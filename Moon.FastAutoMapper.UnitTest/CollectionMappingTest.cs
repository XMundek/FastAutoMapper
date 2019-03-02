using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Moon.FastAutoMapper.UnitTest
{
    [TestClass]
    public class CollectionMappingTest:BaseMappingTest
    {
        
        [TestMethod]
        public void TestSourcePointArrayToDestinationPointMapping()
        {
            TestMapping<SourcePoint[], DestinationStructPoint[]>(
               new[] { new SourcePoint() { x = 109, y = "209", a = 31 } });
        }
        [TestMethod]
        public void TestSourcePointArrayToDestinationPointListMapping()
        {
            TestMapping<SourcePoint[], List<DestinationStructPoint>>(
                new[]
                {
                    new SourcePoint() {x = 109, y = "209", a = 31},
                    null,
                    new SourcePoint() {x = 101, y = "212", a = 33}
                },
                new List<DestinationStructPoint> {
                    new DestinationStructPoint() { x = 109, y = 209, a = 31 },
                    new DestinationStructPoint(),
                    new DestinationStructPoint() { x = 101, y = 212, a = 33 }
                 });
        }
        [TestMethod]
        public void TestSourcePointArrayToDestinationPoint()
        {
            TestMapping<SourcePoint[], DestinationPoint>(
                new[] { new SourcePoint() { x = 109, y = "209", a = 31 } },
                new DestinationPoint() { x = 109, y = 209, a = 31 });
            TestMapping<SourcePoint[], DestinationPoint>(
                new SourcePoint[] {null},
                (DestinationPoint)null );
            TestMapping<SourcePoint[], DestinationPoint>(
                new SourcePoint[0],
                (DestinationPoint)null);
        }

        [TestMethod]
        public void TestSourcePointArrayToDestinationStructPointArrayMapping()
        {
            TestMapping<SourcePoint[], DestinationStructPoint[]>(
                new []
                {
                    new SourcePoint() { x = 109, y = "209", a = 31 },
                    null,
                    new SourcePoint() { x = 101, y = "212", a = 33 }
                },
                new [] {
                    new DestinationStructPoint() { x = 109, y = 209, a = 31 },
                    new DestinationStructPoint(),
                    new DestinationStructPoint() { x = 101, y = 212, a = 33 }
                });
        }
        [TestMethod]
        public void TestSourcePointListToDestinationStructPointArrayMapping()
        {
            TestMapping<List<SourcePoint>, DestinationStructPoint[]>(
                new List<SourcePoint>()
                {
                    new SourcePoint() { x = 109, y = "209", a = 31 },
                    null,
                    new SourcePoint() { x = 101, y = "212", a = 33 }
                },
                new [] {
                    new DestinationStructPoint() { x = 109, y = 209, a = 31 },
                    new DestinationStructPoint(),
                    new DestinationStructPoint() { x = 101, y = 212, a = 33 }
                });
        }
        [TestMethod]
        public void TestSourcePointListToDestinationPointListMapping()
        {
            TestMapping<List<SourcePoint>, List<DestinationPoint>>(
                new List<SourcePoint>
                {
                    new SourcePoint() { x = 109, y = "209", a = 31, k=0 },
                    null,
                    new SourcePoint() { x = 101, y = "212", a = 33,k=0 }
                },
                new List<DestinationPoint>
                {
                    new DestinationPoint() { x = 109, y = 209, a = 31 },
                    null,
                    new DestinationPoint() { x = 101, y = 212, a = 33 }
                }

                );
        }
        [TestMethod]
        public void TestStringArrayToLongArrayMapping()
        {
            TestMapping<string[], long[]>(
                new[] { "10", "2022", null, "44" },
                new[] { 10, 2022, 0, 44 });
        }
        [TestMethod]
        public void TestIntArrayToStringArrayMapping()
        {
            TestMapping<int[], string[]>(new[] { 233, 33, 35, 5563355 });
            TestMapping<int[], string[]>(null);            
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
            TestMapping<long[], object[]>(new long[] { 2, 234234, 3344, -122 });
        }
        [TestMethod]
        public void TestLongArrayToLongMapping()
        {
            TestMapping<long[], long>(new long[] { 2, 234234, 3344, -122 }, 2);
        }
        [TestMethod]
        public void TestLongToIntArrayMapping()
        {
            TestMapping<long, int[]>(3L, new int[] { 3 });
        }
        [TestMethod]
        public void TestLongToLongArrayMapping()
        {
            TestMapping<long, long[]>(32342342342342342, new long[] { 32342342342342342 });
        }

        [TestMethod]
        public void TestClassWithIntArrayToClassWithStringArrayMapping()
        {
            TestMapping<ClassWithIntArray, ClassWithStringArray>(new ClassWithIntArray());
            TestMapping<ClassWithIntArray, ClassWithStringArray>(
                new ClassWithIntArray(){list = new []{1,53,-2,223}}); ;
        }

        [TestMethod]
        public void TestDictionarySourcePointToDictionaryDestinationPointMapping()
        {
            TestMapping<Dictionary<string, SourcePoint>, Dictionary<int, DestinationPoint>>(
                new Dictionary<string, SourcePoint>()
                {
                    {"1",new SourcePoint() {x=1,k = SimpleEnumSource.b,a=2,y="10" }},
                    {"2",new SourcePoint() {x=2,k=SimpleEnumSource.c,a="4",y="XX"}}
                },
                new Dictionary<int, DestinationPoint>()
                {
                    {1,new DestinationPoint() {x=1,a=2,y=10,k=(long)SimpleEnumSource.b}},
                    {2,new DestinationPoint() {x=2,a=4,y=0,k=(long)SimpleEnumSource.c}}
                });
        }
    }
}
