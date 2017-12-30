using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using  Moon.Utils;
namespace Moon.FastAutoMapper.UnitTest
{
    [TestClass]
    public class SimpleUnitTest
    {
        private void TestMapping<TSource, TDestination>(TSource source, 
            [CallerMemberName]
            string caller=""
            )
        {
            TestMapping<TSource,TDestination>(source,source,caller);
        }

        private void TestMapping<TSource, TDestination>(TSource source, object expectedResult,
            [CallerMemberName]
            string caller=""
        )
        {
            var mapper = new Mapper();
            var result = mapper.Map<TSource, TDestination>(source);
            var differences = expectedResult.GetObjectDifferences(result);
            if (differences.Count > 0)
            {
                foreach (var difference in differences)
                {
                    System.Diagnostics.Debug.WriteLine($"Test {caller}:{difference}");
                }
                Assert.Fail($"Test {caller} failed");
            }
        }


        [TestMethod]
        public void TestEnumArrayMapping()
        {
            var source = new SimpleEnumSource[][]
            {
                new [] {SimpleEnumSource.a, SimpleEnumSource.c, SimpleEnumSource.d},
                new [] {SimpleEnumSource.a, SimpleEnumSource.d},
                new SimpleEnumSource[0],
                new [] {SimpleEnumSource.a, SimpleEnumSource.d}
            };
            TestMapping<SimpleEnumSource[][], SimpleEnumDestination[][]>(source);
        }

        [TestMethod]
        public void TestNullableEnumArrayMapping()
        {
            var source = new SimpleEnumSource?[][]
            {
                new SimpleEnumSource?[] {SimpleEnumSource.a, null, SimpleEnumSource.c, SimpleEnumSource.d},
                new SimpleEnumSource?[] {SimpleEnumSource.a, SimpleEnumSource.d},
                null,
                new SimpleEnumSource?[0],
                new SimpleEnumSource?[] {SimpleEnumSource.a, SimpleEnumSource.d}
            };
            TestMapping<SimpleEnumSource?[][], SimpleEnumDestination?[][]>(source);
        }

        [TestMethod]
        public void TestNullStringToDoubleMapping()
        {
            TestMapping<string, double>(null, 0.0);
        }

        [TestMethod]
        public void TestStructMapping()
        {
            TestMapping<SimpleSourceStruct, SimpleDestinationStruct>(
                new SimpleSourceStruct(){c= new SimpleSourceClass() { a=10}},
                new SimpleDestinationStruct(){c=new SimpleDestinationClass(){a=10}});
        }
        [TestMethod]
        public void TestEnumToStringMapping()
        {
            TestMapping<SimpleEnumSource, string>(SimpleEnumSource.d);
        }
        [TestMethod]
        public void TestEnumArrayToStringArrayMapping()
        {
            TestMapping<SimpleEnumSource[], string[]>(
                new [] { SimpleEnumSource.d, SimpleEnumSource.c });
        }
        [TestMethod]
        public void TestStringToEnumMapping()
        {
            TestMapping<string, SimpleEnumSource>("d");
        }
        [TestMethod]
        public void TestStringArrayToEnumArrayMapping()
        {
            TestMapping<string[], SimpleEnumSource[]>(
                new string[] { "d", "a" },
                new SimpleEnumSource[]{SimpleEnumSource.d,SimpleEnumSource.a} );
        }

        [TestMethod]
        public void TestSourcePointToStringMapping()
        {
            TestMapping<SourcePoint,string>(
                new SourcePoint() { x = 10, y = "A"},expectedResult: "x=10,y=A");
        }

        [TestMethod]
        public void TestSourcePointToDestinationPointMapping()
        {
            TestMapping<SourcePoint, DestinationPoint>(
                new SourcePoint() { x = 10, y = null, a = 3, k = SimpleEnumSource.c },
                new DestinationPoint() {x=10,y=0,a=3,k=(long)SimpleEnumSource.c }
                );
        }

