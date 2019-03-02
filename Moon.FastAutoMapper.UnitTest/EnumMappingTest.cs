using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Moon.FastAutoMapper.UnitTest
{
    [TestClass]
    public class EnumMappingTest:BaseMappingTest
    {
        
        [TestMethod]
        public void TestEnumArrayMapping()
        {
            var source = new []
            {
                new [] {SimpleEnumSource.a, SimpleEnumSource.c, SimpleEnumSource.d},
                new [] {SimpleEnumSource.a, SimpleEnumSource.d},
                new SimpleEnumSource[0],
                null,
                new [] {SimpleEnumSource.a, SimpleEnumSource.d}
            };
            TestMapping<SimpleEnumSource[][], SimpleEnumDestination[][]>(source);
        }

        [TestMethod]
        public void TestEnumSourceToEnumDestinationMapping()
        {
            TestMapping<SimpleEnumSource, SimpleEnumDestination>(SimpleEnumSource.d);
            TestMapping<SimpleEnumSource, SimpleEnumDestination>(SimpleEnumSource.t,default(SimpleEnumDestination));
        }

        [TestMethod]
        public void TestEnumLongSourceToEnumIntDestinationMapping()
        {
            TestMapping<SimpleEnumLongSource, SimpleEnumDestination>(SimpleEnumLongSource.a);
            TestMapping<SimpleEnumLongSource, SimpleEnumDestination>(SimpleEnumLongSource.t,default(SimpleEnumDestination));
        }

        [TestMethod]
        public void TestNullableEnumLongSourceToEnumIntDestinationMapping()
        {
            TestMapping<SimpleEnumLongSource?, SimpleEnumDestination>(null,default(SimpleEnumDestination));
            TestMapping<SimpleEnumLongSource?, SimpleEnumDestination>(SimpleEnumLongSource.a);
        }
        [TestMethod]
        public void TestEnumLongSourceToNullableEnumIntDestinationMapping()
        {
            TestMapping<SimpleEnumLongSource, SimpleEnumDestination?>(SimpleEnumLongSource.a);
        }
        [TestMethod]
        public void TestNullableEnumLongSourceToNullableEnumIntDestinationMapping()
        {
            TestMapping<SimpleEnumLongSource?, SimpleEnumDestination?>(null);
            TestMapping<SimpleEnumLongSource?, SimpleEnumDestination?>(SimpleEnumLongSource.a);
        }

        [TestMethod]
        public void TestEnumLongSourceToLongMapping()
        {
            TestMapping<SimpleEnumLongSource, long>(SimpleEnumLongSource.a, (long)SimpleEnumLongSource.a);
        }
        [TestMethod]
        public void TestEnumLongSourceToIntMapping()
        {
            TestMapping<SimpleEnumLongSource, int>(SimpleEnumLongSource.a, 0);
            TestMapping<SimpleEnumLongSource, int>(SimpleEnumLongSource.g, 2);

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
                new[] { SimpleEnumSource.d, SimpleEnumSource.c });
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
                new SimpleEnumSource[] { SimpleEnumSource.d, SimpleEnumSource.a });
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
        public void TestEnumToShortMapping()
        {
            TestMapping<SimpleEnumSource, short>(SimpleEnumSource.a, (short)SimpleEnumSource.a);
        }
        [TestMethod]
        public void TestEnumToByteMapping()
        {
            TestMapping<SimpleEnumSource, byte>(SimpleEnumSource.a, (byte)SimpleEnumSource.a);
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
        public void TestDoubleToEnumMapping()
        {
            TestMapping<double, SimpleEnumSource>(0.1, SimpleEnumSource.x);
            TestMapping<double, SimpleEnumSource>(double.MaxValue, SimpleEnumSource.x);
            TestMapping<double, SimpleEnumSource>(1, SimpleEnumSource.a);
            TestMapping<double, SimpleEnumSource>(1.2, SimpleEnumSource.a);
            TestMapping<double, SimpleEnumSource>(1.7, SimpleEnumSource.b);
        }
        [TestMethod]
        public void TestBoolToEnumMapping()
        {
            TestMapping<bool, SimpleEnumSource>(true, SimpleEnumSource.a);
            TestMapping<bool, SimpleEnumSource>(false, SimpleEnumSource.x);
        }

    }
}
