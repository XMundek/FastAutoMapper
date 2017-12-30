using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

namespace Moon.FastAutoMapper

{

    public class Mapper : IMapper
    {
        private class ListInfo
        {
            public Type SourceElementType;
            public Type DestinationElementType;        
            public MethodInfo ListMappingMethod;
        }

        private class FieldMappingInfo
        {
            public FieldInfo SourceField;
            public FieldInfo DestinationField;
            public Type SourceFieldType;
            public Type DestinationFieldType;
            public bool IsSimpleMapping;
        }

        //dictionary used to store mapping information between source and destination type 
        private class MappingDictionary<T> : Dictionary<long, T>
        {
            public MappingDictionary(Func<Type, Type, int, T> createMapping)
            {
                CreateMapping = createMapping;
            }

            private Func<Type, Type, int, T> CreateMapping;

            public T GetMapping(Type sourceType, Type destType, int level)
            {
                var key = Mapper.GetMappingKey(sourceType, destType);
                if (this.ContainsKey(key))
                {
                    return this[key];
                }
                lock (this)
                {
                    var mappingInfo = CreateMapping(sourceType, destType, level);
                    this[key] = mappingInfo;
                    return mappingInfo;

                }
            }

            public void SetMapping(long key, T value)
            {
                lock (this)
                {
                    this[key] = value;
                }
            }

            public void DeleteMapping(long key)
            {
                if (this.ContainsKey(key))
                {
                    this.Remove(key);
                }
            }
        }

        private static class MappingPrimitivesConverter
        {

            public static string ToString(double f)
            {
                return f.ToString(MappingCulture);
            }
            public static string ToString(float f)
            {
                return f.ToString(MappingCulture);
            }
            public static string ToString(decimal f)
            {
                return f.ToString(MappingCulture);
            }
            public static string ToString(DateTime f)
            {
                return f.ToString(MappingCulture);
            }
            public static double ToDouble(string input)
            {
                return Convert.ToDouble(input, MappingCulture);
            }
            public static decimal ToDecimal(string input)
            {
                return Convert.ToDecimal(input, MappingCulture);
            }
            public static float ToSingle(string input)
            {
                return Convert.ToSingle(input, MappingCulture);
            }
            public static DateTime ToDateTime(string input)
            {
                return Convert.ToDateTime(input, MappingCulture);
            }
            
        }

        public TDestination Map<TSource, TDestination>(TSource source)
        {
            if (source == null) return default(TDestination);
            var sourceType = typeof(TSource);
            var destinationType = typeof(TDestination);

            if (sourceType == destinationType)
                return (TDestination)(object)source;
            return MapClass<TSource, TDestination>(source,  1);
        }

        private const int MaxCompareLevel = 30;

        private static readonly MappingDictionary<Delegate> typeMapping =
            new MappingDictionary<Delegate>(CreateObjectMapping);

        private static readonly Dictionary<long, Dictionary<int, int>> enumMapping=
            new Dictionary<long, Dictionary<int, int>>();

        private static readonly MappingDictionary<ListInfo> listMapping =
            new MappingDictionary<ListInfo>(CreateListMapping);

        private static readonly MappingDictionary<MethodInfo> listMethod =
            new MappingDictionary<MethodInfo>(CreateMethodMapping);

        private static readonly Type objectTypeInfo = typeof(object);
        private static readonly Type funcType = typeof(Func<,>);
        private static readonly Type stringType = typeof(string);

        private static readonly MethodInfo mapObjectMethodInfo = GetMappingMethod("MapClass");

        private static readonly MethodInfo mapEnumMethodInfo = GetMappingMethod("MapEnum");
        private static readonly MethodInfo mapArrayMethodInfo = GetMappingMethod("MapArray");
        private static readonly MethodInfo mapListToArrayMethodInfo = GetMappingMethod("MapListToArray");
        private static readonly MethodInfo mapArrayToListMethodInfo = GetMappingMethod("MapArrayToList");
        private static readonly MethodInfo mapItemToArrayMethodInfo = GetMappingMethod("MapItemToArray");
        private static readonly MethodInfo mapArrayToItemMethodInfo = GetMappingMethod("MapArrayToItem");