        [TestMethod]
        public void TestDestinationPointToSourcePointMapping()
        {
            TestMapping<DestinationPoint,SourcePoint>(
                new DestinationPoint() { x = 10, y=20.0, a = 3 },
                new SourcePoint(){x=10, a=3,
                    y =20.0.ToString(CultureInfo.InvariantCulture)});
        }
        [TestMethod]
        public void TestSourceStructPointToDestinationStructPointMapping()
        {
            TestMapping<SourceStructPoint, DestinationStructPoint>(
                new SourceStructPoint() {
                    x = 109, y = "209", a = 31,
                    px = new SourcePoint()
                    {
                        a=20,k=SimpleEnumSource.c,x=20,y="10.1"
                    } 
                },
                new DestinationStructPoint()
                {
                    x = 109,
                    y = 209,
                    a = 31,
                    px = new DestinationPoint()
                    {
                        a = 20,
                        k = (int)SimpleEnumSource.c,
                        x = 20,
                        y = 10.1
                    }
                });
        }

        [TestMethod]
        public void TestSourceStructPointToObjectMapping()
        {
            TestMapping<SourceStructPoint, object>(
                new SourceStructPoint() { x = 109, y = "209", a = 31, px = new SourcePoint() });
        }

        [TestMethod]
        public void TestSourcePointToObjectMapping()
        {
            TestMapping<SourcePoint, object>(
                new SourcePoint() { x = 109, y = "209", a = 31});
        }

