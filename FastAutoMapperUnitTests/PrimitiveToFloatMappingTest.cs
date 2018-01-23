using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Moon.FastAutoMapper.UnitTest
{
    [TestClass]
    public class PrimitiveToFloatMappingTest : BaseMappingTest
    {
        [TestMethod]
        public void TestFloatToFloatMapping()
        {
            TestMapping<float, float>(2.12f);
        }

        [TestMethod]
        public void TestIntToFloatMapping()
        {
            TestMapping<int,float>(int.MinValue, (float)int.MinValue);
            TestMapping<int,float>(int.MaxValue,(float)int.MaxValue);
            TestMapping<int,float>(0,0f);
            TestMapping<int,float>(1,1f);
            TestMapping<int,float>(-1,-1f);
            TestMapping<int,float>(21312332, 21312332f);
        }

        [TestMethod]
        public void TestShortToFloatMapping()
        {
            TestMapping<short, float>(short.MinValue);
            TestMapping<short, float>(short.MaxValue);
            TestMapping<short, float>(0);
            TestMapping<short, float>(1);
            TestMapping<short, float>(-1);
            TestMapping<short, float>(21312);
        }

        [TestMethod]
        public void TestSByteToFloatMapping()
        {
            TestMapping<sbyte, float>(sbyte.MinValue);
            TestMapping<sbyte, float>(sbyte.MaxValue);
            TestMapping<sbyte, float>(0);
            TestMapping<sbyte, float>(1);
            TestMapping<sbyte, float>(-1);
            TestMapping<sbyte, float>(21);
        }

        [TestMethod]
        public void TestUShortToFloatMapping()
        {
            TestMapping<ushort, float>(ushort.MaxValue);
            TestMapping<ushort, float>(0);
            TestMapping<ushort, float>(1);
            TestMapping<ushort, float>(21312);
        }

        [TestMethod]
        public void TestByteToFloatMapping()
        {
            TestMapping<byte, float>(byte.MaxValue);
            TestMapping<byte, float>(0);
            TestMapping<byte, float>(1);
            TestMapping<byte, float>(213);
        }

        [TestMethod]
        public void TestULongToFloatMapping()
        {
            TestMapping<ulong, float>(ulong.MaxValue, (float)ulong.MaxValue );
            TestMapping<ulong, float>(0,0f);
            TestMapping<ulong, float>(1,1f);
            TestMapping<ulong, float>(2131243232, 2131243232f);
        }

        [TestMethod]
        public void TestUIntToFloatMapping()
        {
            TestMapping<uint, float>(uint.MaxValue,(float)uint.MaxValue);
            TestMapping<uint, float>(0,0f);
            TestMapping<uint, float>(1,1f);
            TestMapping<uint, float>(2131243232, 2131243232f);
        }
        [TestMethod]
        public void TestBoolToFloatMapping()
        {
            TestMapping<bool, float>(true,1f);
            TestMapping<bool, float>(false, 0f);
        }

        [TestMethod]
        public void TestCharToFloatMapping()
        {
            TestMapping<char, float>((char)0,0);
            TestMapping<char, float>('A', (float)'A');
        }

        [TestMethod]
        public void TestDoubleToFloatMapping()
        {
            TestMapping<double, float>(double.MaxValue,0f);
            TestMapping<double, float>(double.MinValue,0f);
            TestMapping<double, float>(float.MinValue, float.MinValue);
            TestMapping<double, float>(float.MaxValue, float.MaxValue);
            TestMapping<double, float>(0,0f);
            TestMapping<double, float>(0.2,.2f);
            TestMapping<double, float>(0.4999,.4999f);
            TestMapping<double, float>(0.5001,.5001f);
            TestMapping<double, float>(0.7,.7f);
            TestMapping<double, float>(1,1f);
            TestMapping<double, float>(1.5,1.5f);
            TestMapping<double, float>(-1,-1f);
            TestMapping<double, float>(213123323453345.244, 213123323453345.244f);
        }

        [TestMethod]
        public void TestDecimalToFloatMapping()
        {
            TestMapping<decimal, float>(decimal.MinValue,(float)decimal.MinValue);
            TestMapping<decimal, float>(decimal.MaxValue, (float)decimal.MaxValue);
            TestMapping<decimal, float>(0, 0f);
            TestMapping<decimal, float>(0.2M,.2f);
            TestMapping<decimal, float>(0.4999M,.4999f);
            TestMapping<decimal, float>(0.5M,.5f);
            TestMapping<decimal, float>(0.5001M,.5001f);
            TestMapping<decimal, float>(0.7M,.7f);
            TestMapping<decimal, float>(1,1f);
            TestMapping<decimal, float>(1.5M,1.5f);
            TestMapping<decimal, float>(-1,-1f);
            TestMapping<decimal, float>(-1.5M,-1.5f);
            TestMapping<decimal, float>(21312332.244M, 21312332.244f);
        }

        [TestMethod]       
        public void TestLongToFloatMapping()
        {
            TestMapping<long, float>(long.MinValue,(float)long.MinValue);
            TestMapping<long, float>(long.MaxValue, (float)long.MaxValue);
            TestMapping<long, float>(0,0f);
            TestMapping<long, float>(1,1f);
            TestMapping<long, float>(-1,-1f);
            TestMapping<long, float>(2131233222246, 2131233222246f);
        }

        [TestMethod]
        public void TestDateTimeToFloatMapping()
        {
            var dt = new DateTime(2010, 3, 4, 2, 33, 3);
            TestMapping<DateTime, float>(dt, (float)dt.Ticks);
            TestMapping<DateTime, float>(DateTime.MaxValue, (float)DateTime.MaxValue.Ticks);
            TestMapping<DateTime, float>(DateTime.MinValue, (float)DateTime.MinValue.Ticks);
        }

        [TestMethod]
        public void TestStringToFloatMapping()
        {
            TestMapping<string, float>("-20", -20f);
            TestMapping<string, float>("21.1", 21.1f);
            TestMapping<string, float>("1.2e2", 120f);
            TestMapping<string, float>("232342344823424323", 232342344823424323f);
            TestMapping<string, float>(null, 0f);
            TestMapping<string, float>("0", 0f);
            TestMapping<string, float>(" ", 0f);
            TestMapping<string, float>("sdfsdf", 0f);
        }

        [TestMethod]
        public void TestObjectToFloatMapping()
        {
            TestMapping<object , float>("-20", -20f);
            TestMapping<object, float>(21, 21f);
            TestMapping<object, float>(float.MaxValue);
            TestMapping<object, float>(1.2e2, 120f);
            TestMapping<object, float>(SimpleEnumSource.a , (float)SimpleEnumSource.a);
            TestMapping<object, float>(new SimpleSourceClass() {a=10},0f);
        }

        [TestMethod]
        public void TestTimeSpanToFloatMapping()
        {
            TestMapping<TimeSpan, float>(TimeSpan.MaxValue,(float)TimeSpan.MaxValue.Ticks);
            TestMapping<TimeSpan, float>(TimeSpan.MinValue, (float)TimeSpan.MinValue.Ticks);
            var ts = new TimeSpan(30, 10, 1);
            TestMapping<TimeSpan, float>(ts, (float)ts.Ticks);
        }

        [TestMethod]
        public void TestGuidToFloatMapping()
        {
            TestMapping<Guid, float>(Guid.Empty,0);
            var guid = Guid.NewGuid();
            TestMapping<Guid, float>(guid, (float)BitConverter.ToInt64(guid.ToByteArray(), 0));
        }
    }
}
