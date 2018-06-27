using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;

namespace Moon.FastAutoMapper.UnitTest.Utils
{
    public static class ObjectExtensions
    {
        private const int MaxCompareLevel = 30;

        public static List<string> GetObjectDifferences(this object a, object b)
        {
            var differences = new List<string>();
            GetObjectDifferences(a, b, "", differences, 0);
            return differences;
        }

        private static bool IsSimpleType(Type t)
        {
            return t.IsEnum || t.IsPrimitive || (t == typeof(string)
                                                 || t == typeof(decimal) || t == typeof(DateTime) ||
                                                 t == typeof(TimeSpan)
                                                 || t == typeof(Guid));
        }

        private static void GetListDifferences(IList listA, IList listB, string propName, List<string> differences,
            int level)
        {

            if (listA.Count != listB.Count)
            {
                differences.Add(string.Format("{0}.Count:{1}<>{2}", propName, listA.Count, listB.Count));
            }

            for (var i = 0; i < listA.Count; i++)
            {
                if (i < listB.Count)
                {
                    GetObjectDifferences(listA[i], listB[i], string.Format("{0}.[{1}]", propName, i),
                        differences, level + 1);
                }
                else
                {
                    differences.Add(string.Format("Item {0}.[{1}] not found in right hand side object",
                        propName, i));
                }
            }
        }

        private static void GetDictionaryDifferences(IDictionary listA, IDictionary listB, string propName,
            List<string> differences, int level)
        {
            var arrA = new object[listA.Count];
            var arrB = new object[listB.Count];
            listA.Keys.CopyTo(arrA, 0);
            listB.Keys.CopyTo(arrB, 0);
            GetListDifferences(arrA, arrB, propName + ".Keys", differences, level);
            listA.Values.CopyTo(arrA, 0);
            listB.Values.CopyTo(arrB, 0);
            GetListDifferences(arrA, arrB, propName + ".Values", differences, level);
        }

        private static void GetObjectDifferences(object a, object b, string propName, List<string> differences,
            int level)
        {
            if (a == null && b == null)
                return;

            if (b == null)
                differences.Add(propName + " is null");
            else if (a == null)
                differences.Add(propName + " is not null");
            else
            {
                var aType = a.GetType();
                var bType = b.GetType();

                if (IsSimpleType(aType) || IsSimpleType(bType))
                {
                    if (!(aType == bType && a.Equals(b) || a.ToString() == b.ToString()))
                        differences.Add(string.Format("{0}:{1}<>{2}", propName, a, b));
                }
                else
                {
                    var listA = a as IList;
                    var listB = b as IList;
                    if (listA != null)
                    {
                        if (listB == null)
                            differences.Add(propName + " is not list");
                        else
                            GetListDifferences(listA, listB, propName, differences, level + 1);
                    }
                    else
                    {
                        var dictA = a as IDictionary;
                        var dictB = b as IDictionary;
                        if (dictA != null)
                        {
                            if (dictB == null)
                                differences.Add(propName + " is not dictionary");
                            else
                                GetDictionaryDifferences(dictA, dictB, propName, differences, level + 1);
                        }
                        else if (level < MaxCompareLevel)
                        {
                            var fieldsA = GetFields(aType);
                            foreach (var pA in fieldsA)
                            {
                                var pB = GetField(bType, pA.Name);
                                if (pB !=null)
                                    GetObjectDifferences(pA.GetValue(a), pB.GetValue(b), propName + "." + pA.Name,
                                        differences, level + 1);
                            }
                        }
                    }
                }
            }
        }

        private static List<FieldInfo> GetFields(Type type)
        {

            var fieldList = new List<FieldInfo>();
            var bindingFlags = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public;
            while (type != typeof(object))
            {
                fieldList.AddRange(type.GetFields(bindingFlags));
                bindingFlags = BindingFlags.Instance | BindingFlags.NonPublic;
                type = type.BaseType;
            }
            return fieldList;
        }

        private static FieldInfo GetField(Type type, string fieldName)
        {
            var field = GetFieldByExactName(type, fieldName);
            if (field != null) return field;
            return GetFieldByExactName(type,
                (fieldName[0] == '<')
                ? fieldName.Substring(1, fieldName.IndexOf(">", 2) - 1)
                : $"<{fieldName}>k__BackingField");
        }

        private static FieldInfo GetFieldByExactName(Type type, string fieldName)
        {
            var bindingFlags = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.IgnoreCase;
            do
            {
                var field = type.GetField(fieldName, bindingFlags);
                if (field != null) return field;
                type = type.BaseType;
                bindingFlags = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.IgnoreCase;
            } while (type != typeof(object));
            return null;
        }


    }

}
