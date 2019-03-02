using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Moon.FastAutoMapper.UnitTest
{
    [TestClass]
    public class PrimitiveToLongMappingTest : BaseMappingTest
    {
        [TestMethod]
        public void TestLongToLongMapping()
        {
            TestMapping<long, long>(2);
        }

        [TestMethod]
        public void TestIntToLongMapping()
        {
            TestMapping<int,long>(int.MinValue);
            TestMapping<int,long>(int.MaxValue);
            TestMapping<int,long>(int.MinValue + 1);
            TestMapping<int,long>(int.MaxValue - 1);
            TestMapping<int,long>(0);
            TestMapping<int,long>(1);
            TestMapping<int,long>(-1);
            TestMapping<int,long>(21312332);
        }

        [TestMethod]
        public void TestShortToLongMapping()
        {
            TestMapping<short, long>(short.MinValue);
            TestMapping<short, long>(short.MaxValue);
            TestMapping<short, long>(short.MinValue + 1);
            TestMapping<short, long>(short.MaxValue - 1);
            TestMapping<short, long>(0);
            TestMapping<short, long>(1);
            TestMapping<short, long>(-1);
            TestMapping<short, long>(21312);
        }

        [TestMethod]
        public void TestSByteToLongMapping()
        {
            TestMapping<sbyte, long>(sbyte.MinValue);
            TestMapping<sbyte, long>(sbyte.MaxValue);
            TestMapping<sbyte, long>(sbyte.MinValue + 1);
            TestMapping<sbyte, long>(sbyte.MaxValue - 1);
            TestMapping<sbyte, long>(0);
            TestMapping<sbyte, long>(1);
            TestMapping<sbyte, long>(-1);
            TestMapping<sbyte, long>(21);
        }

        [TestMethod]
        public void TestUShortTLongMapping()
        {
            TestMapping<ushort, long>(ushort.MaxValue);
            TestMapping<ushort, long>(short.MaxValue - 1);
            TestMapping<ushort, long>(0);
            TestMapping<ushort, long>(1);
            TestMapping<ushort, long>(21312);
        }

        [TestMethod]
        public void TestByteToLongMapping()
        {
            TestMapping<byte, long>(byte.MaxValue);
            TestMapping<byte, long>(byte.MaxValue - 1);
            TestMapping<byte, long>(0);
            TestMapping<byte, long>(1);
            TestMapping<byte, long>(213);
        }

        [TestMethod]
        public void TestULongToLongMapping()
        {
            TestMapping<ulong, long>(ulong.MaxValue, 0);
            TestMapping<ulong, long>(long.MaxValue);
            TestMapping<ulong, long>(long.MaxValue + 1uL, 0);
            TestMapping<ulong, long>(long.MaxValue - 1);
            TestMapping<ulong, long>(0);
            TestMapping<ulong, long>(1);
            TestMapping<ulong, long>(2131243232);
        }
        [TestMethod]
        public void TestUIntToLongMapping()
        {
            TestMapping<uint, long>(uint.MaxValue);
            TestMapping<uint, long>(uint.MaxValue-1);
            TestMapping<uint, long>(0);
            TestMapping<uint, long>(1);
            TestMapping<uint, long>(2131243232);
        }
        [TestMethod]
        public void TestBoolToLongMapping()
        {
            TestMapping<bool, long>(true,1);
            TestMapping<bool, long>(false, 0);
        }

        [TestMethod]
        public void TestCharToLongMapping()
        {
            TestMapping<char, long>((char)0,0);
            TestMapping<char, long>('A', (int)'A');
        }

        [TestMethod]
        public void TestDoubleToLongMapping()
        {
            TestMapping<double, long>(double.MaxValue, 0);
            TestMapping<double, long>(double.MinValue, 0);
            TestMapping<double, long>(-9223372036854770000D,(long)-9223372036854770000D);
            TestMapping<double, long>(9223372036854770000D, (long)9223372036854770000D);
            TestMapping<double, long>(-9223372036854780000D,0L);
            TestMapping<double, long>(9223372036854780000D,0L);
            TestMapping<double, long>(0);
            TestMapping<double, long>(0.2, 0);
            TestMapping<double, long>(0.4999, 0);
            TestMapping<double, long>(0.5,0);
            TestMapping<double, long>(0.5001, 1);
            TestMapping<double, long>(0.7, 1);
            TestMapping<double, long>(1);
            TestMapping<double, long>(1.5,2);
            TestMapping<double, long>(-1);
            TestMapping<double, long>(-1.5, -2);
            TestMapping<double, long>(213123323453345.244, 213123323453345);
        }

        [TestMethod]
        public void TestDecimalToLongMapping()
        {
            TestMapping<decimal, long>(decimal.MinValue, 0);
            TestMapping<decimal, long>(decimal.MaxValue, 0);
            TestMapping<decimal, long>(long.MinValue);
            TestMapping<decimal, long>(long.MaxValue);
            TestMapping<decimal, long>(long.MinValue - 1.5M, 0);
            TestMapping<decimal, long>(long.MinValue + 1);
            TestMapping<decimal, long>(long.MaxValue + 1.5M, 0);
            TestMapping<decimal, long>(long.MaxValue - 1);
            TestMapping<decimal, long>(0);
            TestMapping<decimal, long>(0.2M, 0);
            TestMapping<decimal, long>(0.4999M, 0);
            TestMapping<decimal, long>(0.5M, 0);
            TestMapping<decimal, long>(0.5001M, 1);
            TestMapping<decimal, long>(0.7M, 1);
            TestMapping<decimal, long>(1);
            TestMapping<decimal, long>(1.5M, 2);
            TestMapping<decimal, long>(-1);
            TestMapping<decimal, long>(-1.5M, -2);
            TestMapping<decimal, long>(21312332.244M, 21312332);
        }

        [TestMethod]       
        public void TestFloatToLongMapping()
        {
            TestMapping<float, long>(float.MinValue, 0);
            TestMapping<float, long>(float.MaxValue, 0);
            TestMapping<float, long>(9223371000000000000f, (long)9223371000000000000f);
            TestMapping<float, long>(-9223371000000000000f, (long)-9223371000000000000f);
            TestMapping<float, long>(9223372000000000000f, 0L);
            TestMapping<float, long>(-9223372000000000000f, 0L);

            TestMapping<float, long>(0,0);
            TestMapping<float, long>(0.2f, 0);
            TestMapping<float, long>(0.4999f, 0);
            TestMapping<float, long>(0.5f, 0);
            TestMapping<float, long>(0.5001f, 1);
            TestMapping<float, long>(0.7f, 1);
            TestMapping<float, long>(1);
            TestMapping<float, long>(1.5f, 2);
            TestMapping<float, long>(-1);
            TestMapping<float, long>(-1.5f, -2);
            TestMapping<float, long>(21312332.244f, 21312332);
        }

        [TestMethod]
        public void TestDateTimeToLongMapping()
        {
            var dt = new DateTime(2010, 3, 4, 2, 33, 3);
            TestMapping<DateTime, long>(dt, dt.Ticks);
            TestMapping<DateTime, long>(DateTime.MaxValue, DateTime.MaxValue.Ticks);
            TestMapping<DateTime, long>(DateTime.MinValue, DateTime.MinValue.Ticks);
        }

        [TestMethod]
        public void TestStringToLongMapping()
        {
            TestMapping<string, long>("-20", -20);
            TestMapping<string, long>("21.1", 0);
            TestMapping<string, long>("1.2e2", 0);
            TestMapping<string, long>("232342344823424323", 232342344823424323);
            TestMapping<string, long>(null, 0);
            TestMapping<string, long>("0", 0);
            TestMapping<string, long>(" ", 0);
            TestMapping<string, long>("sdfsdf", 0);
        }

        [TestMethod]
        public void TestObjectToLongMapping()
        {
            TestMapping<object , long>("20", 20);
            TestMapping<object, long>(21, 21);
            TestMapping<object, long>(long.MaxValue);
            TestMapping<object, long>(1.2e2, 120);
            TestMapping<object, long>(SimpleEnumSource.a , (long)SimpleEnumSource.a);
            TestMapping<object, long>(new SimpleSourceClass() {a=10},0);
        }

        [TestMethod]
        public void TestTimeSpanToLongMapping()
        {
            TestMapping<TimeSpan, long>(TimeSpan.MaxValue,TimeSpan.MaxValue.Ticks);
            TestMapping<TimeSpan, long>(TimeSpan.MinValue, TimeSpan.MinValue.Ticks);
            var ts = new TimeSpan(30, 10, 1);
            TestMapping<TimeSpan, long>(ts, ts.Ticks);

        }

        [TestMethod]
        public void TestGuidToLongMapping()
        {
            TestMapping<Guid, long>(Guid.Empty,0);
            var guid = Guid.NewGuid();
            TestMapping<Guid, long>(guid, BitConverter.ToInt64(guid.ToByteArray(), 0));
        }
    }
}
