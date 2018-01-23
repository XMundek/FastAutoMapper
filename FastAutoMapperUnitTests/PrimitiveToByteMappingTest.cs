using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Moon.FastAutoMapper.UnitTest
{
    [TestClass]
    public class PrimitiveToByteMappingTest : BaseMappingTest
    {
        [TestMethod]
        public void TestByteToByteMapping()
        {
            TestMapping<byte, byte>(2);
        }

        [TestMethod]
        public void TestIntToByteMapping()
        {
            TestMapping<int, byte>(int.MinValue,0);
            TestMapping<int, byte>(int.MaxValue,0);
            TestMapping<int, byte>(byte.MaxValue + 1,0);
            TestMapping<int, byte>(byte.MaxValue - 1);
            TestMapping<int, byte>(byte.MaxValue);
            TestMapping<int, byte>(0);
            TestMapping<int, byte>(1);
            TestMapping<int, byte>(-1,0);
            TestMapping<int, byte>(213);
        }

        [TestMethod]
        public void TestShortToByteMapping()
        {
            TestMapping<short, byte>(short.MinValue,0);
            TestMapping<short, byte>(short.MaxValue,0);
            TestMapping<short, byte>(byte.MaxValue + 1,0);
            TestMapping<short, byte>(byte.MaxValue);
            TestMapping<short, byte>(0);
            TestMapping<short, byte>(1);
            TestMapping<short, byte>(-1,0);
            TestMapping<short, byte>(213);
        }

        [TestMethod]
        public void TestSByteToByteMapping()
        {
            TestMapping<sbyte, byte>(sbyte.MinValue,0);
            TestMapping<sbyte, byte>(sbyte.MaxValue);
            TestMapping<sbyte, byte>(sbyte.MinValue + 1,0);
            TestMapping<sbyte, byte>(sbyte.MaxValue - 1);
            TestMapping<sbyte, byte>(0);
            TestMapping<sbyte, byte>(1);
            TestMapping<sbyte, byte>(-1,0);
            TestMapping<sbyte, byte>(21);
        }

        [TestMethod]
        public void TestUIntToByteMapping()
        {
            TestMapping<uint, byte>(uint.MaxValue,0);
            TestMapping<uint, byte>(byte.MaxValue);
            TestMapping<uint, byte>(0);
            TestMapping<uint, byte>(1);
            TestMapping<uint, byte>(213);
        }

        [TestMethod]
        public void TestULongToByteMapping()
        {
            TestMapping<ulong, byte>(ulong.MaxValue,0);
            TestMapping<ulong, byte>(byte.MaxValue);
            TestMapping<ulong, byte>(0);
            TestMapping<ulong, byte>(1);
            TestMapping<ulong, byte>(214);
        }

        [TestMethod]
        public void TestUShortToByteMapping()
        {
            TestMapping<ushort, byte>(ushort.MaxValue,0);
            TestMapping<ushort, byte>(byte.MaxValue);
            TestMapping<ushort, byte>(byte.MaxValue - 1);
            TestMapping<ushort, byte>(0);
            TestMapping<ushort, byte>(1);
            TestMapping<ushort, byte>(213);
        }

        [TestMethod]
        public void TestLongToByteMapping()
        {
            TestMapping<long, byte>(long.MaxValue,0);
            TestMapping<long, byte>(long.MinValue,0);
            TestMapping<long, byte>(byte.MaxValue);
            TestMapping<long, byte>(0);
            TestMapping<long, byte>(-1, 0);
            TestMapping<long, byte>(213);
            TestMapping<long, byte>(-213,0);
        }

        [TestMethod]
        public void TestBoolToByteMapping()
        {
            TestMapping<bool, byte>(true,1);
            TestMapping<bool, byte>(false, 0);
        }

        [TestMethod]
        public void TestCharToByteMapping()
        {
            TestMapping<char, byte>((char)0,0);
            TestMapping<char, byte>('A', (byte)'A');
            TestMapping<char, byte>(char.MaxValue, 0);
            TestMapping<char, byte>((char)byte.MaxValue, byte.MaxValue);
        }

        [TestMethod]
        public void TestDoubleToByteMapping()
        {
            TestMapping<double, byte>(double.MaxValue, 0);
            TestMapping<double, byte>(double.MinValue, 0);
            TestMapping<double, byte>(255.0, 255);
            TestMapping<double, byte>(255.49, 255);
            TestMapping<double, byte>(255.5, 0);
            TestMapping<double, byte>(256, 0);
            TestMapping<double, byte>(0);
            TestMapping<double, byte>(0.2, 0);
            TestMapping<double, byte>(0.4999, 0);
            TestMapping<double, byte>(0.5,0);
            TestMapping<double, byte>(0.5001, 1);
            TestMapping<double, byte>(0.7, 1);
            TestMapping<double, byte>(1);
            TestMapping<double, byte>(1.5,2);
            TestMapping<double, byte>(-1,0);
            TestMapping<double, byte>(-1.5, 0);
            TestMapping<double, byte>(213.244, 213);
        }

        [TestMethod]
        public void TestDecimalToByteMapping()
        {
            TestMapping<decimal, byte>(decimal.MinValue, 0);
            TestMapping<decimal, byte>(decimal.MaxValue, 0);
            TestMapping<decimal, byte>(byte.MaxValue);
            TestMapping<decimal, byte>(byte.MaxValue - 1);
            TestMapping<decimal, byte>(0);
            TestMapping<decimal, byte>(0.2M, 0);
            TestMapping<decimal, byte>(0.4999M, 0);
            TestMapping<decimal, byte>(0.5M, 0);
            TestMapping<decimal, byte>(0.5001M, 1);
            TestMapping<decimal, byte>(0.7M, 1);
            TestMapping<decimal, byte>(1);
            TestMapping<decimal, byte>(1.5M, 2);
            TestMapping<decimal, byte>(-1,0);
            TestMapping<decimal, byte>(-1.5M, 0);
            TestMapping<decimal, byte>(213.244M, 213);
        }

        [TestMethod]       
        public void TestFloatToByteMapping()
        {
            TestMapping<float, byte>(float.MinValue, 0);
            TestMapping<float, byte>(float.MaxValue, 0);
            TestMapping<float, byte>(255, 255);
            TestMapping<float, byte>(0,0);
            TestMapping<float, byte>(0.2f, 0);
            TestMapping<float, byte>(0.4999f, 0);
            TestMapping<float, byte>(0.5f, 0);
            TestMapping<float, byte>(0.5001f, 1);
            TestMapping<float, byte>(0.7f, 1);
            TestMapping<float, byte>(1);
            TestMapping<float, byte>(1.5f, 2);
            TestMapping<float, byte>(-1,0);
            TestMapping<float, byte>(-1.5f,0);
            TestMapping<float, byte>(213.24f,  213);
        }

        [TestMethod]
        public void TestDateTimeToByteMapping()
        {   TestMapping<DateTime, byte>(new DateTime(200), 200);
            TestMapping<DateTime, byte>(DateTime.MaxValue, 0);
            TestMapping<DateTime, byte>(DateTime.MinValue, 0);
        }

        [TestMethod]
        public void TestStringToByteMapping()
        {
            TestMapping<string, byte>("-20", 0);
            TestMapping<string, byte>("21.1", 0);
            TestMapping<string, byte>("1.2e2", 0);
            TestMapping<string, byte>("232", 232);
            TestMapping<string, byte>(null, 0);
            TestMapping<string, byte>("0", 0);
            TestMapping<string, byte>(" ", 0);
            TestMapping<string, byte>("sdfsdf", 0);
        }

        [TestMethod]
        public void TestObjectToByteMapping()
        {
            TestMapping<object, byte>("20", 20);
            TestMapping<object, byte>(21, 21);
            TestMapping<object, byte>(byte.MaxValue);
            TestMapping<object, byte>(1.2e2, 120);
            TestMapping<object, byte>(SimpleEnumSource.a , (byte)SimpleEnumSource.a);
            TestMapping<object, byte>(new SimpleSourceClass() {a=10},0);
        }

        [TestMethod]
        public void TestTimeSpanToByteMapping()
        {
            TestMapping<TimeSpan, byte>(TimeSpan.MaxValue,0);
            TestMapping<TimeSpan, byte>(new TimeSpan(101), 101);
        }

        [TestMethod]
        public void TestGuidToByteMapping()
        {
            TestMapping<Guid, byte>(Guid.Empty,0);
            var guid = Guid.NewGuid();
           TestMapping<Guid, byte>(guid, guid.ToByteArray()[0]);
        }
    }
}
