using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moon.FastAutoMapper.UnitTest.Utils;

namespace Moon.FastAutoMapper.UnitTest
{
    public class BaseMappingTest
    {
        protected void TestMapping<TSource, TDestination>(TSource source,
            [CallerMemberName]
            string caller=""
            )
        {
            TestMapping<TSource, TDestination>(source, source, false, caller);
        }

        protected void TestMapping<TSource, TDestination>(
            TSource source, object expectedResult,bool objectMode=false,
            [CallerMemberName] string caller = ""
        )
        {
            try
            {
                 var result = objectMode 
                    ? Mapper.Map<TDestination>(source) 
                    : Mapper.Map<TSource, TDestination>(source);
                var differences = expectedResult.GetObjectDifferences(result);
                var testResult = "Test " + caller + " " + (differences.Count > 0 ? "failed" : "success") + ":"
                                 + GetObjectInfo(typeof(TSource), source) + "=" +
                                 GetObjectInfo(typeof(TDestination), result);
                Debug.WriteLine(testResult);

                if (differences.Count > 0)
                {
                    Debug.WriteLine($"Test {caller} differences:" );
                    foreach (var difference in differences)
                        Debug.WriteLine(difference);
                    Debug.WriteLine($"End of test {caller} differences.");
                    Assert.Fail(testResult);

                }
            }
            catch (Exception ex)
            {
                if (ex is AssertFailedException) throw; 
                Assert.Fail($"Test {caller} failed :{ GetObjectInfo(typeof(TSource), source)}={GetObjectInfo(ex.GetType(), ex)}");
            }
        }    

        private static string GetObjectInfo(Type type, object source)
        {
            return $"{type.FullName}({source?.ToString() ?? "null" })";
        }

        protected static Guid ToGuid(byte[] arr)
        {
            var guidArray = new byte[16];
            arr.CopyTo(guidArray,0);
            return new Guid(guidArray);
        }
    }
}
