using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Moon.FastAutoMapper.UnitTest
{
    [TestClass]
    public class PrimitiveToDecimalMappingTest : BaseMappingTest
    {
        [TestMethod]
        public void TestDecimalToDecimalMapping()
        {
            TestMapping<decimal, decimal>(233.1233M);
        }

        [TestMethod]
        public void TestIntToDecimalMapping()
        {
            TestMapping<int,decimal>(int.MinValue);
            TestMapping<int,decimal>(int.MaxValue);
            TestMapping<int,decimal>(0);
            TestMapping<int,decimal>(1);
            TestMapping<int,decimal>(-1);
            TestMapping<int,decimal>(21312332);
        }

        [TestMethod]
        public void TestShortToDecimalMapping()
        {
            TestMapping<short, decimal>(short.MinValue);
            TestMapping<short, decimal>(short.MaxValue);
            TestMapping<short, decimal>(0);
            TestMapping<short, decimal>(1);
            TestMapping<short, decimal>(-1);
            TestMapping<short, decimal>(21312);
        }

        [TestMethod]
        public void TestSByteToDecimalMapping()
        {
            TestMapping<sbyte, decimal>(sbyte.MinValue);
            TestMapping<sbyte, decimal>(sbyte.MaxValue);
            TestMapping<sbyte, decimal>(0);
            TestMapping<sbyte, decimal>(1);
            TestMapping<sbyte, decimal>(-1);
            TestMapping<sbyte, decimal>(21);
        }

        [TestMethod]
        public void TestUShortToDecimalMapping()
        {
            TestMapping<ushort, decimal>(ushort.MaxValue);
            TestMapping<ushort, decimal>(0);
            TestMapping<ushort, decimal>(1);
            TestMapping<ushort, decimal>(21312);
        }

        [TestMethod]
        public void TestByteToDecimalMapping()
        {
            TestMapping<byte, decimal>(byte.MaxValue);
            TestMapping<byte, decimal>(0);
            TestMapping<byte, decimal>(1);
            TestMapping<byte, decimal>(213);
        }

        [TestMethod]
        public void TestULongToDecimalMapping()
        {
            TestMapping<ulong, decimal>(ulong.MaxValue);
            TestMapping<ulong, decimal>(0);
            TestMapping<ulong, decimal>(1);
            TestMapping<ulong, decimal>(2131243232);
        }

        [TestMethod]
        public void TestUIntToDecimalMapping()
        {
            TestMapping<uint, decimal>(uint.MaxValue);
            TestMapping<uint, decimal>(0);
            TestMapping<uint, decimal>(1);
            TestMapping<uint, decimal>(2131243232);
        }
        [TestMethod]
        public void TestBoolToDecimalMapping()
        {
            TestMapping<bool, decimal>(true,1M);
            TestMapping<bool, decimal>(false,0M);
        }

        [TestMethod]
        public void TestCharToDecimalMapping()
        {
            TestMapping<char, decimal>((char)0,0M);
            TestMapping<char, decimal>('A', (decimal)'A');
        }

        private decimal GetDoubleLimitValue(decimal d)
        {
            return decimal.Parse(((double)d).ToString("0"));
        }

        private decimal GetFloatLimitValue(decimal d)
        {
            return decimal.Parse(((float)d).ToString("0"));
        }

        [TestMethod]
        public void TestFloatToDecimalMapping()
        {
            TestMapping<float, decimal>((float)decimal.MaxValue, GetFloatLimitValue(decimal.MaxValue));
            TestMapping<float, decimal>((float)decimal.MinValue, GetFloatLimitValue(decimal.MinValue));
            TestMapping<float, decimal>(float.MaxValue,0M);
            TestMapping<float, decimal>(float.MinValue,0M);
            TestMapping<float, decimal>(0f);
            TestMapping<float, decimal>(.2f);
            TestMapping<float, decimal>(.4999f);
            TestMapping<float, decimal>(.5001f);
            TestMapping<float, decimal>(-1);
            TestMapping<float, decimal>(253.244f);
        }

        [TestMethod]
        public void TestDoubleToDecimalMapping()
        {
            TestMapping<double, decimal>((double)decimal.MinValue,GetDoubleLimitValue(decimal.MinValue));
            TestMapping<double, decimal>((double)decimal.MaxValue, GetDoubleLimitValue(decimal.MaxValue));
            TestMapping<double, decimal>(double.MinValue, 0M);
            TestMapping<double, decimal>(double.MaxValue, 0M);
            TestMapping<double, decimal>(0);
            TestMapping<double, decimal>(.2);
            TestMapping<double, decimal>(.4999);
            TestMapping<double, decimal>(.5);
            TestMapping<double, decimal>(0.5001);
            TestMapping<double, decimal>(1);
            TestMapping<double, decimal>(-1);
            TestMapping<double, decimal>(21312332.244, 21312332.244M);
        }

        [TestMethod]       
        public void TestLongToDecimalMapping()
        {
            TestMapping<long, decimal>(long.MinValue,(decimal)long.MinValue);
            TestMapping<long, decimal>(long.MaxValue, (decimal)long.MaxValue);
            TestMapping<long, decimal>(0,0M);
            TestMapping<long, decimal>(1,1M);
            TestMapping<long, decimal>(-1,-1M);
            TestMapping<long, decimal>(2131233222246, 2131233222246M);
        }

        [TestMethod]
        public void TestDateTimeToDecimalMapping()
        {
            var dt = new DateTime(2010, 3, 4, 2, 33, 3);
            TestMapping<DateTime, decimal>(dt, (decimal)dt.Ticks);
            TestMapping<DateTime, decimal>(DateTime.MaxValue, (decimal)DateTime.MaxValue.Ticks);
            TestMapping<DateTime, decimal>(DateTime.MinValue, (decimal)DateTime.MinValue.Ticks);
        }

        [TestMethod]
        public void TestStringToDecimalMapping()
        {
            TestMapping<string, decimal>("-20", -20M);
            TestMapping<string, decimal>("21.1", 21.1M);
            TestMapping<string, decimal>("1.12e2", 112M);
            TestMapping<string, decimal>("1.268e-3", 0.001268M);
            TestMapping<string, decimal>("232342344823424323", 232342344823424323M);
            TestMapping<string, decimal>(null, 0M);
            TestMapping<string, decimal>("0", 0M);
            TestMapping<string, decimal>(" ", 0M);
            TestMapping<string, decimal>("sdfsdf", 0M);
        }

        [TestMethod]
        public void TestObjectToDecimalMapping()
        {
            TestMapping<object, decimal>("-20", -20M);
            TestMapping<object, decimal>(21, 21M);
            TestMapping<object, decimal>(decimal.MaxValue);
            TestMapping<object, decimal>(1.2e2,120M);
            TestMapping<object, decimal>(SimpleEnumSource.a , (decimal)SimpleEnumSource.a);
            TestMapping<object, decimal>(new SimpleSourceClass() {a=10},0M);
        }

        [TestMethod]
        public void TestTimeSpanToDecimalMapping()
        {
            TestMapping<TimeSpan, decimal>(TimeSpan.MaxValue,(decimal)TimeSpan.MaxValue.Ticks);
            var ts = new TimeSpan(30, 10, 1);
            TestMapping<TimeSpan, decimal>(ts, (decimal)ts.Ticks);
        }

        [TestMethod]
        public void TestGuidToDecimalMapping()
        {
            TestMapping<Guid, decimal>(Guid.Empty,0M);
            var guid = Guid.NewGuid();
            TestMapping<Guid, decimal>(guid, (decimal)BitConverter.ToInt64(guid.ToByteArray(), 0));
        }
    }
}
