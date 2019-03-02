using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Moon.FastAutoMapper.UnitTest
{
    [TestClass]
    public class PrimitiveToIntMappingTest:BaseMappingTest
    {
        [TestMethod]
        public void TestIntToIntMapping()
        {
            TestMapping<int, int>(2);
        }

        [TestMethod]
        public void TestLongToIntMapping()
        {
            TestMapping<long, int>(long.MinValue, 0);
            TestMapping<long, int>(long.MaxValue, 0);
            TestMapping<long, int>(int.MinValue);
            TestMapping<long, int>(int.MaxValue);
            TestMapping<long, int>(int.MinValue - 1L, 0);
            TestMapping<long, int>(int.MinValue + 1);
            TestMapping<long, int>(int.MaxValue + 1L, 0);
            TestMapping<long, int>(int.MaxValue - 1);
            TestMapping<long, int>(0);
            TestMapping<long, int>(1);
            TestMapping<long, int>(-1);
            TestMapping<long, int>(21312332);
        }

        [TestMethod]
        public void TestShortToIntMapping()
        {
            TestMapping<short, int>(short.MinValue);
            TestMapping<short, int>(short.MaxValue);
            TestMapping<short, int>(short.MinValue + 1);
            TestMapping<short, int>(short.MaxValue - 1);
            TestMapping<short, int>(0);
            TestMapping<short, int>(1);
            TestMapping<short, int>(-1);
            TestMapping<short, int>(21312);
        }

        [TestMethod]
        public void TestSByteToIntMapping()
        {
            TestMapping<sbyte, int>(sbyte.MinValue);
            TestMapping<sbyte, int>(sbyte.MaxValue);
            TestMapping<sbyte, int>(sbyte.MinValue + 1);
            TestMapping<sbyte, int>(sbyte.MaxValue - 1);
            TestMapping<sbyte, int>(0);
            TestMapping<sbyte, int>(1);
            TestMapping<sbyte, int>(-1);
            TestMapping<sbyte, int>(21);
        }

        [TestMethod]
        public void TestUShortToIntMapping()
        {
            TestMapping<ushort, int>(ushort.MaxValue);
            TestMapping<ushort, int>(short.MaxValue - 1);
            TestMapping<ushort, int>(0);
            TestMapping<ushort, int>(1);
            TestMapping<ushort, int>(21312);
        }

        [TestMethod]
        public void TestUIntToIntMapping()
        {
            TestMapping<uint, int>(uint.MaxValue,0);
            TestMapping<uint, int>(int.MaxValue);
            TestMapping<uint, int>(0);
            TestMapping<uint, int>(1);
            TestMapping<uint, int>(2131243232);
        }

        [TestMethod]
        public void TestByteToIntMapping()
        {
            TestMapping<byte, int>(byte.MaxValue);
            TestMapping<byte, int>(byte.MaxValue - 1);
            TestMapping<byte, int>(0);
            TestMapping<byte, int>(1);
            TestMapping<byte, int>(213);
        }

        [TestMethod]
        public void TestULongToIntMapping()
        {
            TestMapping<ulong, int>(ulong.MaxValue, 0);
            TestMapping<ulong, int>(int.MaxValue);
            TestMapping<ulong, int>(int.MaxValue + 1uL, 0);
            TestMapping<long, int>(int.MaxValue - 1);
            TestMapping<long, int>(0);
            TestMapping<long, int>(1);
            TestMapping<long, int>(2131243232);
        }

        [TestMethod]
        public void TestBoolToIntMapping()
        {
            TestMapping<bool, int>(true,1);
            TestMapping<bool, int>(false, 0);
        }

        [TestMethod]
        public void TestCharToIntMapping()
        {
            TestMapping<char, int>((char)0,0);
            TestMapping<char, int>('A', (int)'A');
        }

        [TestMethod]
        public void TestDoubleToIntMapping()
        {
            TestMapping<double, int>(double.MinValue, 0);
            TestMapping<double, int>(double.MaxValue, 0);
            TestMapping<double, int>(int.MinValue);
            TestMapping<double, int>(int.MaxValue);
            TestMapping<double, int>(int.MinValue - 1.5, 0);
            TestMapping<double, int>(int.MinValue + 1);
            TestMapping<double, int>(int.MaxValue + 1.5, 0);
            TestMapping<double, int>(int.MaxValue - 1);
            TestMapping<double, int>(0);
            TestMapping<double, int>(0.2, 0);
            TestMapping<double, int>(0.4999, 0);
            TestMapping<double, int>(0.5,0);
            TestMapping<double, int>(0.5001, 1);
            TestMapping<double, int>(0.7, 1);
            TestMapping<double, int>(1);
            TestMapping<double, int>(1.5,2);
            TestMapping<double, int>(-1);
            TestMapping<double, int>(-1.5, -2);
            TestMapping<double, int>(21312332.244, 21312332);
        }

        [TestMethod]
        public void TestDecimalToIntMapping()
        {
            TestMapping<decimal, int>(decimal.MinValue, 0);
            TestMapping<decimal, int>(decimal.MaxValue, 0);
            TestMapping<decimal, int>(int.MinValue);
            TestMapping<decimal, int>(int.MaxValue);
            TestMapping<decimal, int>(int.MinValue - 1.5M, 0);
            TestMapping<decimal, int>(int.MinValue + 1);
            TestMapping<decimal, int>(int.MaxValue + 1.5M, 0);
            TestMapping<decimal, int>(int.MaxValue - 1);
            TestMapping<decimal, int>(0);
            TestMapping<decimal, int>(0.2M, 0);
            TestMapping<decimal, int>(0.4999M, 0);
            TestMapping<decimal, int>(0.5M, 0);
            TestMapping<decimal, int>(0.5001M, 1);
            TestMapping<decimal, int>(0.7M, 1);
            TestMapping<decimal, int>(1);
            TestMapping<decimal, int>(1.5M, 2);
            TestMapping<decimal, int>(-1);
            TestMapping<decimal, int>(-1.5M, -2);
            TestMapping<decimal, int>(21312332.244M, 21312332);
        }

        [TestMethod]
        public void TestFloatToIntMapping()
        {
            TestMapping<float, int>(float.MinValue, 0);
            TestMapping<float, int>(float.MaxValue, 0);
            TestMapping<float, int>(2147483000f, (int)2147483000f);
            TestMapping<float, int>(-2147483000f, (int)-2147483000f);
            TestMapping<float, int>(2147484000f, 0f);
            TestMapping<float, int>(-2147484000f, 0f);
            TestMapping<float, int>(0);
            TestMapping<float, int>(0.2f, 0);
            TestMapping<float, int>(0.4999f, 0);
            TestMapping<float, int>(0.5f, 0);
            TestMapping<float, int>(0.5001f, 1);
            TestMapping<float, int>(0.7f, 1);
            TestMapping<float, int>(1);
            TestMapping<float, int>(1.5f, 2);
            TestMapping<float, int>(-1);
            TestMapping<float, int>(-1.5f, -2);
            TestMapping<float, int>(21312332.244f, 21312332);
        }

        [TestMethod]
        public void TestDateTimeToIntMapping()
        {
            TestMapping<DateTime, int>(new DateTime(1001), 1001);
            TestMapping<DateTime, int>(DateTime.MaxValue, 0);
            TestMapping<DateTime, int>(DateTime.MinValue, 0);
        }

        [TestMethod]
        public void TestStringToIntMapping()
        {
            TestMapping<string, int>("-20", -20);
            TestMapping<string, int>("23", 23);
            TestMapping<string, int>("21.1", 0);
            TestMapping<string, int>("1.2e2", 0);
            TestMapping<string, int>(null, 0);
            TestMapping<string, int>("0", 0);
            TestMapping<string, int>(" ", 0);
            TestMapping<string, int>("sdfsdf", 0);

        }

        [TestMethod]
        public void TestObjectToIntMapping()
        {
            TestMapping<object , int>("20", 20);
            TestMapping<object, int>(21, 21);
            TestMapping<object, int>(long.MaxValue, 0);
            TestMapping<object, int>(1.2e2, 120);
            TestMapping<object, int>(SimpleEnumSource.a , (int)SimpleEnumSource.a);
            TestMapping<object, int>(new SimpleSourceClass() {a=10},0);
        }

        [TestMethod]
        public void TestTimeSpanToIntMapping()
        {
            TestMapping<TimeSpan, int>(TimeSpan.MaxValue, 0);
            TestMapping<TimeSpan, int>(new TimeSpan(2234), 2234);
            TestMapping<TimeSpan, int>(new TimeSpan(-2234), -2234);
            TestMapping<TimeSpan, int>(TimeSpan.MinValue, 0);
        }

        [TestMethod]
        public void TestGuidToIntMapping()
        {
            TestMapping<Guid, int>(Guid.Empty,0);
            var guid = Guid.NewGuid();
            TestMapping<Guid, int>(guid, BitConverter.ToInt32(guid.ToByteArray(), 0));
        }
    }
}