        private static readonly MethodInfo mapStringToEnumMethodInfo = GetMappingMethod("MapStringToEnum");
        private static MethodInfo GetMappingMethod(string name)
        {
            return typeof(Mapper).GetMethod(name,
                BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
        }

        private static readonly Module dynamicModule = GetDynamicModule();

        private static Module GetDynamicModule()
        {
            return AppDomain.CurrentDomain
                .DefineDynamicAssembly(new AssemblyName("_"), AssemblyBuilderAccess.Run)
                .DefineDynamicModule("_");
        }

        static Mapper()
        {
            var types = new Type[]
            {
                typeof(int),typeof(long),typeof(short),typeof(sbyte),
                typeof(uint),typeof(ulong),typeof(ushort),typeof(byte),
                typeof(bool),typeof(char),
                typeof(float),typeof(double),typeof(decimal),typeof(DateTime),
                typeof(string),typeof(object)
            };
            var len = types.Length;


            var simpleMapperMethods = typeof(MappingPrimitivesConverter).GetMethods(BindingFlags.Static | BindingFlags.Public);
            var converterMethods = typeof(Convert).GetMethods(BindingFlags.Static | BindingFlags.Public)
                .Where(p => p.Name.StartsWith("To") && p.GetParameters().Length == 1).ToArray();
            for (var i = 0; i < len - 1; i++)
            {
                var destType = types[i];
                var destTypeHash = destType.GetHashCode();
                for (var j = 0; j < len; j++)
                {
                    var sourceType = types[j];
                    if (destType == sourceType) continue;
                    var sourceTypeHash = sourceType.GetHashCode();
                    //var methodName = "To" + destType.Name;
                    var method = GetPrimitiveConvertMethod(simpleMapperMethods, sourceType,destType);
                    if (method == null)
                    {
                        method = GetPrimitiveConvertMethod(converterMethods, sourceType,destType);
                    }
                    if (method != null)
                    {
                        var mappingKey = GetMappingKey(sourceTypeHash, destTypeHash);
                        primitiveTypeMappings[mappingKey] = method;
                        listMethod[mappingKey] = method;
                        typeMapping[mappingKey] = method.CreateDelegate(funcType.MakeGenericType(sourceType, destType));
                    }
                }
            }
        }
        private static MethodInfo GetPrimitiveConvertMethod(MethodInfo[] list, Type sourceType, Type destType)
        {            
            return list.FirstOrDefault(m=>m.ReturnType==destType && m.GetParameters()[0].ParameterType == sourceType);
        }
        public static CultureInfo MappingCulture = CultureInfo.InvariantCulture;

        private static Dictionary<long, MethodInfo> primitiveTypeMappings = new Dictionary<long, MethodInfo>();

        private static long GetMappingKey(Type sourceType, Type destinationType)
        {
            return (((long)sourceType.GetHashCode()) << 32) + destinationType.GetHashCode();
        }
        private static long GetMappingKey(int sourceType, int destinationType)
        {
            return (((long)sourceType) << 32) + destinationType;
        }

        public static void AddMapping<TSource, TDestination>(Func<TSource, TDestination> f)
        {
            var key = GetMappingKey(typeof(TSource), typeof(TDestination));
            typeMapping.SetMapping(key, f);
            listMethod.SetMapping(key, f.Method);
        }
        public static void DeleteMapping<TSource, TDestination>()
        {
            var key = GetMappingKey(typeof(TSource), typeof(TDestination));

            typeMapping.DeleteMapping(key);
            listMethod.DeleteMapping(key);
        }
        private static Dictionary<int, int> CreateEnumMapping(Type sourceType, Type destinationType)
        {
            var enumMappings = new Dictionary<int, int>();
            IList enumValues = Enum.GetValues(sourceType);
            for (var i = enumValues.Count - 1; i > -1; i--)
            {
                var value = enumValues[i];
                try
                {
                    enumMappings.Add((int)value, (int)Enum.Parse(destinationType, value.ToString()));
                }
                catch
                {
                }
            }
            return enumMappings;
        }

        private static Type GetElementType(Type sourceType)
        {
            return sourceType.IsArray
                ? sourceType.GetElementType()
                : sourceType.IsGenericType//is iList
                    ? sourceType.GenericTypeArguments[0]
                    : sourceType;

        }
        private static ListInfo CreateListMapping(Type sourceType, Type destinationType, int level)
        {

            MethodInfo mappingMethod;
            if (destinationType.IsArray && sourceType.IsArray)
                mappingMethod = mapArrayMethodInfo;
            else
            {
                mappingMethod = destinationType.IsArray
                    ? sourceType.GetInterfaces().Contains(typeof(IList))
                        ? mapListToArrayMethodInfo : mapItemToArrayMethodInfo
                    : destinationType.GetInterfaces().Contains(typeof(IList))
                        ? mapArrayToListMethodInfo : mapArrayToItemMethodInfo;
            }
            var sourceElementType = GetElementType(sourceType);
            var destElementType = GetElementType(destinationType);


            return new ListInfo()
            {
                ListMappingMethod = mappingMethod.MakeGenericMethod(sourceElementType,destElementType),
                SourceElementType = sourceElementType,
                DestinationElementType = destElementType
            };
        }

        private static MethodInfo CreateMethodMapping(Type sourceType, Type destinationType, int level)
        {
            if (destinationType.IsArray || sourceType.IsArray)
            {
                return listMapping.GetMapping(sourceType, destinationType,level).ListMappingMethod;
            }
            return mapObjectMethodInfo.MakeGenericMethod(new Type[] { sourceType, destinationType });
        }

        private static bool LoadFields(Type sourceType, Type destinationType, List<FieldMappingInfo> fieldMappings)
        {
            bool isComplexMapping = false;
            while (destinationType != objectTypeInfo)
            {
                var fields =
                    destinationType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                for (var i = fields.Length - 1; i > -1; i--)
                {
                    var destinationField = fields[i];
                    var sourceField = GetFieldInfo(sourceType, destinationField.Name);
                    if (sourceField != null)
                    {
                        var sourceFieldType = sourceField.FieldType;
                        var destinationFieldType = destinationField.FieldType;


                        var fieldMapping = new FieldMappingInfo()
                        {
                            SourceField = sourceField,
                            DestinationField = destinationField
                        };

                        if (sourceFieldType.IsEnum || destinationFieldType.IsEnum)
                        {
                            if (!(sourceFieldType.IsEnum && destinationFieldType.IsEnum))
                            {
                                if (sourceFieldType.IsEnum)
                                {
                                    if (destinationFieldType != stringType)
                                        sourceFieldType = Enum.GetUnderlyingType(sourceFieldType);
                                }
                                else
                                {
                                    if (sourceFieldType != stringType)
                                        destinationFieldType = Enum.GetUnderlyingType(destinationFieldType);
                                }
                            }
                        }

                        if (sourceFieldType == destinationFieldType)
                        {
                            fieldMapping.IsSimpleMapping = true;
                        }
                        else
                        {
                            fieldMapping.SourceFieldType = sourceFieldType;
                            fieldMapping.DestinationFieldType = destinationFieldType;
                            isComplexMapping = true;
                        }
                        fieldMappings.Add(fieldMapping);
                    }
                }
                destinationType = destinationType.BaseType;
            }
            return isComplexMapping;
        }

        private static FieldInfo GetFieldInfo(Type type, string fieldName)
        {
            do
            {
                var field = type.GetField(fieldName, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                if (field != null) return field;
                type = type.BaseType;
            } while (type != objectTypeInfo);
            return null;
        }

        private static void EmitListMapping(ILGenerator iL, Type sourceType,Type destType, int level)
        {
            iL.Emit(OpCodes.Ldarg_0);
            //load level variable 
            iL.Emit(OpCodes.Ldc_I4, level);
            //call Map{Object|Array|List}(object source,Type sorceType,Type destType,int level)
            iL.Emit(OpCodes.Call, listMapping.GetMapping(sourceType,destType,1).ListMappingMethod);
        }

        private static long GetEnumMapping(Type sourceType, Type destType)
        {
            var mappingKey = GetMappingKey(sourceType, destType);
            if (!enumMapping.ContainsKey(mappingKey))
            {
                enumMapping[mappingKey] = CreateEnumMapping(sourceType, destType);
            }
            return mappingKey;
        }
        private static void EmitEnumMapping(ILGenerator iL, Type sourceType, Type destType)
        {
            iL.Emit(OpCodes.Ldarg_0);
            iL.Emit(OpCodes.Ldc_I8, GetEnumMapping(sourceType,destType));
            iL.Emit(OpCodes.Call, mapEnumMethodInfo);
        }

        private static void EmitStringToEnumMapping(ILGenerator iL, Type destinationType)
        {
            iL.Emit(OpCodes.Ldarg_0);
            iL.Emit(OpCodes.Call, mapStringToEnumMethodInfo.MakeGenericMethod(destinationType));
        }

        private static void EmitStringMapping(ILGenerator iL, Type sourceType)
        {
            iL.Emit(OpCodes.Ldarga_S, 0);
            iL.Emit(OpCodes.Constrained, sourceType);
            iL.Emit(OpCodes.Callvirt, objectTypeInfo.GetMethod("ToString"));
        }

        private static void EmitObjectMapping(ILGenerator iL, Type sourceType)
        {
            iL.Emit(OpCodes.Ldarg_0);
            if (sourceType.IsValueType)
                iL.Emit(OpCodes.Box, sourceType);
        }

        private static void EmitSimpleClassMapping(ILGenerator iL, List<FieldMappingInfo> fieldMappings)
        {
            for (var i = fieldMappings.Count - 1; i > -1; i--)
            {
                var fieldMapping = fieldMappings[i];
                //copy topmost value from stack and push onto stack (in this case new destination object)
                iL.Emit(OpCodes.Dup);
                //load source object
                iL.Emit(OpCodes.Ldarg_0);
                //copy from source field to destination
                iL.Emit(OpCodes.Ldfld, fieldMapping.SourceField);
                iL.Emit(OpCodes.Stfld, fieldMapping.DestinationField);
            }
        }

        private static void EmitSimpleFieldMapping(ILGenerator iL, FieldMappingInfo fieldMapping, bool isClass)
        {
            if (isClass)
                iL.Emit(OpCodes.Ldloc_0);
            else
                iL.Emit(OpCodes.Ldloca_S, 0);
            //load source reference
            iL.Emit(OpCodes.Ldarg_0);
            //copy source field to destination
            iL.Emit(OpCodes.Ldfld, fieldMapping.SourceField);
            iL.Emit(OpCodes.Stfld, fieldMapping.DestinationField);
        }
        private static void EmitStringToEnumFieldMapping(ILGenerator iL, FieldMappingInfo fieldMapping, bool isClass)
        {
            //load destination from variable at 0 position
            EmitLoadDestinationObject(iL, isClass);
            //load source from argument
            iL.Emit(OpCodes.Ldarg_0);
            //load parameters to MapEnumInternal method
            iL.Emit(OpCodes.Ldfld, fieldMapping.SourceField);
            //call MapEnumInternal
            iL.Emit(OpCodes.Call, mapStringToEnumMethodInfo.MakeGenericMethod(fieldMapping.DestinationFieldType));
            //set mapped value to destination field
            iL.Emit(OpCodes.Stfld, fieldMapping.DestinationField);
        }
        private static void EmitStringFieldMapping(ILGenerator iL, FieldMappingInfo fieldMapping, bool isClass)
        {
            //load destination from variable at 0 position
            EmitLoadDestinationObject(iL, isClass);
            //load source from argument
            iL.Emit(OpCodes.Ldarg_0);
            //load parameters to MapEnumInternal method
            iL.Emit(OpCodes.Ldflda, fieldMapping.SourceField);
            iL.Emit(OpCodes.Constrained, fieldMapping.SourceFieldType);
            //call MapEnumInternal
            iL.Emit(OpCodes.Callvirt, objectTypeInfo.GetMethod("ToString"));
            //set mapped value to destination field
            iL.Emit(OpCodes.Stfld, fieldMapping.DestinationField);
        }
        private static void EmitEnumFieldMapping(ILGenerator iL, FieldMappingInfo fieldMapping, bool isClass)
        {
            EmitLoadDestinationObject(iL, isClass);
            //load source from argument
            iL.Emit(OpCodes.Ldarg_0);
            //load parameters to MapEnumInternal method
            iL.Emit(OpCodes.Ldfld, fieldMapping.SourceField);
            iL.Emit(OpCodes.Ldc_I8, GetEnumMapping(fieldMapping.SourceFieldType, fieldMapping.DestinationFieldType));
            //call MapEnumInternal
            iL.Emit(OpCodes.Call, mapEnumMethodInfo);
            //set mapped value to destination field
            iL.Emit(OpCodes.Stfld, fieldMapping.DestinationField);
        }

        private static void EmitPrimitiveFieldMapping(ILGenerator iL, 
            FieldMappingInfo fieldMapping, bool isClass)
        {
            EmitLoadDestinationObject(iL, isClass);
            iL.Emit(OpCodes.Ldarg_0);
            iL.Emit(OpCodes.Ldfld, fieldMapping.SourceField);

            if (fieldMapping.DestinationFieldType == objectTypeInfo)
            {
                if (fieldMapping.SourceFieldType.IsValueType)
                    iL.Emit(OpCodes.Box, fieldMapping.SourceFieldType);
            }
            else
            {
                iL.Emit(OpCodes.Call, primitiveTypeMappings[
                    GetMappingKey(fieldMapping.SourceFieldType,fieldMapping.DestinationFieldType)]);
            }
            iL.Emit(OpCodes.Stfld, fieldMapping.DestinationField);
        }

        private static void EmitComplexFieldMapping(ILGenerator iL, 
            FieldMappingInfo fieldMapping, bool isClass, int level)
        {
            if (fieldMapping.SourceFieldType.IsValueType)
            {
                //load destination object from variable
                EmitLoadDestinationObject(iL, isClass);
                //load source argument
                iL.Emit(OpCodes.Ldarg_0);
                //load field value from source
                iL.Emit(OpCodes.Ldfld, fieldMapping.SourceField);
                EmitComplexSetField(iL, fieldMapping, level);
            }
            else
            {
                Label label = iL.DefineLabel();
                //load source argument
                iL.Emit(OpCodes.Ldarg_0);
                //load field value from source
                iL.Emit(OpCodes.Ldfld, fieldMapping.SourceField);
                //store field value in local variable at 1 position
                iL.Emit(OpCodes.Stloc_1);

                iL.Emit(OpCodes.Ldloc_1);
                //check if field value is not null
                iL.Emit(OpCodes.Brfalse_S, label);
                //load destination object from variable
                EmitLoadDestinationObject(iL, isClass);
                //load source field value from variable
                iL.Emit(OpCodes.Ldloc_1);
                EmitComplexSetField(iL, fieldMapping, level);
                //end if
                iL.MarkLabel(label);
            }
        }

        private static void EmitLoadDestinationObject(ILGenerator iL, bool isClass)
        {
            if (isClass)
                iL.Emit(OpCodes.Ldloc_0);
            else
                iL.Emit(OpCodes.Ldloca_S, 0);
        }
        private static void EmitComplexSetField(ILGenerator iL, FieldMappingInfo fieldMapping,  int level)
        {
            //load level variable 
            iL.Emit(OpCodes.Ldc_I4, level);
            //call Map{Object|Array|List}(object source,Type sorceType,Type destType,int level)
            iL.Emit(OpCodes.Call, listMethod.GetMapping(fieldMapping.SourceFieldType,fieldMapping.DestinationFieldType, level));
            //set mapped value to destination field
            iL.Emit(OpCodes.Stfld, fieldMapping.DestinationField);

        }
        private static void EmitComplexClassMapping(ILGenerator iL, List<FieldMappingInfo> fieldMappings, bool isClass, int level)
        {
            //store destination object in variable at 0 position
            if (isClass)
                iL.Emit(OpCodes.Stloc_0);
            for (var i = fieldMappings.Count - 1; i > -1; i--)
            {
                var fieldMapping = fieldMappings[i];
                if (fieldMapping.IsSimpleMapping)
                {
                    EmitSimpleFieldMapping(iL, fieldMapping, isClass);
                }
                else
                {
                    var sourceFieldType = fieldMapping.SourceFieldType;
                    var destinationFieldType = fieldMapping.DestinationFieldType;

                    if (destinationFieldType.IsEnum && sourceFieldType.IsEnum)
                    {
                        EmitEnumFieldMapping(iL,  fieldMapping, isClass);
                    }
                    else if (primitiveTypeMappings.ContainsKey(GetMappingKey(sourceFieldType,destinationFieldType)))
                    {
                        EmitPrimitiveFieldMapping(iL, fieldMapping, isClass);
                    }
                    else if (destinationFieldType == stringType)
                    {
                        EmitStringFieldMapping(iL, fieldMapping, isClass);
                    }
                    else if (destinationFieldType.IsEnum && sourceFieldType == stringType)
                    {
                        EmitStringToEnumFieldMapping(iL, fieldMapping, isClass);
                    }
                    else
                    {
                        EmitComplexFieldMapping(iL, fieldMapping, isClass, level);
                    }
                }
            }
            //load destination object to stack
            iL.Emit(OpCodes.Ldloc_0);
        }

        private static void EmitSimpleConvertEnumMapping(ILGenerator iL, Type sourceType, Type destinationType)
        {
            if (sourceType.IsEnum)
                sourceType = Enum.GetUnderlyingType(sourceType);
            if (destinationType.IsEnum)
                destinationType = Enum.GetUnderlyingType(destinationType);
            iL.Emit(OpCodes.Ldarg_0);
            if (sourceType != destinationType)
            {
                iL.Emit(OpCodes.Call, listMethod.GetMapping(sourceType, destinationType, 1));
            }
        }
        private static Delegate CreateObjectMapping(Type sourceType, Type destinationType, int level)
        {
            var copyFuncGenerator = new DynamicMethod(
                "_", destinationType, new[] { sourceType }, dynamicModule, true);
            var iL = copyFuncGenerator.GetILGenerator();
            if (sourceType == destinationType)
                iL.Emit(OpCodes.Ldarg_0);
            else if (destinationType == objectTypeInfo)
                EmitObjectMapping(iL, sourceType);
            else if (destinationType == stringType)
                EmitStringMapping(iL, sourceType);
            else if (destinationType.IsArray || sourceType.IsArray)
                EmitListMapping(iL, sourceType,destinationType, level);
            else if (destinationType.IsEnum || sourceType.IsEnum)
            {
                if (destinationType.IsEnum & sourceType.IsEnum)
                    EmitEnumMapping(iL, sourceType, destinationType);
                else if (sourceType == stringType)
                {
                    EmitStringToEnumMapping(iL, destinationType);
                }
                else if (EmitNullableMapping(iL, sourceType, destinationType))
                {

                }
                else
                {
                    EmitSimpleConvertEnumMapping(iL, sourceType, destinationType);
                }
            }
            else
            {            
                bool isClass = !destinationType.IsValueType;
                if (EmitNullableMapping(iL,sourceType,destinationType))
                {
                }
                else if (EmitInitObject(iL, destinationType, isClass))
                {
                    var fieldMappings = new List<FieldMappingInfo>();
                    bool isComplexMapping = LoadFields(sourceType, destinationType, fieldMappings);                    
                    if (isComplexMapping || !isClass)
                    {
                        iL.DeclareLocal(destinationType);
                        iL.DeclareLocal(objectTypeInfo);
                        EmitComplexClassMapping(iL, fieldMappings, isClass, level);
                    }
                    else
                        EmitSimpleClassMapping(iL, fieldMappings);
                }
            }
            iL.Emit(OpCodes.Ret);
            return copyFuncGenerator.CreateDelegate(
                funcType.MakeGenericType(sourceType, destinationType));
        }
        private static bool EmitNullableMapping(ILGenerator iL, Type sourceType, Type destinationType)
        {
            bool isSourceNullable = sourceType.IsValueType && sourceType.Name.Contains("Nullable");
            bool isDestinationNullable = sourceType.IsValueType && destinationType.Name.Contains("Nullable");

            if (isSourceNullable && !isDestinationNullable)
            {
                EmitNullableToPrimitiveMapping(iL, sourceType, destinationType);
                return true;
            }
            else if (!isSourceNullable && isDestinationNullable)
            {
                EmitPrimitiveToNullableMapping(iL, sourceType, destinationType);
                return true;
            }
            return false;
        }

        private static void EmitPrimitiveToNullableMapping(ILGenerator iL, FieldInfo hasValue)
        {
            iL.Emit(OpCodes.Ldloca_S, 0);
            iL.Emit(OpCodes.Ldc_I4_1);
            iL.Emit(OpCodes.Stfld, hasValue);
            iL.Emit(OpCodes.Ldloca_S, 0);
            iL.Emit(OpCodes.Ldarg_0);

        }
        private static void EmitPrimitiveToNullableMapping(ILGenerator iL, Type sourceType, Type destinationType) {
            var hasValue = GetFieldInfo(destinationType, "hasValue");
            var value = GetFieldInfo(destinationType, "value");
            iL.DeclareLocal(destinationType);
            iL.Emit(OpCodes.Ldloca_S, 0);
            iL.Emit(OpCodes.Initobj, destinationType);
            destinationType = value.FieldType;
            if (destinationType == sourceType) {
                EmitPrimitiveToNullableMapping(iL, hasValue);
                iL.Emit(OpCodes.Stfld, value);
            }
            else
            {
                var mappingKey = GetMappingKey(sourceType, destinationType);
                if (primitiveTypeMappings.ContainsKey(mappingKey))
                {
                    EmitPrimitiveToNullableMapping(iL, hasValue);
                    iL.Emit(OpCodes.Call, primitiveTypeMappings[mappingKey]);
                    iL.Emit(OpCodes.Stfld, value);
                }
                else if (destinationType.IsEnum && sourceType.IsEnum)
                {
                    EmitPrimitiveToNullableMapping(iL, hasValue);
                    iL.Emit(OpCodes.Ldc_I8, GetEnumMapping(sourceType, destinationType));
                    iL.Emit(OpCodes.Call, mapEnumMethodInfo);
                    iL.Emit(OpCodes.Stfld, value);

                }
            }            
            iL.Emit(OpCodes.Ldloc_0);
        }

        private static void EmitNullableToPrimitiveMapping(ILGenerator iL,Type destinationType, FieldInfo hasValue, FieldInfo value)
        {            
            iL.Emit(OpCodes.Ldarg_0);
            iL.Emit(OpCodes.Ldfld, hasValue);
            var label = iL.DefineLabel();
            iL.Emit(OpCodes.Brtrue_S, label);
            iL.Emit(OpCodes.Ldloca_S, 0);
            iL.Emit(OpCodes.Initobj,destinationType);
            iL.Emit(OpCodes.Ldloc_0);
            iL.Emit(OpCodes.Ret);
            iL.MarkLabel(label);
            iL.Emit(OpCodes.Ldarg_0);
            iL.Emit(OpCodes.Ldfld, value);
        }
        private static void EmitNullableToPrimitiveMapping(ILGenerator iL, Type sourceType, Type destinationType)
        {
            var hasValue = GetFieldInfo(sourceType, "hasValue");
            var value = GetFieldInfo(sourceType, "value");
            sourceType = value.FieldType;
            iL.DeclareLocal(destinationType);
            if (sourceType == destinationType)
            {
                EmitNullableToPrimitiveMapping(iL,destinationType, hasValue, value);
            }
            else
            {
                var mappingKey = GetMappingKey(sourceType, destinationType);
                if (primitiveTypeMappings.ContainsKey(mappingKey))
                {
                    EmitNullableToPrimitiveMapping(iL,destinationType, hasValue, value);
                    iL.Emit(OpCodes.Call, primitiveTypeMappings[mappingKey]);
                }
                else if (destinationType.IsEnum && sourceType.IsEnum)
                {
                    EmitNullableToPrimitiveMapping(iL, destinationType, hasValue, value);
                    iL.Emit(OpCodes.Ldc_I8, GetEnumMapping(sourceType, destinationType));
                    iL.Emit(OpCodes.Call, mapEnumMethodInfo);
                }
                else if (destinationType.IsValueType)
                {
                    iL.Emit(OpCodes.Ldloca_S, 0);
                    iL.Emit(OpCodes.Initobj, destinationType);
                    iL.Emit(OpCodes.Ldloc_0);
                }
                else
                {
                    iL.Emit(OpCodes.Ldnull);
                }

            }           
        }
        private static bool EmitInitObject(ILGenerator iL, Type destinationType, bool isClass)
        {
            if (isClass)
            {
                var ctor = destinationType.GetConstructor(Type.EmptyTypes);
                if (ctor == null)
                {
                    iL.Emit(OpCodes.Ldnull);
                    return false;
                }
                iL.Emit(OpCodes.Newobj, ctor);

            }
            else
            {
                iL.Emit(OpCodes.Ldloca_S, 0);
                iL.Emit(OpCodes.Initobj, destinationType);
            }
            return true;
        }
        private static int MapEnum(int source, long mappingKey)
        {
            var mapping = enumMapping[mappingKey];
            return mapping.ContainsKey(source) ? mapping[source] : 0;
        }

        private static T MapStringToEnum<T>(string source) where T : struct
        {
            return Enum.TryParse<T>(source, out T result) ? result : default(T);
        }
   
    
        private static TDestination[] MapArray<TSource, TDestination>(TSource[] sourceList,  int level)
        {
            if (sourceList == null) return null;
            var len = sourceList.Length;
            var destinationList = new TDestination[len];
            if (len > 0)
            {
                var mapElementFunction =
                    (Func<TSource, TDestination>) typeMapping.GetMapping(typeof(TSource), typeof(TDestination), level);
                for (var i = 0; i < len; i++)
                {
                    if (sourceList[i]!=null)
                        destinationList[i] = mapElementFunction(sourceList[i]);
                }
            }
            return destinationList;
        }

        internal static TDestination MapClass<TSource, TDestination>(TSource source, int level)
        {
            if( ++level > MaxCompareLevel)
                return default(TDestination); //for break circular reference
            return ((Func<TSource, TDestination>)typeMapping.GetMapping(typeof(TSource),typeof(TDestination), level)
            )(source);
        }
        
        private static TDestination[] MapListToArray<TSource, TDestination>(IList<TSource> sourceList,int level)
        {
            if (sourceList == null) return null;
            var len = sourceList.Count;
            var destinationList = new TDestination[len];
            if (len > 0)
            {
                var mapElementFunction = (Func<TSource, TDestination>)typeMapping.GetMapping(typeof(TSource), typeof(TDestination), level);
                for (var i = 0; i < len; i++)
                {
                    destinationList[i] = mapElementFunction(sourceList[i]);
                }
            }
            return destinationList;
        }

        private static TDestination[] MapItemToArray<TSource, TDestination>(TSource source, int level)
        {
            if (source == null) return null;
            return new[]
            {
                ((Func<TSource, TDestination>) typeMapping.GetMapping(typeof(TSource), typeof(TDestination),level))(source)
            };
        }


        private static List<TDestination> MapArrayToList<TSource, TDestination>(TSource[] sourceList, int level)
        {
            if (sourceList == null) return null;
            var len = sourceList.Length;
            var destinationList = new List<TDestination>(len);
            if (len > 0)
            {
                var mapElementFunction = (Func<TSource, TDestination>)typeMapping.GetMapping(typeof(TSource), typeof(TDestination), level);

                for (var i = 0; i < len; i++)
                {
                    destinationList.Add(mapElementFunction(sourceList[i]));
                }
            }
            return destinationList;
        }

        private static TDestination MapArrayToItem<TSource, TDestination>(TSource[] sourceList, int level)
        {
            if (sourceList == null || sourceList.Length == 0) return default(TDestination);
            return ((Func<TSource, TDestination>)typeMapping.GetMapping(typeof(TSource), typeof(TDestination), level))(sourceList[0]);
        }
    }
}
