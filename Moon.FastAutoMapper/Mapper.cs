using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
namespace Moon.FastAutoMapper
{
    public class Mapper :IMapper
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

        private class DelegateDictionary : MappingDictionary<Delegate>
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            protected sealed override Delegate CreateMapping(Type sourceType, Type destinationType)
            {
                return Mapper.CreateObjectMapping(sourceType, destinationType);
            }
        }

        private class ListInfoDictionary : MappingDictionary<ListInfo>
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            protected sealed override ListInfo CreateMapping(Type sourceType, Type destinationType)
            {
                return Mapper.CreateListMapping(sourceType, destinationType);
            }
        }

        private class MethodInfoDictionary : MappingDictionary<MethodInfo>
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            protected sealed override MethodInfo CreateMapping(Type sourceType, Type destinationType)
            {
                return Mapper.CreateMethodMapping(sourceType, destinationType);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TDestination Map<TDestination>(object source)
        {
            if (source == null)
                return default(TDestination);
            return (TDestination)typeMapping.GetMapping(source.GetType(), typeof(TDestination)).DynamicInvoke(source);
        }

        public static TDestination Map<TSource, TDestination>(TSource source)
        {
            if (source == null) return default(TDestination);
            var sourceType = typeof(TSource);
            var destinationType = typeof(TDestination);

            if (sourceType == destinationType)
                return (TDestination)(object)source;
            return MapClass<TSource, TDestination>(source);
        }

        public static void AddMapping<TSource, TDestination>(Func<TSource, TDestination> f)
        {
            var sourceType = typeof(TSource);
            var destinationType = typeof(TDestination);
            var key = GetMappingKey(sourceType,destinationType);
            typeMapping.SetMapping (key, f);
            var method = f.GetMethodInfo();
            listMethod.SetMapping(key, method.IsStatic ? method : mapCallLambdaMethodInfo.MakeGenericMethod(sourceType,destinationType));
        }

        public static void DeleteMapping<TSource, TDestination>()
        {
            var key = GetMappingKey(typeof(TSource), typeof(TDestination));

            typeMapping.DeleteMapping(key);
            listMethod.DeleteMapping(key);
        }

       public static CultureInfo MappingCulture
        {
            get { return MappingPrimitivesConverter.MappingCulture; }
            set { MappingPrimitivesConverter.MappingCulture = value; }
        }

        private static readonly DelegateDictionary typeMapping = new DelegateDictionary();
        private static readonly ListInfoDictionary listMapping = new ListInfoDictionary();
        private static readonly MethodInfoDictionary listMethod = new MethodInfoDictionary();
        private static readonly Dictionary<long, Dictionary<int, int>> enumMapping = new Dictionary<long, Dictionary<int, int>>(128);
        private static readonly Dictionary<long, MethodInfo> primitiveTypeMappings = new Dictionary<long, MethodInfo>();

        private static readonly Type objectType = typeof(object);
        private static readonly Type funcType = typeof(Func<,>);
        private static readonly Type stringType = typeof(string);
        private static readonly Type intType = typeof(int);
        private static readonly Type nullableType = typeof(Nullable<>);
        private static readonly Type iListType = typeof(IList);
        private static readonly Type listType = typeof(List<>);
        private static readonly Type enumerableType = typeof(IEnumerable);
        private static readonly MethodInfo mapObjectMethodInfo = GetMappingMethod(nameof(MapClass));
        private static readonly MethodInfo mapEnumMethodInfo = GetMappingMethod(nameof(MapEnum));
        private static readonly MethodInfo mapNullableEnumMethodInfo = GetMappingMethod(nameof(MapNullableEnum));
        private static readonly MethodInfo mapComplexEnumMethodInfo = GetMappingMethod(nameof(MapComplexEnum));
        private static readonly MethodInfo mapNullableComplexEnumMethodInfo = GetMappingMethod(nameof(MapNullableComplexEnum));
        private static readonly MethodInfo mapArrayMethodInfo = GetMappingMethod(nameof(MapArray));
        private static readonly MethodInfo mapListToArrayMethodInfo = GetMappingMethod(nameof(MapListToArray));
        private static readonly MethodInfo mapArrayToListMethodInfo = GetMappingMethod(nameof(MapArrayToList));
        private static readonly MethodInfo mapItemToArrayMethodInfo = GetMappingMethod(nameof(MapItemToArray));
        private static readonly MethodInfo mapArrayToItemMethodInfo = GetMappingMethod(nameof(MapArrayToItem));
        private static readonly MethodInfo mapIEnumerableToArrayMethodInfo = GetMappingMethod(nameof(MapIEnumerableToArray));
        private static readonly MethodInfo mapIEnumerableToListMethodInfo = GetMappingMethod(nameof(MapIEnumerableToList));
        private static readonly MethodInfo mapIEnumerableToItemMethodInfo = GetMappingMethod(nameof(MapIEnumerableToItem));
        private static readonly MethodInfo mapStringToEnumMethodInfo = GetMappingMethod(nameof(MapStringToEnum));
        private static readonly MethodInfo mapCallLambdaMethodInfo = GetMappingMethod(nameof(CallLambda));
        private static readonly Module dynamicModule = typeof(Mapper).GetTypeInfo().Module;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMappingMethod(string name)
        {
            return typeof(Mapper).GetTypeInfo().GetMethod(name,
                BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
        }

        static Mapper()
        {
            var simpleMapperMethods = typeof(MappingPrimitivesConverter).GetTypeInfo().GetMethods(BindingFlags.Static | BindingFlags.Public);
            var len = simpleMapperMethods.Length;

            for (var i = 0; i < len; i++)
            {
                var method = simpleMapperMethods[i];
                var sourceType = method.GetParameters()[0].ParameterType;
                var destType = method.ReturnType;
                var mappingKey = GetMappingKey(sourceType, destType);
                primitiveTypeMappings[mappingKey] = method;
                listMethod[mappingKey] = method;
                typeMapping[mappingKey] = method.CreateDelegate(funcType.MakeGenericType(sourceType, destType));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static long GetMappingKey(Type sourceType, Type destinationType)
        {
            return (((long)sourceType.GetHashCode()) << 32) + destinationType.GetHashCode();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Func<TSource, TDestination> GetMapping<TSource, TDestination>()
        {
            return (Func<TSource, TDestination>)typeMapping.GetMapping(typeof(TSource), typeof(TDestination));
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
                    enumMappings.Add((int)value, (int)Enum.Parse(destinationType, value.ToString(), true));
                }
                catch
                {
                }
            }
            return enumMappings;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Type GetElementType(Type sourceType)
        {
            return sourceType.IsArray
                ? sourceType.GetElementType()
                : sourceType.GetTypeInfo().IsGenericType && IsIEnumerable(sourceType)
                    ? sourceType.GenericTypeArguments[0]
                    : sourceType;
        }

        private static MethodInfo GetListMappingMethod(Type sourceType, Type destinationType)
        {
            Type[] interfaces;
            if (destinationType.IsArray)
            {
                if (sourceType.IsArray)
                    return mapArrayMethodInfo;
                if (sourceType.GetTypeInfo().IsGenericType) {            
                    interfaces = sourceType.GetTypeInfo().GetInterfaces();
                    if (interfaces.Contains(iListType))
                        return mapListToArrayMethodInfo;
                    if (interfaces.Contains(enumerableType))
                        return mapIEnumerableToArrayMethodInfo;
                }
                return mapItemToArrayMethodInfo;
            }
            if (sourceType.IsArray)
            {
                if (destinationType.GetTypeInfo().IsGenericType && IsAssignableToList(destinationType))
                       return mapArrayToListMethodInfo;
                return mapArrayToItemMethodInfo;
            }
            if (sourceType.GetTypeInfo().IsGenericType)
            {
                if (destinationType.GetTypeInfo().IsGenericType)
                {
                    if (!destinationType.GetTypeInfo().IsInterface 
                            && destinationType.GetGenericTypeDefinition() == sourceType.GetGenericTypeDefinition())
                        return null;
                    if (!IsIEnumerable(sourceType))
                        return null;
                    if (IsAssignableToList(destinationType))
                        return mapIEnumerableToListMethodInfo;
                    return mapIEnumerableToItemMethodInfo;
                }
                if (IsIEnumerable(sourceType))
                    return mapIEnumerableToItemMethodInfo;
            }
            return null;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool IsIEnumerable(Type sourceType)
        {
            return sourceType.GetTypeInfo().GetInterfaces().Contains(enumerableType);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool IsAssignableToList(Type destinationType)
        {
            return destinationType.GetTypeInfo().IsAssignableFrom(listType.MakeGenericType(destinationType.GenericTypeArguments[0]));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ListInfo CreateListMapping(Type sourceType, Type destinationType)
        {
            var mappingMethod = GetListMappingMethod(sourceType,destinationType);
            if (mappingMethod == null) return null;
            var sourceElementType = GetElementType(sourceType);
            var destElementType = GetElementType(destinationType);
            return new ListInfo()
            {
                ListMappingMethod = mappingMethod.MakeGenericMethod(sourceElementType, destElementType),
                SourceElementType = sourceElementType,
                DestinationElementType = destElementType
            };
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo CreateMethodMapping(Type sourceType, Type destinationType)
        {
            var mapping = listMapping.GetMapping(sourceType, destinationType);
            if (mapping != null)
                return mapping.ListMappingMethod;
            return mapObjectMethodInfo.MakeGenericMethod(sourceType, destinationType);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Dictionary<long, FieldInfo> GetFields(Type type)
        {

            var fieldDictionary = new Dictionary<long, FieldInfo>();
            var bindingFlags = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public;
            while (type != objectType)
            {
                var fields = type.GetTypeInfo().GetFields(bindingFlags);
                for (var i = fields.Length - 1; i > -1; i--)
                {
                    var field = fields[i];
                    var fieldKey = GetFieldNameHash(field.Name);
                    if (!fieldDictionary.ContainsKey(fieldKey))
                    {
                        fieldDictionary[fieldKey] = field;
                    }
                }
                bindingFlags = BindingFlags.Instance | BindingFlags.NonPublic;
                type = type.GetTypeInfo().BaseType;
            }
            return fieldDictionary;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static long GetFieldNameHash(string fieldName)
        {
            if (fieldName[0] == '<')
                fieldName = fieldName.Substring(1, fieldName.IndexOf(">", 2) - 1);
            return fieldName.ToUpper().GetHashCode();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool LoadFields(Type sourceType, Type destinationType, List<FieldMappingInfo> fieldMappings)
        {
            var sourceFields = GetFields(sourceType);
            if (sourceFields.Count == 0) return false;
            bool isComplexMapping = false;
            var bindingFlags = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public;
            while (destinationType != objectType)
            {
                var fields = destinationType.GetTypeInfo().GetFields(bindingFlags);
                for (var i = fields.Length - 1; i > -1; i--)
                {
                    var destinationField = fields[i];
                    sourceFields.TryGetValue(GetFieldNameHash(destinationField.Name), out var sourceField);
                    if (sourceField != null)
                    {
                        var sourceFieldType = sourceField.FieldType;
                        var destinationFieldType = destinationField.FieldType;

                        var fieldMapping = new FieldMappingInfo()
                        {
                            SourceField = sourceField,
                            DestinationField = destinationField
                        };
                        if (sourceFieldType.GetTypeInfo().IsEnum)
                        {
                            if (!(destinationFieldType.GetTypeInfo().IsEnum || destinationFieldType == stringType || destinationFieldType == objectType || IsNullable(destinationFieldType)))
                                sourceFieldType = GetEnumType(sourceFieldType);
                        }
                        else if (destinationFieldType.GetTypeInfo().IsEnum && !(sourceFieldType == stringType || IsNullable(sourceFieldType)))
                                destinationFieldType = GetEnumType(destinationFieldType);

                        if (sourceFieldType == destinationFieldType)
                            fieldMapping.IsSimpleMapping = true;
                        else
                        {
                            fieldMapping.SourceFieldType = sourceFieldType;
                            fieldMapping.DestinationFieldType = destinationFieldType;
                            isComplexMapping = true;
                        }
                        fieldMappings.Add(fieldMapping);
                    }
                }
                destinationType = destinationType.GetTypeInfo().BaseType;
                bindingFlags = BindingFlags.Instance | BindingFlags.NonPublic;
            }
            return isComplexMapping;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static FieldInfo GetFieldByExactName(Type type, string fieldName)
        {
            return type.GetTypeInfo().GetField(fieldName, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool EmitListMapping(ILGenerator iL, Type sourceType, Type destType)
        {
            var mapping= listMapping.GetMapping(sourceType, destType);
            if (mapping == null) return false;
            iL.Emit(OpCodes.Ldarg_0);
            //call Map{Object|Array|List}(object source)
            iL.Emit(OpCodes.Call, mapping.ListMappingMethod);
            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static long GetEnumMapping(Type sourceType, Type destType)
        {
            var mappingKey = GetMappingKey(sourceType, destType);
            if (!enumMapping.ContainsKey(mappingKey))
            {
                enumMapping[mappingKey] = CreateEnumMapping(sourceType, destType);
            }
            return mappingKey;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Type GetEnumType(Type enumType)
        {
            return enumType.GetTypeInfo().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)[0].FieldType;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool IsSimpleEnum(Type enumType)
        {
            return GetEnumType(enumType) == intType;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void EmitEnumMapping(ILGenerator iL, Type sourceType, Type destType)
        {
            if (IsSimpleEnum(sourceType) && IsSimpleEnum(destType))
            {
                iL.Emit(OpCodes.Ldc_I8, GetEnumMapping(sourceType, destType));
                iL.Emit(OpCodes.Call, mapEnumMethodInfo);
            }
            else
                iL.Emit(OpCodes.Call, mapComplexEnumMethodInfo.MakeGenericMethod(sourceType, destType));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void EmitStringToEnumMapping(ILGenerator iL, Type destinationType)
        {
            iL.Emit(OpCodes.Ldarg_0);
            iL.Emit(OpCodes.Call, mapStringToEnumMethodInfo.MakeGenericMethod(destinationType));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void EmitStringMapping(ILGenerator iL, Type sourceType)
        {
            iL.Emit(OpCodes.Ldarga_S, 0);
            iL.Emit(OpCodes.Constrained, sourceType);
            iL.Emit(OpCodes.Callvirt, objectType.GetTypeInfo().GetMethod("ToString"));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void EmitObjectMapping(ILGenerator iL, Type sourceType)
        {
            iL.Emit(OpCodes.Ldarg_0);
            if (sourceType.GetTypeInfo().IsValueType)
                iL.Emit(OpCodes.Box, sourceType);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
            iL.Emit(OpCodes.Callvirt, objectType.GetTypeInfo().GetMethod("ToString"));
            //set mapped value to destination field
            iL.Emit(OpCodes.Stfld, fieldMapping.DestinationField);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool EmitPrimitiveFieldMapping(ILGenerator iL,
            FieldMappingInfo fieldMapping, bool isClass)
        {
            var mappingKey = GetMappingKey(fieldMapping.SourceFieldType, fieldMapping.DestinationFieldType);
            if (!primitiveTypeMappings.ContainsKey(mappingKey))
                return false;
            EmitLoadDestinationObject(iL, isClass);
            iL.Emit(OpCodes.Ldarg_0);
            iL.Emit(OpCodes.Ldfld, fieldMapping.SourceField);

            iL.Emit(OpCodes.Call, primitiveTypeMappings[mappingKey]);
            iL.Emit(OpCodes.Stfld, fieldMapping.DestinationField);
            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void EmitComplexFieldMapping(ILGenerator iL, FieldMappingInfo fieldMapping, bool isClass)
        {
            if (fieldMapping.SourceFieldType.GetTypeInfo().IsValueType)
            {
                //load destination object from variable
                EmitLoadDestinationObject(iL, isClass);
                //load source argument
                iL.Emit(OpCodes.Ldarg_0);
                //load field value from source
                iL.Emit(OpCodes.Ldfld, fieldMapping.SourceField);
                EmitComplexSetField(iL, fieldMapping);
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
                EmitComplexSetField(iL, fieldMapping);
                //end if
                iL.MarkLabel(label);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void EmitLoadDestinationObject(ILGenerator iL, bool isClass)
        {
            if (isClass)
                iL.Emit(OpCodes.Ldloc_0);
            else
                iL.Emit(OpCodes.Ldloca_S, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void EmitComplexSetField(ILGenerator iL, FieldMappingInfo fieldMapping)
        {
            //call Map{Object|Array|List}(object source)
            iL.Emit(OpCodes.Call, listMethod.GetMapping(fieldMapping.SourceFieldType, fieldMapping.DestinationFieldType));
            //set mapped value to destination field
            iL.Emit(OpCodes.Stfld, fieldMapping.DestinationField);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void EmitComplexClassMapping(ILGenerator iL, List<FieldMappingInfo> fieldMappings, bool isClass)
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

                    if (destinationFieldType.GetTypeInfo().IsEnum && sourceFieldType.GetTypeInfo().IsEnum
                        && IsSimpleEnum(destinationFieldType) && IsSimpleEnum(sourceFieldType))
                    {
                        EmitEnumFieldMapping(iL, fieldMapping, isClass);
                    }
                    else if (EmitPrimitiveFieldMapping(iL, fieldMapping, isClass))
                    {
                    }
                    else if (destinationFieldType == stringType)
                    {
                        EmitStringFieldMapping(iL, fieldMapping, isClass);
                    }
                    else if (destinationFieldType.GetTypeInfo().IsEnum && sourceFieldType == stringType)
                    {
                        EmitStringToEnumFieldMapping(iL, fieldMapping, isClass);
                    }
                    else
                    {
                        EmitComplexFieldMapping(iL, fieldMapping, isClass);
                    }
                }
            }
            //load destination object to stack
            iL.Emit(OpCodes.Ldloc_0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void EmitSimpleConvertEnumMapping(ILGenerator iL, Type sourceType, Type destinationType)
        {
            if (sourceType.GetTypeInfo().IsEnum)
                sourceType = GetEnumType(sourceType);
            else if (destinationType.GetTypeInfo().IsEnum)
                destinationType = GetEnumType(destinationType);
            iL.Emit(OpCodes.Ldarg_0);
            if (sourceType != destinationType)
            {
                iL.Emit(OpCodes.Call, listMethod.GetMapping(sourceType, destinationType));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Delegate CreateObjectMapping(Type sourceType, Type destinationType)
        {
            var copyFuncGenerator = new DynamicMethod(
                "_", destinationType, new[] { sourceType }, dynamicModule, true);
            var iL = copyFuncGenerator.GetILGenerator();
            if (sourceType == destinationType)
                iL.Emit(OpCodes.Ldarg_0);
            else if (destinationType == objectType)
                EmitObjectMapping(iL, sourceType);
            else if (destinationType == stringType)
                EmitStringMapping(iL, sourceType);
            else if (EmitListMapping(iL, sourceType, destinationType))
            {
            }
            else if (destinationType.GetTypeInfo().IsEnum || sourceType.GetTypeInfo().IsEnum)
            {
                if (destinationType.GetTypeInfo().IsEnum & sourceType.GetTypeInfo().IsEnum)
                {
                    iL.Emit(OpCodes.Ldarg_0);
                    EmitEnumMapping(iL, sourceType, destinationType);
                }
                else if (sourceType == stringType)
                {
                    EmitStringToEnumMapping(iL, destinationType);
                }
                else if (!EmitNullableMapping(iL, sourceType, destinationType))
                {
                    EmitSimpleConvertEnumMapping(iL, sourceType, destinationType);
                }
            }
            else
            {
                bool isClass = !destinationType.GetTypeInfo().IsValueType;
                if (EmitNullableMapping(iL, sourceType, destinationType))
                {
                }
                else if (EmitInitObject(iL, destinationType, isClass))
                {
                    var fieldMappings = new List<FieldMappingInfo>();
                    bool isComplexMapping = LoadFields(sourceType, destinationType, fieldMappings);
                    if (isComplexMapping || !isClass)
                    {
                        iL.DeclareLocal(destinationType);
                        iL.DeclareLocal(objectType);
                        EmitComplexClassMapping(iL, fieldMappings, isClass);
                    }
                    else
                        EmitSimpleClassMapping(iL, fieldMappings);
                }
            }
            iL.Emit(OpCodes.Ret);
            return copyFuncGenerator.CreateDelegate(
                funcType.MakeGenericType(sourceType, destinationType));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool IsNullable(Type sourceType)
        {
            return sourceType.GetTypeInfo().IsGenericType && sourceType.GetGenericTypeDefinition() == nullableType;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool EmitNullableMapping(ILGenerator iL, Type sourceType, Type destinationType)
        {
            bool isSourceNullable = IsNullable(sourceType);
            bool isDestinationNullable = IsNullable(destinationType);

            if (isSourceNullable && !isDestinationNullable)
            {
                EmitNullableToPrimitiveMapping(iL, sourceType, destinationType);
                return true;
            }
            if (!isSourceNullable && isDestinationNullable)
            {
                EmitPrimitiveToNullableMapping(iL, sourceType, destinationType);
                return true;
            }
            return false;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void EmitStructInit(ILGenerator iL, Type type)
        {
            iL.DeclareLocal(type);
            iL.Emit(OpCodes.Ldloca_S, 0);
            iL.Emit(OpCodes.Initobj, type);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void EmitNullableTypeInstance(ILGenerator iL, Type type )
        {
            EmitStructInit(iL,type);
            iL.Emit(OpCodes.Ldloca_S, 0);
            iL.Emit(OpCodes.Ldc_I4_1);
            iL.Emit(OpCodes.Stfld, GetFieldByExactName(type, "hasValue"));
            iL.Emit(OpCodes.Ldloca_S, 0);
            iL.Emit(OpCodes.Ldarg_0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void EmitNullableTypeInstance(ILGenerator iL, Type type, FieldInfo value)
        {
            EmitNullableTypeInstance(iL, type);
            iL.Emit(OpCodes.Stfld, value);
            iL.Emit(OpCodes.Ldloc_0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void EmitPrimitiveToNullableMapping(ILGenerator iL, Type sourceType, Type destinationType)
        {
            var value = GetFieldByExactName(destinationType, "value");
            var destinationValueType = value.FieldType;
            
            if (destinationValueType == sourceType)
                EmitNullableTypeInstance(iL,destinationType,value);
            else 
            {
                if (destinationValueType.GetTypeInfo().IsEnum)
                {
                    if (sourceType.GetTypeInfo().IsEnum)
                    {
                        iL.Emit(OpCodes.Ldarg_0);
                        if (IsSimpleEnum(sourceType) && IsSimpleEnum(destinationValueType))
                        {
                            iL.Emit(OpCodes.Ldc_I8, GetEnumMapping(sourceType, destinationValueType));
                            iL.Emit(OpCodes.Call, mapNullableEnumMethodInfo);
                        }
                        else
                            iL.Emit(OpCodes.Call, mapNullableComplexEnumMethodInfo.MakeGenericMethod(sourceType, destinationValueType));
                        return;
                    }
                    destinationValueType = GetEnumType(destinationValueType);
                }
                else if (sourceType.GetTypeInfo().IsEnum)
                    sourceType = GetEnumType(sourceType);

                if (destinationValueType == sourceType)
                    EmitNullableTypeInstance(iL, destinationType, value);
                else
                {
                    var mappingKey = GetMappingKey(sourceType, destinationValueType);
                    if (primitiveTypeMappings.ContainsKey(mappingKey))
                    {
                        EmitNullableTypeInstance(iL, destinationType);
                        iL.Emit(OpCodes.Call, primitiveTypeMappings[mappingKey]);
                        iL.Emit(OpCodes.Stfld, value);
                        iL.Emit(OpCodes.Ldloc_0);
                        return;
                    }
                    EmitStructInit(iL, destinationType);
                    iL.Emit(OpCodes.Ldloc_0);
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void EmitNullableToPrimitiveMapping(ILGenerator iL, Type destinationType, FieldInfo hasValue, FieldInfo value)
        {
            iL.Emit(OpCodes.Ldarg_0);
            iL.Emit(OpCodes.Ldfld, hasValue);
            var label = iL.DefineLabel();
            iL.Emit(OpCodes.Brtrue_S, label);
            iL.Emit(OpCodes.Ldloca_S, 0);
            iL.Emit(OpCodes.Initobj, destinationType);
            iL.Emit(OpCodes.Ldloc_0);
            iL.Emit(OpCodes.Ret);
            iL.MarkLabel(label);
            iL.Emit(OpCodes.Ldarg_0);
            iL.Emit(OpCodes.Ldfld, value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void EmitNullableToPrimitiveMapping(ILGenerator iL, Type sourceType, Type destinationType)
        {
            var hasValue = GetFieldByExactName(sourceType, "hasValue");
            var value = GetFieldByExactName(sourceType, "value");
            sourceType = value.FieldType;
            iL.DeclareLocal(destinationType);
            if (sourceType == destinationType)
            {
                EmitNullableToPrimitiveMapping(iL, destinationType, hasValue, value);
            }
            else
            {
                var mappingKey = GetMappingKey(sourceType, destinationType);
                if (primitiveTypeMappings.ContainsKey(mappingKey))
                {
                    EmitNullableToPrimitiveMapping(iL, destinationType, hasValue, value);
                    iL.Emit(OpCodes.Call, primitiveTypeMappings[mappingKey]);
                }
                else if (destinationType.GetTypeInfo().IsEnum && sourceType.GetTypeInfo().IsEnum)
                {
                    EmitNullableToPrimitiveMapping(iL, destinationType, hasValue, value);
                    EmitEnumMapping(iL, sourceType, destinationType);
                }
                else if (destinationType.GetTypeInfo().IsValueType)
                {
                    iL.Emit(OpCodes.Ldloca_S, 0);
                    iL.Emit(OpCodes.Initobj, destinationType);
                    iL.Emit(OpCodes.Ldloc_0);
                }
                else
                    iL.Emit(OpCodes.Ldnull);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool EmitInitObject(ILGenerator iL, Type destinationType, bool isClass)
        {
            if (isClass)
            {
                var ctor = destinationType.GetTypeInfo().GetConstructor(Type.EmptyTypes);
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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static int MapEnum(int source, long mappingKey)
        {
            var mapping = enumMapping[mappingKey];
            return mapping.ContainsKey(source) ? mapping[source] : 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static int? MapNullableEnum(int source, long mappingKey)
        {
            var mapping = enumMapping[mappingKey];
            return mapping.ContainsKey(source) ? mapping[source] : (int?)null;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static TDestination MapComplexEnum<TSource, TDestination>(TSource source)
            where TSource : struct
            where TDestination : struct
        {
            return Enum.TryParse<TDestination>(source.ToString(), true, out var result) ? result : default(TDestination);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static TDestination? MapNullableComplexEnum<TSource, TDestination>(TSource source)
            where TSource : struct
            where TDestination : struct
        {
            return Enum.TryParse<TDestination>(source.ToString(), true, out var result) ? result : (TDestination?)null;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static T MapStringToEnum<T>(string source) where T : struct
        {
            return Enum.TryParse<T>(source, true, out var result) ? result : default(T);
        }

        private static TDestination[] MapArray<TSource, TDestination>(TSource[] sourceList)
        {
            var len = sourceList.Length;
            var destinationList = new TDestination[len];
            if (len > 0)
            {
                var mapElementFunction = GetMapping<TSource, TDestination>();
                for (var i = 0; i < len; i++)
                {
                    var sourceItem = sourceList[i];
                    if (sourceItem != null)
                        destinationList[i] = mapElementFunction(sourceItem);
                }
            }
            return destinationList;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static TDestination MapClass<TSource, TDestination>(TSource source)
        {
            return GetMapping<TSource, TDestination>()(source);
        }

        private static TDestination[] MapListToArray<TSource, TDestination>(IList<TSource> sourceList)
        {
            var len = sourceList.Count;
            var destinationList = new TDestination[len];
            if (len > 0)
            {
                var mapElementFunction = GetMapping<TSource, TDestination>(); 
                for (var i = 0; i < len; i++)
                {
                    var sourceItem = sourceList[i];
                    if (sourceItem != null)
                        destinationList[i] = mapElementFunction(sourceItem);
                }
            }
            return destinationList;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static TDestination[] MapItemToArray<TSource, TDestination>(TSource source)
        {
            return new[]
            {
                GetMapping<TSource, TDestination>()(source)
            };
        }

        private static List<TDestination> MapArrayToList<TSource, TDestination>(TSource[] sourceList)
        {
            var len = sourceList.Length;
            var destinationList = new List<TDestination>(len);
            if (len > 0)
            {
                var mapElementFunction = GetMapping<TSource, TDestination>();

                for (var i = 0; i < len; i++)
                {
                    var sourceItem = sourceList[i];
                    destinationList.Add(sourceItem != null ? mapElementFunction(sourceItem) : default(TDestination));
                }
            }
            return destinationList;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static TDestination MapArrayToItem<TSource, TDestination>(TSource[] sourceList)
        {
            if (sourceList == null || sourceList.Length == 0 || sourceList[0] == null)
                return default(TDestination);
            return GetMapping<TSource, TDestination>()(sourceList[0]);
        }

        private static TDestination[] MapICollectionToArray<TSource, TDestination>(ICollection<TSource> sourceList)
        {
            var len = sourceList.Count;
            var destinationList = new TDestination[len];
            if (len > 0)
            {
                var mapElementFunction = GetMapping<TSource, TDestination>();
                int i = 0;
                foreach(var item in sourceList)
                {
                    if (item != null)
                        destinationList[i] =mapElementFunction(item);
                    i++;
                }
            }
            return destinationList;
        }
        private static List<TDestination> MapIEnumerableToList<TSource, TDestination>(IEnumerable<TSource> sourceList)
        {
            var destinationList = new List<TDestination>();
            var mapElementFunction = GetMapping<TSource, TDestination>();
            foreach (var item in sourceList)
            {
                destinationList.Add(item == null ? default(TDestination) : mapElementFunction(item));
            }
            return destinationList;
        }

        private static TDestination[] MapIEnumerableToArray<TSource, TDestination>(IEnumerable<TSource> sourceList)
        {
            var collection = sourceList as ICollection<TSource>;
            if (collection != null)
                return MapICollectionToArray<TSource,TDestination>(collection);
            var destinationList = MapIEnumerableToList<TSource,TDestination>(sourceList);
            var array = new TDestination[destinationList.Count];
            destinationList.CopyTo(array);
            return array;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static TDestination MapIEnumerableToItem<TSource, TDestination>(IEnumerable<TSource> sourceList)
        {
            foreach (var item in sourceList)
            {
                if (item == null) return default(TDestination);
                return GetMapping<TSource, TDestination>()(item);
            }
            return default(TDestination);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static TDestination CallLambda<TSource, TDestination>(TSource source)
        {
            return ((Func<TSource, TDestination>)typeMapping[GetMappingKey(typeof(TSource), typeof(TDestination))])(source);            
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        TDestination IMapper.Map<TSource, TDestination>(TSource from)
        {
            return Map<TSource, TDestination>(from);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        TDestination IMapper.Map<TDestination>(object from)
        {
            return Map<TDestination>(from);
        }
    }
}