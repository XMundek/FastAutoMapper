using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Moon.FastAutoMapper.UnitTest
{
    [TestClass]
    public class PrimitiveToULongMappingTest : BaseMappingTest
    {
        [TestMethod]
        public void TestULongToULongMapping()
        {
            TestMapping<ulong, ulong>(2);
        }

        [TestMethod]
        public void TestIntToULongMapping()
        {
            TestMapping<int,ulong>(int.MinValue,0);
            TestMapping<int,ulong>(int.MaxValue);
            TestMapping<int,ulong>(int.MinValue + 1,0);
            TestMapping<int,ulong>(int.MaxValue - 1);
            TestMapping<int,ulong>(0);
            TestMapping<int,ulong>(1);
            TestMapping<int,ulong>(-1,0);
            TestMapping<int,ulong>(21312332);
        }

        [TestMethod]
        public void TestShortToULongMapping()
        {
            TestMapping<short, ulong>(short.MinValue,0);
            TestMapping<short, ulong>(short.MaxValue);
            TestMapping<short, ulong>(short.MinValue + 1,0);
            TestMapping<short, ulong>(short.MaxValue - 1);
            TestMapping<short, ulong>(0);
            TestMapping<short, ulong>(1);
            TestMapping<short, ulong>(-1,0);
            TestMapping<short, ulong>(21312);
        }

        [TestMethod]
        public void TestSByteToULongMapping()
        {
            TestMapping<sbyte, ulong>(sbyte.MinValue,0);
            TestMapping<sbyte, ulong>(sbyte.MaxValue);
            TestMapping<sbyte, ulong>(sbyte.MinValue + 1,0);
            TestMapping<sbyte, ulong>(sbyte.MaxValue - 1);
            TestMapping<sbyte, ulong>(0);
            TestMapping<sbyte, ulong>(1);
            TestMapping<sbyte, ulong>(-1,0);
            TestMapping<sbyte, ulong>(21);
        }

        [TestMethod]
        public void TestUIntToULongMapping()
        {
            TestMapping<uint, ulong>(uint.MaxValue);
            TestMapping<uint, ulong>(0);
            TestMapping<uint, ulong>(1);
            TestMapping<uint, ulong>(2131243232);
        }

        [TestMethod]
        public void TestUShortToULongMapping()
        {
            TestMapping<ushort, ulong>(ushort.MaxValue);
            TestMapping<ushort, ulong>(short.MaxValue - 1);
            TestMapping<ushort, ulong>(0);
            TestMapping<ushort, ulong>(1);
            TestMapping<ushort, ulong>(21312);
        }

        [TestMethod]
        public void TestByteToULongMapping()
        {
            TestMapping<byte, ulong>(byte.MaxValue);
            TestMapping<byte, ulong>(byte.MaxValue - 1);
            TestMapping<byte, ulong>(0);
            TestMapping<byte, ulong>(1);
            TestMapping<byte, ulong>(213);
        }

        [TestMethod]
        public void TestLongToULongMapping()
        {
            TestMapping<long, ulong>(long.MaxValue);
            TestMapping<long, ulong>(long.MinValue,0);
            TestMapping<long, ulong>(long.MaxValue - 1);
            TestMapping<long, ulong>(0);
            TestMapping<long, ulong>(-1, 0);
            TestMapping<long, ulong>(2131243232);
            TestMapping<long, ulong>(-2131243232,0);
        }

        [TestMethod]
        public void TestBoolToULongMapping()
        {
            TestMapping<bool, ulong>(true,1);
            TestMapping<bool, ulong>(false, 0);
        }

        [TestMethod]
        public void TestCharToULongMapping()
        {
            TestMapping<char, ulong>((char)0,0);
            TestMapping<char, ulong>('A', (long)'A');
        }

        [TestMethod]
        public void TestDoubleToULongMapping()
        {
            TestMapping<double, ulong>(double.MaxValue, 0);
            TestMapping<double, ulong>(double.MinValue, 0);
            TestMapping<double, ulong>(18446744073709500000D, (ulong)18446744073709500000D);
            TestMapping<double, ulong>(18446744073709600000D, 0);
            TestMapping<double, ulong>(0);
            TestMapping<double, ulong>(0.2, 0);
            TestMapping<double, ulong>(0.4999, 0);
            TestMapping<double, ulong>(0.5,0);
            TestMapping<double, ulong>(0.5001, 1);
            TestMapping<double, ulong>(0.7, 1);
            TestMapping<double, ulong>(1);
            TestMapping<double, ulong>(1.5,2);
            TestMapping<double, ulong>(-1,0);
            TestMapping<double, ulong>(-1.5, 0);
            TestMapping<double, ulong>(213123323453345.244, 213123323453345);
        }

        [TestMethod]
        public void TestDecimalToULongMapping()
        {
            TestMapping<decimal, ulong>(decimal.MinValue, 0);
            TestMapping<decimal, ulong>(decimal.MaxValue, 0);
            TestMapping<decimal, ulong>(ulong.MaxValue);
            TestMapping<decimal, ulong>(ulong.MaxValue - 1);
            TestMapping<decimal, ulong>(0);
            TestMapping<decimal, ulong>(0.2M, 0);
            TestMapping<decimal, ulong>(0.4999M, 0);
            TestMapping<decimal, ulong>(0.5M, 0);
            TestMapping<decimal, ulong>(0.5001M, 1);
            TestMapping<decimal, ulong>(0.7M, 1);
            TestMapping<decimal, ulong>(1);
            TestMapping<decimal, ulong>(1.5M, 2);
            TestMapping<decimal, ulong>(-1,0);
            TestMapping<decimal, ulong>(-1.5M, 0);
            TestMapping<decimal, ulong>(21312332.244M, 21312332);
        }

        [TestMethod]       
        public void TestFloatToULongMapping()
        {
            TestMapping<float, ulong>(float.MinValue, 0);
            TestMapping<float, ulong>(float.MaxValue, 0);
            TestMapping<float, ulong>(18446730000000000000f, (ulong)18446730000000000000f);
            TestMapping<float, ulong>(18446740000000000000f, 0f);
            TestMapping<float, ulong>(0,0);
            TestMapping<float, ulong>(0.2f, 0);
            TestMapping<float, ulong>(0.4999f, 0);
            TestMapping<float, ulong>(0.5f, 0);
            TestMapping<float, ulong>(0.5001f, 1);
            TestMapping<float, ulong>(0.7f, 1);
            TestMapping<float, ulong>(1);
            TestMapping<float, ulong>(1.5f, 2);
            TestMapping<float, ulong>(-1,0);
            TestMapping<float, ulong>(-1.5f,0);
            TestMapping<float, ulong>(21312332.244f, 21312332);
        }

        [TestMethod]
        public void TestDateTimeToULongMapping()
        {
            var dt = new DateTime(2010, 3, 4, 2, 33, 3);
            TestMapping<DateTime, ulong>(dt, dt.Ticks);
            TestMapping<DateTime, ulong>(DateTime.MaxValue, DateTime.MaxValue.Ticks);
            TestMapping<DateTime, ulong>(DateTime.MinValue, DateTime.MinValue.Ticks);
        }

        [TestMethod]
        public void TestStringToULongMapping()
        {
            TestMapping<string, ulong>("-20", 0);
            TestMapping<string, ulong>("21.1", 0);
            TestMapping<string, ulong>("1.2e2", 0);
            TestMapping<string, ulong>("232342344823424323", 232342344823424323);
            TestMapping<string, ulong>(null, 0);
            TestMapping<string, ulong>("0", 0);
            TestMapping<string, ulong>(" ", 0);
            TestMapping<string, ulong>("sdfsdf", 0);
        }

        [TestMethod]
        public void TestObjectToULongMapping()
        {
            TestMapping<object, ulong>("20", 20);
            TestMapping<object, ulong>(21, 21);
            TestMapping<object, ulong>(ulong.MaxValue);
            TestMapping<object, ulong>(1.2e2, 120);
            TestMapping<object, ulong>(SimpleEnumSource.a , (ulong)SimpleEnumSource.a);
            TestMapping<object, ulong>(new SimpleSourceClass() {a=10},0);
        }

        [TestMethod]
        public void TestTimeSpanToULongMapping()
        {
            TestMapping<TimeSpan, ulong>(TimeSpan.MaxValue,TimeSpan.MaxValue.Ticks);
            TestMapping<TimeSpan, ulong>(TimeSpan.MinValue, 0);
            var ts = new TimeSpan(30, 10, 1);
            TestMapping<TimeSpan, ulong>(ts, ts.Ticks);
        }

        [TestMethod]
        public void TestGuidToULongMapping()
        {
            TestMapping<Guid, ulong>(Guid.Empty,0);
            var guid = Guid.NewGuid();
            TestMapping<Guid, ulong>(guid, BitConverter.ToUInt64(guid.ToByteArray(), 0));
        }
    }
}
