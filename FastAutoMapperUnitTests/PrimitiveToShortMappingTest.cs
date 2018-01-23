using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Moon.FastAutoMapper.UnitTest
{
    [TestClass]
    public class PrimitiveToShortMappingTest:BaseMappingTest
    {
        [TestMethod]
        public void TestShortToShortMapping()
        {
            TestMapping<short, short>(2);
        }

        [TestMethod]
        public void TestLongToShortMapping()
        {
            TestMapping<long, short>(long.MinValue, 0);
            TestMapping<long, short>(long.MaxValue, 0);
            TestMapping<long, short>(short.MinValue);
            TestMapping<long, short>(short.MaxValue);
            TestMapping<long, short>(short.MinValue - 1L, 0);
            TestMapping<long, short>(short.MinValue + 1);
            TestMapping<long, short>(short.MaxValue + 1L, 0);
            TestMapping<long, short>(short.MaxValue - 1);
            TestMapping<long, short>(0);
            TestMapping<long, short>(1);
            TestMapping<long, short>(-1);
            TestMapping<long, short>(2131);
        }

        [TestMethod]
        public void TestIntToShortMapping()
        {
            TestMapping<int, short>(int.MinValue, 0);
            TestMapping<int, short>(int.MaxValue, 0);
            TestMapping<int, short>(short.MinValue);
            TestMapping<int, short>(short.MaxValue);
            TestMapping<int, short>(short.MinValue - 1, 0);
            TestMapping<int, short>(short.MinValue + 1);
            TestMapping<int, short>(short.MaxValue + 1, 0);
            TestMapping<int, short>(short.MaxValue - 1);
            TestMapping<int, short>(0);
            TestMapping<int, short>(1);
            TestMapping<int, short>(-1);
            TestMapping<int, short>(21334);
        }

        [TestMethod]
        public void TestSByteToShortMapping()
        {
            TestMapping<sbyte, short>(sbyte.MinValue);
            TestMapping<sbyte, short>(sbyte.MaxValue);
            TestMapping<sbyte, short>(sbyte.MinValue + 1);
            TestMapping<sbyte, short>(sbyte.MaxValue - 1);
            TestMapping<sbyte, short>(0);
            TestMapping<sbyte, short>(1);
            TestMapping<sbyte, short>(-1);
            TestMapping<sbyte, short>(21);
        }

        [TestMethod]
        public void TestUShortToShortMapping()
        {
            TestMapping<ushort, short>(ushort.MaxValue,0);
            TestMapping<ushort, short>((ushort)short.MaxValue);
            TestMapping<ushort, short>(short.MaxValue - 1);
            TestMapping<ushort, short>(0);
            TestMapping<ushort, short>(1);
            TestMapping<ushort, short>(21312);
        }

        [TestMethod]
        public void TestByteToShortMapping()
        {
            TestMapping<byte, short>(byte.MaxValue);
            TestMapping<byte, short>(byte.MaxValue - 1);
            TestMapping<byte, short>(0);
            TestMapping<byte, short>(1);
            TestMapping<byte, short>(213);
        }

        [TestMethod]
        public void TestULongToShortMapping()
        {
            TestMapping<ulong, short>(ulong.MaxValue, 0);
            TestMapping<ulong, short>((ulong)short.MaxValue);
            TestMapping<ulong, short>(short.MaxValue + 1, 0);
            TestMapping<ulong, short>(short.MaxValue - 1);
            TestMapping<ulong, short>(0);
            TestMapping<ulong, short>(1);
            TestMapping<ulong, short>(21312);
        }

        [TestMethod]
        public void TestUIntToShortMapping()
        {
            TestMapping<uint, short>(uint.MaxValue, 0);
            TestMapping<uint, short>((uint)short.MaxValue);
            TestMapping<uint, short>((uint)short.MaxValue-1);
            TestMapping<uint, short>((uint)short.MaxValue + 1,0);
            TestMapping<uint, short>(0);
            TestMapping<uint, short>(1);
            TestMapping<uint, short>(2131);
        }

        [TestMethod]
        public void TestBoolToIntMapping()
        {
            TestMapping<bool, short>(true,1);
            TestMapping<bool, short>(false, 0);
        }

        [TestMethod]
        public void TestCharToShortMapping()
        {
            TestMapping<char, short>((char)0,0);
            TestMapping<char, short>('A', (short)'A');
        }

        [TestMethod]
        public void TestDoubleToShortMapping()
        {
            TestMapping<double, short>(double.MinValue, 0);
            TestMapping<double, short>(double.MaxValue, 0);
            TestMapping<double, short>(short.MinValue);
            TestMapping<double, short>(short.MaxValue);
            TestMapping<double, short>(short.MinValue - 1.5, 0);
            TestMapping<double, short>(short.MinValue + 1);
            TestMapping<double, short>(short.MaxValue + 1.5, 0);
            TestMapping<double, short>(short.MaxValue - 1);
            TestMapping<double, short>(0);
            TestMapping<double, short>(0.2, 0);
            TestMapping<double, short>(0.4999, 0);
            TestMapping<double, short>(0.5,0);
            TestMapping<double, short>(0.5001, 1);
            TestMapping<double, short>(0.7, 1);
            TestMapping<double, short>(1);
            TestMapping<double, short>(1.5,2);
            TestMapping<double, short>(-1);
            TestMapping<double, short>(-1.5, -2);
            TestMapping<double, short>(21312.244, 21312);
        }

        [TestMethod]
        public void TestDecimalToShortMapping()
        {
            TestMapping<decimal, short>(decimal.MinValue, 0);
            TestMapping<decimal, short>(decimal.MaxValue, 0);
            TestMapping<decimal, short>(short.MinValue);
            TestMapping<decimal, short>(short.MaxValue);
            TestMapping<decimal, short>(short.MinValue - 1.5M, 0);
            TestMapping<decimal, short>(short.MinValue + 1);
            TestMapping<decimal, short>(short.MaxValue + 1.5M, 0);
            TestMapping<decimal, short>(short.MaxValue - 1);
            TestMapping<decimal, short>(0);
            TestMapping<decimal, short>(0.2M, 0);
            TestMapping<decimal, short>(0.4999M, 0);
            TestMapping<decimal, short>(0.5M, 0);
            TestMapping<decimal, short>(0.5001M, 1);
            TestMapping<decimal, short>(0.7M, 1);
            TestMapping<decimal, short>(1);
            TestMapping<decimal, short>(1.5M, 2);
            TestMapping<decimal, short>(-1);
            TestMapping<decimal, short>(-1.5M, -2);
            TestMapping<decimal, short>(21312.244M, 21312);
        }

        [TestMethod]
        public void TestFloatToShortMapping()
        {
            TestMapping<float, short>(float.MinValue, 0);
            TestMapping<float, short>(float.MaxValue, 0);
            TestMapping<float, short>(short.MinValue, short.MinValue);
            TestMapping<float, short>(short.MaxValue, short.MaxValue);
            TestMapping<float, short>(0);
            TestMapping<float, short>(0.2f, 0);
            TestMapping<float, short>(0.4999f, 0);
            TestMapping<float, short>(0.5f, 0);
            TestMapping<float, short>(0.5001f, 1);
            TestMapping<float, short>(0.7f, 1);
            TestMapping<float, short>(1);
            TestMapping<float, short>(1.5f, 2);
            TestMapping<float, short>(-1);
            TestMapping<float, short>(-1.5f, -2);
            TestMapping<float, short>(21312.244f, 21312);
        }

        [TestMethod]
        public void TestDateTimeToShortMapping()
        {
            TestMapping<DateTime, short>(new DateTime(12312), 12312);
            TestMapping<DateTime, short>(DateTime.MaxValue,0);
            TestMapping<DateTime, short>(DateTime.MinValue, 0);
        }

        [TestMethod]
        public void TestStringToShortMapping()
        {
            TestMapping<string, short>("-20", -20);
            TestMapping<string, short>("23", 23);
            TestMapping<string, short>("21.1", 0);
            TestMapping<string, short>("1.2e2", 0);
            TestMapping<string, short>(null, 0);
            TestMapping<string, short>("0", 0);
            TestMapping<string, short>(" ", 0);
            TestMapping<string, short>("sdfsdf", 0);

        }

        [TestMethod]
        public void TestObjectToShortMapping()
        {
            TestMapping<object , short>("20", 20);
            TestMapping<object, short>(21, 21);
            TestMapping<object, short>(long.MaxValue, 0);
            TestMapping<object, short>(1.2e2, 120);
            TestMapping<object, short>(SimpleEnumSource.a , (int)SimpleEnumSource.a);
            TestMapping<object, short>(new SimpleSourceClass() {a=10},0);
        }

        [TestMethod]
        public void TestTimeSpanToShortMapping()
        {
            TestMapping<TimeSpan, short>(TimeSpan.MaxValue, 0);
            TestMapping<TimeSpan, short>(new TimeSpan(2234), 2234);
            TestMapping<TimeSpan, short>(new TimeSpan(-2234), -2234);
            TestMapping<TimeSpan, short>(TimeSpan.MinValue, 0);
        }

        [TestMethod]
        public void TestGuidToShortMapping()
        {
            TestMapping<Guid, short>(Guid.Empty,0);
            var guid = Guid.NewGuid();
            TestMapping<Guid, short>(guid, BitConverter.ToInt16(guid.ToByteArray(), 0));
        }
    }
}
