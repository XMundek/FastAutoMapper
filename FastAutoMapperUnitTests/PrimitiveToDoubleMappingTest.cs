using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Moon.FastAutoMapper.UnitTest
{
    [TestClass]
    public class PrimitiveToDoubleMappingTest : BaseMappingTest
    {
        [TestMethod]
        public void TestDoubleToDoubleMapping()
        {
            TestMapping<double, double>(233.1233);
        }

        [TestMethod]
        public void TestIntToDoubleMapping()
        {
            TestMapping<int,double>(int.MinValue, (double)int.MinValue);
            TestMapping<int,double>(int.MaxValue,(double)int.MaxValue);
            TestMapping<int,double>(0,.0);
            TestMapping<int,double>(1,1.0);
            TestMapping<int,double>(-1,-1.0);
            TestMapping<int,double>(21312332, 21312332.0);
        }

        [TestMethod]
        public void TestShortToDoubleMapping()
        {
            TestMapping<short, double>(short.MinValue);
            TestMapping<short, double>(short.MaxValue);
            TestMapping<short, double>(0);
            TestMapping<short, double>(1);
            TestMapping<short, double>(-1);
            TestMapping<short, double>(21312);
        }

        [TestMethod]
        public void TestSByteToDoubleMapping()
        {
            TestMapping<sbyte, double>(sbyte.MinValue);
            TestMapping<sbyte, double>(sbyte.MaxValue);
            TestMapping<sbyte, double>(0);
            TestMapping<sbyte, double>(1);
            TestMapping<sbyte, double>(-1);
            TestMapping<sbyte, double>(21);
        }

        [TestMethod]
        public void TestUShortTDoubleMapping()
        {
            TestMapping<ushort, double>(ushort.MaxValue);
            TestMapping<ushort, double>(0);
            TestMapping<ushort, double>(1);
            TestMapping<ushort, double>(21312);
        }

        [TestMethod]
        public void TestByteToDoubleMapping()
        {
            TestMapping<byte, double>(byte.MaxValue);
            TestMapping<byte, double>(0);
            TestMapping<byte, double>(1);
            TestMapping<byte, double>(213);
        }

        [TestMethod]
        public void TestULongToDoubleMapping()
        {
            TestMapping<ulong, double>(ulong.MaxValue, (double)ulong.MaxValue );
            TestMapping<ulong, double>(0,.0);
            TestMapping<ulong, double>(1,1.0);
            TestMapping<ulong, double>(2131243232, 2131243232.0);
        }

        [TestMethod]
        public void TestUIntToDoubleMapping()
        {
            TestMapping<uint, double>(uint.MaxValue,(double)uint.MaxValue);
            TestMapping<uint, double>(0,.0);
            TestMapping<uint, double>(1,1.0);
            TestMapping<uint, double>(2131243232, 2131243232.0);
        }
        [TestMethod]
        public void TestBoolToDoubleMapping()
        {
            TestMapping<bool, double>(true,1.0);
            TestMapping<bool, double>(false,0.0);
        }

        [TestMethod]
        public void TestCharToDoubleMapping()
        {
            TestMapping<char, double>((char)0,0.0);
            TestMapping<char, double>('A', (double)'A');
        }

        [TestMethod]
        public void TestFloatToDoubleMapping()
        {
            TestMapping<float, double>(float.MaxValue,(double)float.MaxValue);
            TestMapping<float, double>(float.MinValue,(double)float.MinValue);
            TestMapping<float, double>(0f);
            TestMapping<float, double>(.2f, (double).2f);
            TestMapping<float, double>(.4999f, (double).4999f);
            TestMapping<float, double>(.5001f, (double).5001f);
            TestMapping<float, double>(-1);
            TestMapping<float, double>(253673345.244f, (double)253673345.244f);
        }

        [TestMethod]
        public void TestDecimalToDoubleMapping()
        {
            TestMapping<decimal, double>(decimal.MinValue,(double)decimal.MinValue);
            TestMapping<decimal, double>(decimal.MaxValue, (double)decimal.MaxValue);
            TestMapping<decimal, double>(0, .0);
            TestMapping<decimal, double>(0.2M,.2);
            TestMapping<decimal, double>(0.4999M,.4999);
            TestMapping<decimal, double>(0.5M,.5);
            TestMapping<decimal, double>(0.5001M,.5001);
            TestMapping<decimal, double>(1,1f);
            TestMapping<decimal, double>(-1,-1f);
            TestMapping<decimal, double>(21312332.244M, 21312332.244);
        }

        [TestMethod]       
        public void TestLongToDoubleMapping()
        {
            TestMapping<long, double>(long.MinValue,(double)long.MinValue);
            TestMapping<long, double>(long.MaxValue, (double)long.MaxValue);
            TestMapping<long, double>(0,.0);
            TestMapping<long, double>(1,1.0);
            TestMapping<long, double>(-1,-1.0);
            TestMapping<long, double>(2131233222246, 2131233222246.0);
        }

        [TestMethod]
        public void TestDateTimeToDoubleMapping()
        {
            var dt = new DateTime(2010, 3, 4, 2, 33, 3);
            TestMapping<DateTime, double>(dt, (double)dt.Ticks);
            TestMapping<DateTime, double>(DateTime.MaxValue, (double)DateTime.MaxValue.Ticks);
            TestMapping<DateTime, double>(DateTime.MinValue, (double)DateTime.MinValue.Ticks);
        }

        [TestMethod]
        public void TestStringToDoubleMapping()
        {
            TestMapping<string, double>("-20", -20.0);
            TestMapping<string, double>("21.1", 21.1);
            TestMapping<string, double>("1.12e2", 1.12e2);
            TestMapping<string, double>("1.268e-3", 1.268e-3);
            TestMapping<string, double>("232342344823424323", 232342344823424323.0);
            TestMapping<string, double>(null, .0);
            TestMapping<string, double>("0", .0);
            TestMapping<string, double>(" ", .0);
            TestMapping<string, double>("sdfsdf", .0);
        }

        [TestMethod]
        public void TestObjectToDoubleMapping()
        {
            TestMapping<object , double>("-20", -20.0);
            TestMapping<object, double>(21, 21.0);
            TestMapping<object, double>(double.MaxValue);
            TestMapping<object, double>(1.2e2);
            TestMapping<object, double>(SimpleEnumSource.a , (double)SimpleEnumSource.a);
            TestMapping<object, double>(new SimpleSourceClass() {a=10},0d);
        }

        [TestMethod]
        public void TestTimeSpanToDoubleMapping()
        {
            TestMapping<TimeSpan, double>(TimeSpan.MaxValue,(double)TimeSpan.MaxValue.Ticks);
            var ts = new TimeSpan(30, 10, 1);
            TestMapping<TimeSpan, double>(ts, (double)ts.Ticks);
        }

        [TestMethod]
        public void TestGuidToDoubleMapping()
        {
            TestMapping<Guid, double>(Guid.Empty,0);
            var guid = Guid.NewGuid();
            TestMapping<Guid, double>(guid, (double)BitConverter.ToInt64(guid.ToByteArray(), 0));
        }
    }
}
