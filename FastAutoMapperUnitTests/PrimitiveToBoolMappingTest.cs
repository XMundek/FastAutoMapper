using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Moon.FastAutoMapper.UnitTest
{
    [TestClass]
    public class PrimitiveToBoolMappingTest : BaseMappingTest
    {
        [TestMethod]
        public void TestBoolToBoolMapping()
        {
            TestMapping<bool, bool>(true);
            TestMapping<bool, bool>(false);
        }

        [TestMethod]
        public void TestIntToBoolMapping()
        {
            TestMapping<int, bool>(int.MinValue,true);
            TestMapping<int, bool>(int.MaxValue,true);
            TestMapping<int, bool>(0,false);
            TestMapping<int, bool>(1,true);
            TestMapping<int, bool>(-1,true);
        }

        [TestMethod]
        public void TestShortToBoolMapping()
        {
            TestMapping<short, bool>(short.MinValue,true);
            TestMapping<short, bool>(short.MaxValue,true);
            TestMapping<short, bool>(0,false);
            TestMapping<short, bool>(1,true);
            TestMapping<short, bool>(-1,true);
            TestMapping<short, bool>(213,true);
        }

        [TestMethod]
        public void TestSByteToBoolMapping()
        {
            TestMapping<sbyte, bool>(sbyte.MinValue,true);
            TestMapping<sbyte, bool>(sbyte.MaxValue,true);
            TestMapping<sbyte, bool>(0,false);
            TestMapping<sbyte, bool>(1,true);
            TestMapping<sbyte, bool>(-1,true);
        }

        [TestMethod]
        public void TestUIntToBoolMapping()
        {
            TestMapping<uint, bool>(uint.MaxValue,true);
            TestMapping<uint, bool>(0,false);
            TestMapping<uint, bool>(1,true);
        }

        [TestMethod]
        public void TestULongToBoolMapping()
        {
            TestMapping<ulong, bool>(ulong.MaxValue,true);
            TestMapping<ulong, bool>(0,false);
            TestMapping<ulong, bool>(1,true);
        }

        [TestMethod]
        public void TestUShortToBoolMapping()
        {
            TestMapping<ushort, bool>(ushort.MaxValue,true);
            TestMapping<ushort, bool>(0,false);
            TestMapping<ushort, bool>(1,true);
        }

        [TestMethod]
        public void TestLongToBoolMapping()
        {
            TestMapping<long, bool>(long.MaxValue,true);
            TestMapping<long, bool>(long.MinValue,true);
            TestMapping<long, bool>(0,false);
            TestMapping<long, bool>(-1, true);
        }

        [TestMethod]
        public void TestByteToBoolMapping()
        {
            TestMapping<byte, bool>(byte.MaxValue,true);
            TestMapping<byte, bool>(0,false);
            TestMapping<byte, bool>(1,true);
        }

        [TestMethod]
        public void TestCharToBoolMapping()
        {
            TestMapping<char, bool>((char)0,false);
            TestMapping<char, bool>('A', true);
            TestMapping<char, bool>(char.MaxValue, true);
        }

        [TestMethod]
        public void TestDoubleToBoolMapping()
        {
            TestMapping<double, bool>(double.MaxValue, true);
            TestMapping<double, bool>(double.MinValue, true);
            TestMapping<double, bool>(0,false);
            TestMapping<double, bool>(0.2, true);
            TestMapping<double, bool>(0.4999, true);
            TestMapping<double, bool>(0.5, true);
            TestMapping<double, bool>(0.5001, true);
            TestMapping<double, bool>(0.7, true);
            TestMapping<double, bool>(1e-29, true);
            TestMapping<double, bool>(1, true);
            TestMapping<double, bool>(1.5, true);
            TestMapping<double, bool>(-1, true);
            TestMapping<double, bool>(-1.5, true);
            TestMapping<double, bool>(213.244, true);
        }

        [TestMethod]
        public void TestDecimalToBoolMapping()
        {
            TestMapping<decimal, bool>(decimal.MinValue, true);
            TestMapping<decimal, bool>(decimal.MaxValue, true);
            TestMapping<decimal, bool>(0,false);
            TestMapping<decimal, bool>(0.2M, true);
            TestMapping<decimal, bool>(0.4999M, true);
            TestMapping<decimal, bool>(0.5M, true);
            TestMapping<decimal, bool>(0.5001M, true);
            TestMapping<decimal, bool>(0.7M, true);
            TestMapping<decimal, bool>(1, true);
            TestMapping<decimal, bool>(1.5M, true);
            TestMapping<decimal, bool>(-1, true);
            TestMapping<decimal, bool>(-1.5M, true);
            TestMapping<decimal, bool>(213.244M, true);
        }

        [TestMethod]       
        public void TestFloatToBoolMapping()
        {
            TestMapping<float, bool>(float.MinValue, true);
            TestMapping<float, bool>(float.MaxValue, true);
            TestMapping<float, bool>(0,false);
            TestMapping<float, bool>(0.2f, true);
            TestMapping<float, bool>(0.4999f, true);
            TestMapping<float, bool>(0.5f, true);
            TestMapping<float, bool>(0.5001f, true);
            TestMapping<float, bool>(0.7f, true);
            TestMapping<float, bool>(1,true);
            TestMapping<float, bool>(1.5f, true);
            TestMapping<float, bool>(-1, true);
            TestMapping<float, bool>(-1.5f, true);
            TestMapping<float, bool>(213.24f, true);
        }

        [TestMethod]
        public void TestDateTimeToBoolMapping()
        {   TestMapping<DateTime, bool>(new DateTime(2001,1,10), true);
            TestMapping<DateTime, bool>(DateTime.MaxValue, true);
            TestMapping<DateTime, bool>(DateTime.Now, true);
            TestMapping<DateTime, bool>(DateTime.MinValue, false);
        }

        [TestMethod]
        public void TestStringToBoolMapping()
        {
            TestMapping<string, bool>(null, false);
            TestMapping<string, bool>("0", false);
            TestMapping<string, bool>(" ", false);
            TestMapping<string, bool>(string.Empty, false);
            TestMapping<string, bool>("sdfsdf", true);
            TestMapping<string, bool>("a", true);
            TestMapping<string, bool>("true", true);
            TestMapping<string, bool>("TRUE", true);
            TestMapping<string, bool>("True", true);
            TestMapping<string, bool>("false", false);
            TestMapping<string, bool>("FALSE", false);
            TestMapping<string, bool>("fAlse", false);
            TestMapping<string, bool>("False", false);
            TestMapping<string, bool>("0.0", true);
            TestMapping<string, bool>("1", true);
        }

        [TestMethod]
        public void TestObjectToBoolMapping()
        {
            TestMapping<object, bool>("sdas", true);
            TestMapping<object, bool>(null, false);
            TestMapping<object, bool>(2, true);
            TestMapping<object, bool>(0, false);
            TestMapping<object, bool>(new int?(), false);
            TestMapping<object, bool>((int?)1, true);
            TestMapping<object, bool>((int?)0, false);
            TestMapping<object, bool>(1.2e2, true);
            TestMapping<object, bool>((SimpleEnumSource)0, false);
            TestMapping<object, bool>(SimpleEnumSource.a , true);
            TestMapping<object, bool>(new SimpleSourceClass() {a=10},true);
            TestMapping<object, bool>(new SimpleSourceStruct(), false);
        }

        [TestMethod]
        public void TestTimeSpanToBoolMapping()
        {
            TestMapping<TimeSpan, bool>(TimeSpan.MaxValue,true);
            TestMapping<TimeSpan, bool>(new TimeSpan(101), true);
            TestMapping<TimeSpan, bool>(new TimeSpan(0), false);
            TestMapping<TimeSpan, bool>(TimeSpan.MinValue, true);
        }

        [TestMethod]
        public void TestGuidToBoolMapping()
        {
            TestMapping<Guid, bool>(Guid.Empty,false);            
            TestMapping<Guid, bool>(Guid.NewGuid(),true);
        }
    }
}
