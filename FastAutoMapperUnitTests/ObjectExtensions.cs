using System;
using System.Collections.Generic;
using System.Reflection;

namespace Moon.Utils
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
           return t.IsEnum || t.IsPrimitive || (t == typeof(string)) ;
        }
        private static void GetObjectDifferences(object a, object b, string propName, List<string> differences,
            int level)
        {
            if (a == null && b==null)
                return;
            if (b == null)
                differences.Add(propName + " is null");

            else if (a == null)
                differences.Add(propName + " is not null");

            else if (a != b)
            {
                var aType = a.GetType();
                var bType = b.GetType();

                if (IsSimpleType(aType) || IsSimpleType(bType))
                {
                    var eqStatus = (aType == bType)
                        ? a.Equals(b)
                        : a.ToString() == b.ToString();
                    if (!eqStatus)
                        differences.Add(string.Format("{0}:{1}<>{2}", propName, a, b));
                }
                else
                {
                    var listA = a as System.Collections.IList;
                    var listB = b as System.Collections.IList;
                    if (listA != null)
                    {
                        if (listB == null)
                        {
                            differences.Add(propName + " is not list");
                        }
                        else
                        {
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
                    }
                    else if (level < MaxCompareLevel)
                    {
                        var fieldsA =
                            aType.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                        foreach (var pA in fieldsA)
                        {

                            var pB = bType.GetField(pA.Name);
                            if (pB != null)
                                GetObjectDifferences(pA.GetValue(a), pB.GetValue(b), propName + "." + pA.Name,
                                    differences, level + 1);
                        }
                    }
                }
            }
        }
    }
}