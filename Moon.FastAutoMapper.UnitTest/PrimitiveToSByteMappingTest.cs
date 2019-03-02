using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Moon.FastAutoMapper.UnitTest
{
    [TestClass]
    public class PrimitiveToSByteMappingTest:BaseMappingTest
    {
        [TestMethod]
        public void TestSByteToSByteMapping()
        {
            TestMapping<sbyte, sbyte>(2);
        }

        [TestMethod]
        public void TestLongToSByteMapping()
        {
            TestMapping<long, sbyte>(long.MinValue, 0);
            TestMapping<long, sbyte>(long.MaxValue, 0);
            TestMapping<long, sbyte>(sbyte.MinValue);
            TestMapping<long, sbyte>(sbyte.MaxValue);
            TestMapping<long, sbyte>(sbyte.MinValue - 1L, 0);
            TestMapping<long, sbyte>(sbyte.MinValue + 1);
            TestMapping<long, sbyte>(sbyte.MaxValue + 1L, 0);
            TestMapping<long, sbyte>(sbyte.MaxValue - 1);
            TestMapping<long, sbyte>(0);
            TestMapping<long, sbyte>(1);
            TestMapping<long, sbyte>(-1);
            TestMapping<long, sbyte>(21);
        }

        [TestMethod]
        public void TestIntToSByteMapping()
        {
            TestMapping<int, sbyte>(int.MinValue, 0);
            TestMapping<int, sbyte>(int.MaxValue, 0);
            TestMapping<int, sbyte>(sbyte.MinValue);
            TestMapping<int, sbyte>(sbyte.MaxValue);
            TestMapping<int, sbyte>(sbyte.MinValue - 1, 0);
            TestMapping<int, sbyte>(sbyte.MinValue + 1);
            TestMapping<int, sbyte>(sbyte.MaxValue + 1, 0);
            TestMapping<int, sbyte>(sbyte.MaxValue - 1);
            TestMapping<int, sbyte>(0);
            TestMapping<int, sbyte>(1);
            TestMapping<int, sbyte>(-1);
            TestMapping<int, sbyte>(21);
        }

        [TestMethod]
        public void TestShortToSByteMapping()
        {
            TestMapping<short, sbyte>(short.MinValue,0);
            TestMapping<short, sbyte>(short.MaxValue,0);
            TestMapping<short, sbyte>(sbyte.MinValue);
            TestMapping<short, sbyte>(sbyte.MaxValue);
            TestMapping<short, sbyte>(sbyte.MinValue - 1,0);
            TestMapping<short, sbyte>(sbyte.MaxValue + 1,0);
            TestMapping<short, sbyte>(sbyte.MinValue + 1);
            TestMapping<short, sbyte>(sbyte.MaxValue - 1);
            TestMapping<short, sbyte>(0);
            TestMapping<short, sbyte>(1);
            TestMapping<short, sbyte>(-1);
            TestMapping<short, sbyte>(21);
        }

        [TestMethod]
        public void TestUShortToSByteMapping()
        {
            TestMapping<ushort, sbyte>(ushort.MaxValue,0);
            TestMapping<ushort, sbyte>((ushort)sbyte.MaxValue);
            TestMapping<ushort, sbyte>((ushort)sbyte.MaxValue - 1);
            TestMapping<ushort, sbyte>(0);
            TestMapping<ushort, sbyte>(1);
            TestMapping<ushort, sbyte>(121);
        }

        [TestMethod]
        public void TestByteToSByteMapping()
        {
            TestMapping<byte, sbyte>((byte) sbyte.MaxValue);
            TestMapping<byte, sbyte>((byte)sbyte.MaxValue+1,0);
            TestMapping<byte, sbyte>(sbyte.MaxValue-1);
            TestMapping<byte, sbyte>(0);
            TestMapping<byte, sbyte>(1);
            TestMapping<byte, sbyte>(21);
        }

        [TestMethod]
        public void TestULongToSByteMapping()
        {
            TestMapping<ulong, sbyte>(ulong.MaxValue, 0);
            TestMapping<ulong, sbyte>((ulong)sbyte.MaxValue);
            TestMapping<ulong, sbyte>(sbyte.MaxValue + 1, 0);
            TestMapping<ulong, sbyte>(sbyte.MaxValue - 1);
            TestMapping<ulong, sbyte>(0);
            TestMapping<ulong, sbyte>(1);
            TestMapping<ulong, sbyte>(121);
        }

        [TestMethod]
        public void TestUIntToSByteMapping()
        {
            TestMapping<uint, sbyte>(uint.MaxValue, 0);
            TestMapping<uint, sbyte>((uint)sbyte.MaxValue);
            TestMapping<uint, sbyte>((uint)sbyte.MaxValue+1,0);
            TestMapping<uint, sbyte>((uint)sbyte.MaxValue - 1);
            TestMapping<uint, sbyte>(0);
            TestMapping<uint, sbyte>(1);
            TestMapping<uint, sbyte>(21);
        }

        [TestMethod]
        public void TestBoolToSByteMapping()
        {
            TestMapping<bool, sbyte>(true,1);
            TestMapping<bool, sbyte>(false, 0);
        }

        [TestMethod]
        public void TestCharToSByteMapping()
        {
            TestMapping<char, sbyte>((char)0,0);
            TestMapping<char, sbyte>('A', (sbyte)'A');
            TestMapping<char, sbyte>((char)sbyte.MaxValue,sbyte.MaxValue);
            TestMapping<char, sbyte>((char)(sbyte.MaxValue+1),0);
        }

        [TestMethod]
        public void TestDoubleToSByteMapping()
        {
            TestMapping<double, sbyte>(double.MinValue, 0);
            TestMapping<double, sbyte>(double.MaxValue, 0);
            TestMapping<double, sbyte>(sbyte.MinValue);
            TestMapping<double, sbyte>(sbyte.MaxValue);
            TestMapping<double, sbyte>(sbyte.MinValue - 1.5, 0);
            TestMapping<double, sbyte>(sbyte.MinValue + 1);
            TestMapping<double, sbyte>(sbyte.MaxValue + 1.5, 0);
            TestMapping<double, sbyte>(sbyte.MaxValue - 1);
            TestMapping<double, sbyte>(0);
            TestMapping<double, sbyte>(0.2, 0);
            TestMapping<double, sbyte>(0.4999, 0);
            TestMapping<double, sbyte>(0.5,0);
            TestMapping<double, sbyte>(0.5001, 1);
            TestMapping<double, sbyte>(0.7, 1);
            TestMapping<double, sbyte>(1);
            TestMapping<double, sbyte>(1.5,2);
            TestMapping<double, sbyte>(-1);
            TestMapping<double, sbyte>(-1.5, -2);
            TestMapping<double, sbyte>(121.244, 121);
        }

        [TestMethod]
        public void TestDecimalToSByteMapping()
        {
            TestMapping<decimal, sbyte>(decimal.MinValue, 0);
            TestMapping<decimal, sbyte>(decimal.MaxValue, 0);
            TestMapping<decimal, sbyte>(sbyte.MinValue);
            TestMapping<decimal, sbyte>(sbyte.MaxValue);
            TestMapping<decimal, sbyte>(sbyte.MinValue - 1.5M, 0);
            TestMapping<decimal, sbyte>(sbyte.MinValue + 1);
            TestMapping<decimal, sbyte>(sbyte.MaxValue + 1.5M, 0);
            TestMapping<decimal, sbyte>(sbyte.MaxValue - 1);
            TestMapping<decimal, sbyte>(0);
            TestMapping<decimal, sbyte>(0.2M, 0);
            TestMapping<decimal, sbyte>(0.4999M, 0);
            TestMapping<decimal, sbyte>(0.5M, 0);
            TestMapping<decimal, sbyte>(0.5001M, 1);
            TestMapping<decimal, sbyte>(0.7M, 1);
            TestMapping<decimal, sbyte>(1);
            TestMapping<decimal, sbyte>(1.5M, 2);
            TestMapping<decimal, sbyte>(-1);
            TestMapping<decimal, sbyte>(-1.5M, -2);
            TestMapping<decimal, sbyte>(121.244M, 121);
        }

        [TestMethod]
        public void TestFloatToSByteMapping()
        {
            TestMapping<float, sbyte>(float.MinValue, 0);
            TestMapping<float, sbyte>(float.MaxValue, 0);
            TestMapping<float, sbyte>(sbyte.MinValue, sbyte.MinValue);
            TestMapping<float, sbyte>(sbyte.MaxValue, sbyte.MaxValue);
            TestMapping<float, sbyte>(0);
            TestMapping<float, sbyte>(0.2f, 0);
            TestMapping<float, sbyte>(0.4999f, 0);
            TestMapping<float, sbyte>(0.5f, 0);
            TestMapping<float, sbyte>(0.5001f, 1);
            TestMapping<float, sbyte>(0.7f, 1);
            TestMapping<float, sbyte>(1);
            TestMapping<float, sbyte>(1.5f, 2);
            TestMapping<float, sbyte>(-1);
            TestMapping<float, sbyte>(-1.5f, -2);
            TestMapping<float, sbyte>(121.244f, 121);
        }

        [TestMethod]
        public void TestDateTimeToSByteMapping()
        {
            TestMapping<DateTime, sbyte>(new DateTime(123), 123);
            TestMapping<DateTime, sbyte>(DateTime.MaxValue,0);
            TestMapping<DateTime, sbyte>(DateTime.MinValue, 0);
        }

        [TestMethod]
        public void TestStringToSByteMapping()
        {
            TestMapping<string, sbyte>("-20", -20);
            TestMapping<string, sbyte>("23", 23);
            TestMapping<string, sbyte>("21.1", 0);
            TestMapping<string, sbyte>("1.2e2", 0);
            TestMapping<string, sbyte>(null, 0);
            TestMapping<string, sbyte>("0", 0);
            TestMapping<string, sbyte>(" ", 0);
            TestMapping<string, sbyte>("sdfsdf", 0);

        }

        [TestMethod]
        public void TestObjectToSByteMapping()
        {
            TestMapping<object , sbyte>("20", 20);
            TestMapping<object, sbyte>(21, 21);
            TestMapping<object, sbyte>(long.MaxValue, 0);
            TestMapping<object, sbyte>(1.2e2, 120);
            TestMapping<object, sbyte>(SimpleEnumSource.a , (int)SimpleEnumSource.a);
            TestMapping<object, sbyte>(new SimpleSourceClass() {a=10},0);
        }

        [TestMethod]
        public void TestTimeSpanToSByteMapping()
        {
            TestMapping<TimeSpan, sbyte>(TimeSpan.MaxValue, 0);
            TestMapping<TimeSpan, sbyte>(TimeSpan.MinValue, 0);
            TestMapping<TimeSpan, sbyte>(new TimeSpan(120), 120);
            TestMapping<TimeSpan, sbyte>(new TimeSpan(-120), -120);
        }

        [TestMethod]
        public void TestGuidToSByteMapping()
        {
            TestMapping<Guid, sbyte>(Guid.Empty,0);
            var arr = new byte[16];
            arr[0] = 120;
            TestMapping<Guid, sbyte>(new Guid(arr), 120);
            arr[0] = 234;
            TestMapping<Guid, sbyte>(new Guid(arr), (sbyte)arr[0]);
            sbyte testval = -20;
            arr[0] = (byte)testval;
            TestMapping<Guid, sbyte>(new Guid(arr), (sbyte)arr[0]);
        }
    }
}
