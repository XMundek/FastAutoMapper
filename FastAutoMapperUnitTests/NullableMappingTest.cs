using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Moon.FastAutoMapper.UnitTest
{
    [TestClass]
    public class NullableMappingTest:BaseMappingTest
    {        
        [TestMethod]
        public void TestNullableInt32ToLongMapping()
        {
            TestMapping<int?, long>(30);
            TestMapping<int?, long>(null, 0L);
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
            TestMapping<int?, int>(null, 0);
        }

        [TestMethod]
        public void TestNullableInt32ToStringMapping()
        {
            TestMapping<int?, string>(30,(object)"30");
            TestMapping<int?, string>(null, null);
            ;
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
            TestMapping<DateTime?, DateTime>(null,DateTime.MinValue);
        }
        [TestMethod]
        public void TestNullableTimeSpanToTimeSpanMapping()
        {
            TestMapping<TimeSpan?, TimeSpan>(new TimeSpan(10,20,2,1));
            TestMapping<TimeSpan?, TimeSpan>(null, TimeSpan.Zero);
        }
        [TestMethod]
        public void TestNullableDoubleToDoubleMapping()
        {
            TestMapping<double?, double>(10.35);
            TestMapping<double?, double>(null, 0.0);
        }
        [TestMethod]
        public void TestDoubleToNullableDoubleMapping()
        {
            TestMapping<double, double?>(10.35);
        }
        [TestMethod]
        public void TestNullableDecimalToDecimalMapping()
        {
            TestMapping<decimal?, decimal>(10.35M);
            TestMapping<decimal?, decimal>(null, 0M);
        }

        [TestMethod]
        public void TestNullableDecimalToLongMapping()
        {
            TestMapping<decimal?, long>(10.56M,11);
            TestMapping<decimal?, long>(null, 0);
        }

        [TestMethod]
        public void TestDecimalToNullableDecimalMapping()
        {
            TestMapping<decimal, decimal?>(10.35M);
        }

        [TestMethod]
        public void TestEnumToNullableEnumMapping()
        {
            TestMapping<SimpleEnumSource, SimpleEnumDestination?>(SimpleEnumSource.c, SimpleEnumDestination.c);
            TestMapping<SimpleEnumSource, SimpleEnumSource?>(SimpleEnumSource.x, null);
        }

        [TestMethod]
        public void TestEnumLongToNullableEnumMapping()
        {
            TestMapping<SimpleEnumLongSource, SimpleEnumSource?>(SimpleEnumLongSource.a, SimpleEnumSource.a);
            TestMapping<SimpleEnumLongSource, SimpleEnumSource?>(SimpleEnumLongSource.g, (SimpleEnumSource?) null);
        }

        [TestMethod]
        public void TestNullableEnumToEnumMapping()
        {
            TestMapping<SimpleEnumSource?, SimpleEnumDestination>(SimpleEnumSource.c, SimpleEnumDestination.c);
            TestMapping<SimpleEnumSource?, SimpleEnumDestination>((SimpleEnumSource?)null, (SimpleEnumDestination)0);
        }
        [TestMethod]
        public void TestNullableIntToSimpleDestinationClassMapping()
        {
            TestMapping<int?, SimpleDestinationClass>(20,(object)null);
            TestMapping<int?, SimpleDestinationClass>(null);
        }

        [TestMethod]
        public void TestNullableIntToSimpleDestinationStructMapping()
        {
            TestMapping<int?, SimpleDestinationStruct>(20, new SimpleDestinationStruct());
            TestMapping<int?, SimpleDestinationStruct>(null,new SimpleDestinationStruct());
        }

        [TestMethod]
        public void TestNullableEnumArrayMapping()
        {
            var source = new []
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
        public void TestNullableEnumArrayToEnumArrayMapping()
        {
            var source = new SimpleEnumSource?[] {SimpleEnumSource.a, SimpleEnumSource.c, SimpleEnumSource.d,null};
            var expectedResult = new [] { SimpleEnumDestination.a, SimpleEnumDestination.c, SimpleEnumDestination.d, SimpleEnumDestination.b };
            TestMapping<SimpleEnumSource?[], SimpleEnumDestination[]>(source,expectedResult);            
        }

        [TestMethod]
        public void TestEnumArrayToNullableEnumArrayMapping()
        {
            var source = new [] { SimpleEnumSource.a, SimpleEnumSource.c, SimpleEnumSource.d, SimpleEnumSource.x };
            var expectedResult = new SimpleEnumDestination?[] { SimpleEnumDestination.a, SimpleEnumDestination.c, SimpleEnumDestination.d, null };
            TestMapping<SimpleEnumSource[], SimpleEnumDestination?[]>(source,expectedResult);
        }

        [TestMethod]
        public void TestIntArrayToNullableEnumArrayMapping()
        {
            var source = new[] {1,3,10};
            var expectedResult = new SimpleEnumDestination?[] { SimpleEnumDestination.c, SimpleEnumDestination.a, (SimpleEnumDestination)10};
            TestMapping<int[], SimpleEnumDestination?[]>(source, expectedResult);
        }

        [TestMethod]
        public void TestEnumArrayToNullableIntArrayMapping()
        {
            var source = new[] { SimpleEnumSource.a, SimpleEnumSource.b };
            var expectedResult = new [] {(int) SimpleEnumSource.a, (int)SimpleEnumSource.b };
            TestMapping<SimpleEnumSource[], int?[]>(source, expectedResult);
        }

        [TestMethod]
        public void TestStructArrayToNullableIntArrayMapping()
        {
            var source = new[] { new SimpleSourceStruct(), new SimpleSourceStruct() };
            var expectedResult = new int?[] {null, null};
            TestMapping<SimpleSourceStruct[], int?[]>(source, expectedResult);
        }
    }
}
