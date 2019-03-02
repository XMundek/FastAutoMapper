using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Moon.FastAutoMapper.UnitTest
{
    [TestClass]
    public class PrimitiveToUShortMappingTest : BaseMappingTest
    {
        [TestMethod]
        public void TestUShortToUShortMapping()
        {
            TestMapping<ushort, ushort>(2);
        }

        [TestMethod]
        public void TestIntToUShortMapping()
        {
            TestMapping<int, ushort>(int.MinValue,0);
            TestMapping<int, ushort>(int.MaxValue,0);
            TestMapping<int, ushort>(ushort.MaxValue + 1,0);
            TestMapping<int, ushort>(ushort.MaxValue - 1);
            TestMapping<int, ushort>(0);
            TestMapping<int, ushort>(1);
            TestMapping<int, ushort>(-1,0);
            TestMapping<int, ushort>(2131);
        }

        [TestMethod]
        public void TestShortToUShortMapping()
        {
            TestMapping<short, ushort>(short.MinValue,0);
            TestMapping<short, ushort>(short.MaxValue);
            TestMapping<short, ushort>(short.MaxValue - 1);
            TestMapping<short, ushort>(0);
            TestMapping<short, ushort>(1);
            TestMapping<short, ushort>(-1,0);
            TestMapping<short, ushort>(21312);
        }

        [TestMethod]
        public void TestSByteToUShortMapping()
        {
            TestMapping<sbyte, ushort>(sbyte.MinValue,0);
            TestMapping<sbyte, ushort>(sbyte.MaxValue);
            TestMapping<sbyte, ushort>(sbyte.MinValue + 1,0);
            TestMapping<sbyte, ushort>(sbyte.MaxValue - 1);
            TestMapping<sbyte, ushort>(0);
            TestMapping<sbyte, ushort>(1);
            TestMapping<sbyte, ushort>(-1,0);
            TestMapping<sbyte, ushort>(21);
        }

        [TestMethod]
        public void TestUIntToUShortMapping()
        {
            TestMapping<uint, ushort>(uint.MaxValue,0);
            TestMapping<uint, ushort>(ushort.MaxValue);
            TestMapping<uint, ushort>(0);
            TestMapping<uint, ushort>(1);
            TestMapping<uint, ushort>(2131);
        }

        [TestMethod]
        public void TestULongToUShortMapping()
        {
            TestMapping<ulong, ushort>(ulong.MaxValue,0);
            TestMapping<ulong, ushort>(ushort.MaxValue);
            TestMapping<ulong, ushort>(0);
            TestMapping<ulong, ushort>(1);
            TestMapping<ulong, ushort>(21312);
        }

        [TestMethod]
        public void TestByteToUShortMapping()
        {
            TestMapping<byte, ushort>(byte.MaxValue);
            TestMapping<byte, ushort>(byte.MaxValue - 1);
            TestMapping<byte, ushort>(0);
            TestMapping<byte, ushort>(1);
            TestMapping<byte, ushort>(213);
        }

        [TestMethod]
        public void TestLongToUShortMapping()
        {
            TestMapping<long, ushort>(long.MaxValue,0);
            TestMapping<long, ushort>(long.MinValue,0);
            TestMapping<long, ushort>(ushort.MaxValue);
            TestMapping<long, ushort>(0);
            TestMapping<long, ushort>(-1, 0);
            TestMapping<long, ushort>(21312);
            TestMapping<long, ushort>(-2131243232,0);
        }

        [TestMethod]
        public void TestBoolToUShortMapping()
        {
            TestMapping<bool, ushort>(true,1);
            TestMapping<bool, ushort>(false, 0);
        }

        [TestMethod]
        public void TestCharToUShortMapping()
        {
            TestMapping<char, ushort>((char)0,0);
            TestMapping<char, ushort>('A', (ushort)'A');
        }

        [TestMethod]
        public void TestDoubleToUShortMapping()
        {
            TestMapping<double, ushort>(double.MaxValue, 0);
            TestMapping<double, ushort>(double.MinValue, 0);
            TestMapping<double, ushort>(ushort.MaxValue, ushort.MaxValue);
            TestMapping<double, ushort>(0);
            TestMapping<double, ushort>(0.2, 0);
            TestMapping<double, ushort>(0.4999, 0);
            TestMapping<double, ushort>(0.5,0);
            TestMapping<double, ushort>(0.5001, 1);
            TestMapping<double, ushort>(0.7, 1);
            TestMapping<double, ushort>(1);
            TestMapping<double, ushort>(1.5,2);
            TestMapping<double, ushort>(-1,0);
            TestMapping<double, ushort>(-1.5, 0);
            TestMapping<double, ushort>(21312.244, 21312);
        }

        [TestMethod]
        public void TestDecimalToUShortMapping()
        {
            TestMapping<decimal, ushort>(decimal.MinValue, 0);
            TestMapping<decimal, ushort>(decimal.MaxValue, 0);
            TestMapping<decimal, ushort>(ushort.MaxValue);
            TestMapping<decimal, ushort>(ushort.MaxValue - 1);
            TestMapping<decimal, ushort>(0);
            TestMapping<decimal, ushort>(0.2M, 0);
            TestMapping<decimal, ushort>(0.4999M, 0);
            TestMapping<decimal, ushort>(0.5M, 0);
            TestMapping<decimal, ushort>(0.5001M, 1);
            TestMapping<decimal, ushort>(0.7M, 1);
            TestMapping<decimal, ushort>(1);
            TestMapping<decimal, ushort>(1.5M, 2);
            TestMapping<decimal, ushort>(-1,0);
            TestMapping<decimal, ushort>(-1.5M, 0);
            TestMapping<decimal, ushort>(2131.244M, 2131);
        }

        [TestMethod]       
        public void TestFloatToUShortMapping()
        {
            TestMapping<float, ushort>(float.MinValue, 0);
            TestMapping<float, ushort>(float.MaxValue, 0);
            TestMapping<float, ushort>(ushort.MaxValue, ushort.MaxValue);
            TestMapping<float, ushort>(0,0);
            TestMapping<float, ushort>(0.2f, 0);
            TestMapping<float, ushort>(0.4999f, 0);
            TestMapping<float, ushort>(0.5f, 0);
            TestMapping<float, ushort>(0.5001f, 1);
            TestMapping<float, ushort>(0.7f, 1);
            TestMapping<float, ushort>(1);
            TestMapping<float, ushort>(1.5f, 2);
            TestMapping<float, ushort>(-1,0);
            TestMapping<float, ushort>(-1.5f,0);
            TestMapping<float, ushort>(2137.24f,  2137);
        }

        [TestMethod]
        public void TestDateTimeToUShortMapping()
        {
            TestMapping<DateTime, ushort>(new DateTime(1001), 1001);
            TestMapping<DateTime, ushort>(DateTime.MaxValue, 0);
            TestMapping<DateTime, ushort>(DateTime.MinValue, 0);
        }

        [TestMethod]
        public void TestStringToUShortMapping()
        {
            TestMapping<string, ushort>("-20", 0);
            TestMapping<string, ushort>("21.1", 0);
            TestMapping<string, ushort>("1.2e2", 0);
            TestMapping<string, ushort>("2322", 2322);
            TestMapping<string, ushort>(null, 0);
            TestMapping<string, ushort>("0", 0);
            TestMapping<string, ushort>(" ", 0);
            TestMapping<string, ushort>("sdfsdf", 0);
        }

        [TestMethod]
        public void TestObjectToUShortMapping()
        {
            TestMapping<object, ushort>("20", 20);
            TestMapping<object, ushort>(21, 21);
            TestMapping<object, ushort>(ushort.MaxValue);
            TestMapping<object, ushort>(1.2e2, 120);
            TestMapping<object, ushort>(SimpleEnumSource.a , (ushort)SimpleEnumSource.a);
            TestMapping<object, ushort>(new SimpleSourceClass() {a=10},0);
        }

        [TestMethod]
        public void TestTimeSpanToUShortMapping()
        {
            TestMapping<TimeSpan, ushort>(TimeSpan.MaxValue,0);
            TestMapping<TimeSpan, ushort>(TimeSpan.MinValue, 0);
            TestMapping<TimeSpan, ushort>(new TimeSpan(1001), 1001);
        }

        [TestMethod]
        public void TestGuidToUShortMapping()
        {
            TestMapping<Guid, ushort>(Guid.Empty,0);
            var guid = Guid.NewGuid();
            TestMapping<Guid, ushort>(guid, BitConverter.ToUInt16(guid.ToByteArray(), 0));
        }
    }
}
