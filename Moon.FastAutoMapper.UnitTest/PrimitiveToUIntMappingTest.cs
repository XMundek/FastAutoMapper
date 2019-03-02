using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Moon.FastAutoMapper.UnitTest
{
    [TestClass]
    public class PrimitiveToUIntMappingTest : BaseMappingTest
    {
        [TestMethod]
        public void TestUIntToUIntMapping()
        {
            TestMapping<uint, uint>(2);
        }

        [TestMethod]
        public void TestIntToUIntMapping()
        {
            TestMapping<int, uint>(int.MinValue,0);
            TestMapping<int, uint>(int.MaxValue);
            TestMapping<int, uint>(int.MinValue + 1,0);
            TestMapping<int, uint>(int.MaxValue - 1);
            TestMapping<int, uint>(0);
            TestMapping<int, uint>(1);
            TestMapping<int, uint>(-1,0);
            TestMapping<int, uint>(21312332);
        }

        [TestMethod]
        public void TestShortToUIntMapping()
        {
            TestMapping<short, uint>(short.MinValue,0);
            TestMapping<short, uint>(short.MaxValue);
            TestMapping<short, uint>(short.MinValue + 1,0);
            TestMapping<short, uint>(short.MaxValue - 1);
            TestMapping<short, uint>(0);
            TestMapping<short, uint>(1);
            TestMapping<short, uint>(-1,0);
            TestMapping<short, uint>(21312);
        }

        [TestMethod]
        public void TestSByteToUIntMapping()
        {
            TestMapping<sbyte, uint>(sbyte.MinValue,0);
            TestMapping<sbyte, uint>(sbyte.MaxValue);
            TestMapping<sbyte, uint>(sbyte.MinValue + 1,0);
            TestMapping<sbyte, uint>(sbyte.MaxValue - 1);
            TestMapping<sbyte, uint>(0);
            TestMapping<sbyte, uint>(1);
            TestMapping<sbyte, uint>(-1,0);
            TestMapping<sbyte, uint>(21);
        }

        [TestMethod]
        public void TestULongToUIntMapping()
        {
            TestMapping<ulong,uint>(uint.MaxValue);
            TestMapping<ulong, uint>((ulong)uint.MaxValue+1,0);
            TestMapping<ulong, uint>(ulong.MaxValue,0);
            TestMapping<ulong, uint>(ulong.MaxValue-1, 0);
            TestMapping<ulong, uint>(0);
            TestMapping<ulong, uint>(1);
            TestMapping<ulong, uint>(2131243232);
        }

        [TestMethod]
        public void TestUShortToUIntMapping()
        {
            TestMapping<ushort, uint>(ushort.MaxValue);
            TestMapping<ushort, uint>(short.MaxValue - 1);
            TestMapping<ushort, uint>(0);
            TestMapping<ushort, uint>(1);
            TestMapping<ushort, uint>(21312);
        }

        [TestMethod]
        public void TestByteToUIntMapping()
        {
            TestMapping<byte, uint>(byte.MaxValue);
            TestMapping<byte, uint>(byte.MaxValue - 1);
            TestMapping<byte, uint>(0);
            TestMapping<byte, uint>(1);
            TestMapping<byte, uint>(213);
        }

        [TestMethod]
        public void TestLongUIntMapping()
        {
            TestMapping<long, uint>(long.MaxValue,0);
            TestMapping<long, uint>(long.MinValue,0);
            TestMapping<long, uint>(uint.MaxValue);
            TestMapping<long, uint>(uint.MaxValue-1);
            TestMapping<long, uint>((long)uint.MaxValue+1,0);
            TestMapping<long, uint>(0);
            TestMapping<long, uint>(-1, 0);
            TestMapping<long, uint>(2131243232);
            TestMapping<long, uint>(-2131243232,0);
        }

        [TestMethod]
        public void TestBoolToUIntMapping()
        {
            TestMapping<bool, uint>(true,1);
            TestMapping<bool, uint>(false, 0);
        }

        [TestMethod]
        public void TestCharToUIntMapping()
        {
            TestMapping<char, uint>((char)0,0);
            TestMapping<char, uint>('A', (uint)'A');
        }

        [TestMethod]
        public void TestDoubleToUIntMapping()
        {
            TestMapping<double, uint>(double.MaxValue, 0);
            TestMapping<double, uint>(double.MinValue, 0);
            TestMapping<double, uint>(uint.MaxValue, uint.MaxValue);
            TestMapping<double, uint>(0);
            TestMapping<double, uint>(0.2, 0);
            TestMapping<double, uint>(0.4999, 0);
            TestMapping<double, uint>(0.5,0);
            TestMapping<double, uint>(0.5001, 1);
            TestMapping<double, uint>(0.7, 1);
            TestMapping<double, uint>(1);
            TestMapping<double, uint>(1.5,2);
            TestMapping<double, uint>(-1,0);
            TestMapping<double, uint>(-1.5, 0);
            TestMapping<double, uint>(21312332.244, 21312332);
        }

        [TestMethod]
        public void TestDecimalToUIntMapping()
        {
            TestMapping<decimal, uint>(decimal.MinValue, 0);
            TestMapping<decimal, uint>(decimal.MaxValue, 0);
            TestMapping<decimal, uint>(uint.MaxValue);
            TestMapping<decimal, uint>(uint.MaxValue - 1);
            TestMapping<decimal, uint>(0);
            TestMapping<decimal, uint>(0.2M, 0);
            TestMapping<decimal, uint>(0.4999M, 0);
            TestMapping<decimal, uint>(0.5M, 0);
            TestMapping<decimal, uint>(0.5001M, 1);
            TestMapping<decimal, uint>(0.7M, 1);
            TestMapping<decimal, uint>(1);
            TestMapping<decimal, uint>(1.5M, 2);
            TestMapping<decimal, uint>(-1,0);
            TestMapping<decimal, uint>(-1.5M, 0);
            TestMapping<decimal, uint>(21312332.244M, 21312332);
        }

        [TestMethod]       
        public void TestFloatToUIntMapping()
        {
            TestMapping<float, uint>(float.MinValue, 0);
            TestMapping<float, uint>(float.MaxValue, 0);
            TestMapping<float, uint>(4294966000f, (uint)4294966000f);
            TestMapping<float, uint>(4294967000f, 0f);
            TestMapping<float, uint>(0,0);
            TestMapping<float, uint>(0.2f, 0);
            TestMapping<float, uint>(0.4999f, 0);
            TestMapping<float, uint>(0.5f, 0);
            TestMapping<float, uint>(0.5001f, 1);
            TestMapping<float, uint>(0.7f, 1);
            TestMapping<float, uint>(1);
            TestMapping<float, uint>(1.5f, 2);
            TestMapping<float, uint>(-1,0);
            TestMapping<float, uint>(-1.5f,0);
            TestMapping<float, uint>(21312332.244f, 21312332);
        }

        [TestMethod]
        public void TestDateTimeToUIntMapping()
        {
            TestMapping<DateTime, uint>(new DateTime(1001), 1001);
            TestMapping<DateTime, uint>(DateTime.MaxValue, 0);
            TestMapping<DateTime, uint>(DateTime.MinValue, 0);
        }

        [TestMethod]
        public void TestStringToUIntMapping()
        {
            TestMapping<string, uint>("-20", 0);
            TestMapping<string, uint>("21.1", 0);
            TestMapping<string, uint>("1.2e2", 0);
            TestMapping<string, uint>("2323423448", 2323423448);
            TestMapping<string, uint>(null, 0);
            TestMapping<string, uint>("0", 0);
            TestMapping<string, uint>(" ", 0);
            TestMapping<string, uint>("sdfsdf", 0);
        }

        [TestMethod]
        public void TestObjectToUIntMapping()
        {
            TestMapping<object, uint>("20", 20);
            TestMapping<object, uint>(21, 21);
            TestMapping<object, uint>(uint.MaxValue);
            TestMapping<object, uint>(ulong.MaxValue,0);
            TestMapping<object, uint>(1.2e2, 120);
            TestMapping<object, uint>(SimpleEnumSource.a , (uint)SimpleEnumSource.a);
            TestMapping<object, uint>(new SimpleSourceClass() {a=10},0);
        }

        [TestMethod]
        public void TestTimeSpanToUIntMapping()
        {
            TestMapping<TimeSpan, uint>(TimeSpan.MaxValue, 0);
            TestMapping<TimeSpan, uint>(new TimeSpan(2234), 2234);
            TestMapping<TimeSpan, uint>(new TimeSpan(-2234), 0);
            TestMapping<TimeSpan, uint>(TimeSpan.MinValue, 0);
        }

        [TestMethod]
        public void TestGuidToUIntMapping()
        {
            TestMapping<Guid, uint>(Guid.Empty,0);
            var guid = Guid.NewGuid();
            TestMapping<Guid, uint>(guid, BitConverter.ToUInt32(guid.ToByteArray(), 0));
        }
    }
}