        [TestMethod]
        public void TestSourceStructPointToDestinationPointMapping()
        {
            TestMapping<SourceStructPoint, DestinationPoint>(
                new SourceStructPoint() { x = 109, y = "209", a = 31, px = new SourcePoint() });
        }
        [TestMethod]
        public void TestSourcePointToDestinationStructPointMapping()
        {
            TestMapping<SourcePoint, DestinationStructPoint>(
                new SourcePoint() { x = 109, y = "209", a = 31 });
        }
        [TestMethod]
        public void TestSourcePointToDestinationPointArrayMapping()
        {
            TestMapping<SourcePoint, DestinationStructPoint[]>(
                new SourcePoint() { x = 109, y = "209", a = 31 });
        }
        [TestMethod]
        public void TestSourcePointArrayToDestinationPointMapping()
        {
            TestMapping<SourcePoint[], DestinationStructPoint[]>(
               new []{ new SourcePoint() { x = 109, y = "209", a = 31 }});
        }
        [TestMethod]
        public void TestSourcePointArrayToDestinationPointListMapping()
        {
            TestMapping<SourcePoint[], List<DestinationStructPoint>>(
                new[]
                {
                    new SourcePoint() { x = 109, y = "209", a = 31 },
                    new SourcePoint() { x = 101, y = "212", a = 33 }
                });
        }
        [TestMethod]
        public void TestSourcePointListToDestinationStructPointArrayMapping()
        {
            TestMapping<List<SourcePoint>, DestinationStructPoint[]>(
                new List<SourcePoint>()
                {
                    new SourcePoint() { x = 109, y = "209", a = 31 },
                    new SourcePoint() { x = 101, y = "212", a = 33 }
                });
        }
        [TestMethod]
        public void TestSourcePointListToDestinationPointListMapping()
        {
            TestMapping<List<SourcePoint>, List<DestinationPoint>>(
                new List<SourcePoint>
                {
                    new SourcePoint() { x = 109, y = "209", a = 31, k=0 },
                    new SourcePoint() { x = 101, y = "212", a = 33,k=0 }
                },
                new List<DestinationPoint>
                {
                    new DestinationPoint() { x = 109, y = 209, a = 31 },
                    new DestinationPoint() { x = 101, y = 212, a = 33 }
                }

                );
        }
        [TestMethod]
        public void TestStringArrayToLongArrayMapping()
        {
            TestMapping<string[], long[]>(
                new [] { "10", "2022",null, "44"},
                new[] { 10, 2022, 0, 44 });        
        }
        [TestMethod]
        public void TestIntArrayToStringArrayMapping()
        {
            TestMapping<int[], string[]>(new[] {233,33,35,5563355});
        }
        [TestMethod]
        public void TestStringToDoubleMapping()
        {
            TestMapping<string,double>("2.223");
        }
        [TestMethod]
        public void TestDoubleToStringMapping()
        {
            TestMapping<double,string>(2.24);
        }
        [TestMethod]
        public void TestIntToObjectMapping()
        {
            TestMapping<int, object>(24);
        }
        [TestMethod]
        public void TestObjectToIntMapping()
        {
            TestMapping<object,int>(2);
        }
        [TestMethod]
        public void TestObjectArrayToLongArrayMapping()
        {
            TestMapping<object[], long[]>(
                new object[] { 2, 33.4, 22M, -1 },
                new long[] { 2, 33, 22, -1 }
                );
        }
        [TestMethod]
        public void TestLongArrayToObjectArrayMapping()
        {
            TestMapping<long[], object[]>(new long[] { 2, 234234,3344, -122 });
        }
        [TestMethod]
        public void TestLongArrayToLongMapping()
        {
            TestMapping<long[],long>(new long[] { 2, 234234, 3344, -122 },2);
        }
        [TestMethod]
        public void TestLongToIntArrayMapping()
        {
            TestMapping<long, int[]>(3L, new int[]{3});
        }
        [TestMethod]
        public void TestLongToLongArrayMapping()
        {
            TestMapping<long, long[]>(32342342342342342, new long[] { 32342342342342342 });
        }
        [TestMethod]
        public void TestEnumToLongMapping()
        {
            TestMapping<SimpleEnumSource, long>(SimpleEnumSource.a, (long)SimpleEnumSource.a);
        }
        [TestMethod]
        public void TestEnumToIntMapping()
        {
            TestMapping<SimpleEnumSource, int>(SimpleEnumSource.a, (int)SimpleEnumSource.a);
        }
        [TestMethod]
        public void TestIntToEnumMapping()
        {
            TestMapping<int, SimpleEnumSource>((int)SimpleEnumSource.a, SimpleEnumSource.a);
        }
        [TestMethod]
        public void TestLongToEnumMapping()
        {
            TestMapping<long, SimpleEnumSource>((long)SimpleEnumSource.a, SimpleEnumSource.a);
        }
        [TestMethod]
        public void TestDictionarySourcePointToDictionaryDestinationPointMapping()
        {
            TestMapping<Dictionary<string, SourcePoint>, Dictionary<int, DestinationPoint>>(
                new Dictionary<string, SourcePoint>()
                {
                    {"1",new SourcePoint() {x=1}},
                    {"2",new SourcePoint() {x=2}}
                });
        }
        [TestMethod]
        public void TestSourceClassToDestinationClassWithoutDefaultConstructorMapping()
        {
            TestMapping<SourceClassWithoutDefaultConstructor, DestinationClassWithoutContructor>(
                new SourceClassWithoutDefaultConstructor(1),(DestinationClassWithoutContructor) null);
        }
        [TestMethod]
        public void TestSourceClassToDestinationClassWithAutoPropertyMapping()
        {
            TestMapping<SourceClassWithAutoProperty, DestinationClassWithAutoProperty>(
                    new SourceClassWithAutoProperty()
                    {
                        x=10,
                        y=20.1,
                        z ="331.22"
                    }
                );
        }
        [TestMethod]
        public void TestNullableInt32ToLongMapping()
        {
            TestMapping<int?, long>(30);
            TestMapping<int?, long>((int?)null,0L);
        }
        [TestMethod]
        public void TestLongToNullableInt32Mapping()
        {
            TestMapping<long, int?>(30);
        }
        [TestMethod]
        public void TestNullableInt32ToInt32Mapping()
        {
            TestMapping<int?, int>(30);
            TestMapping<int?, int>((int?)null,0);
        }
        [TestMethod]
        public void TestInt32ToNullableInt32Mapping()
        {
            TestMapping<int, int?>(30);
        }
        [TestMethod]
        public void TestDatetimeToNullableDatetimeMapping()
        {
            TestMapping<DateTime, DateTime?>(DateTime.Now);
        }
        [TestMethod]
        public void TestNullableDatetimeToDatetimeMapping()
        {
            TestMapping<DateTime?, DateTime>(DateTime.Now);
        }
        [TestMethod]
        public void TestNullableDoubleToDoubleMapping()
        {
            TestMapping<double?, double>(10.35);
            TestMapping<double?, double>((double?)null,0.0);
        }
        [TestMethod]
        public void TestDoubleToNullableDoubleMapping()
        {
            TestMapping<double, double?>(10.35);
        }
        [TestMethod]
        public void TestEnumToNullableEnumMapping()
        {
            TestMapping<SimpleEnumSource, SimpleEnumDestination?>(SimpleEnumSource.c,SimpleEnumDestination.c);
        }
        [TestMethod]
        public void TestNullableEnumToEnumMapping()
        {
            TestMapping<SimpleEnumSource?, SimpleEnumDestination>(SimpleEnumSource.c, SimpleEnumDestination.c);
            TestMapping<SimpleEnumSource?, SimpleEnumDestination>((SimpleEnumSource?)null, (SimpleEnumDestination) 0);
        }

    }
}
