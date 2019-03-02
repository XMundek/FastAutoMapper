using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Moon.FastAutoMapper.UnitTest
{
    [TestClass]
    public class PrimitiveToTimeSpanMappingTest : BaseMappingTest
    {
        [TestMethod]
        public void TestTimeSpanToTimeSpanMapping()
        {
            TestMapping<TimeSpan, TimeSpan>(new TimeSpan(1,20,10,10));
        }

        [TestMethod]
        public void TestIntToTimeSpanMapping()
        {
            TestMapping<int, TimeSpan>(int.MinValue, new TimeSpan(int.MinValue));
            TestMapping<int, TimeSpan>(int.MaxValue,new TimeSpan(int.MaxValue));
            TestMapping<int, TimeSpan>(0,new TimeSpan(0));
            TestMapping<int, TimeSpan>(1, new TimeSpan(1)); 
        }

        [TestMethod]
        public void TestShortToTimeSpanMapping()
        {
            TestMapping<short, TimeSpan>(short.MinValue, new TimeSpan(short.MinValue));
            TestMapping<short, TimeSpan>(short.MaxValue, new TimeSpan(short.MaxValue));
            TestMapping<short, TimeSpan>(0, new TimeSpan(0));
            TestMapping<short, TimeSpan>(1, new TimeSpan(1));
        }

        [TestMethod]
        public void TestSByteToTimeSpanMapping()
        {
            TestMapping<sbyte, TimeSpan>(sbyte.MinValue, new TimeSpan(sbyte.MinValue));
            TestMapping<sbyte, TimeSpan>(sbyte.MaxValue, new TimeSpan(sbyte.MaxValue));
            TestMapping<sbyte, TimeSpan>(0, new TimeSpan(0));
            TestMapping<sbyte, TimeSpan>(1, new TimeSpan(1));
        }

        [TestMethod]
        public void TestUIntToTimeSpanMapping()
        {
            TestMapping<uint, TimeSpan>(uint.MaxValue, new TimeSpan(uint.MaxValue));
            TestMapping<uint, TimeSpan>(0, new TimeSpan(0));
            TestMapping<uint, TimeSpan>(1, new TimeSpan(1));
        }

        [TestMethod]
        public void TestULongToTimeSpanMapping()
        {
            TestMapping<ulong, TimeSpan>(ulong.MaxValue, TimeSpan.Zero);
            TestMapping<ulong, TimeSpan>((ulong)TimeSpan.MaxValue.Ticks, TimeSpan.MaxValue);
            TestMapping<ulong, TimeSpan>(0, new TimeSpan(0));
            TestMapping<ulong, TimeSpan>(1, new TimeSpan(1));
        }

        [TestMethod]
        public void TestByteToTimeSpanMapping()
        {
            TestMapping<byte, TimeSpan>(byte.MaxValue, new TimeSpan(byte.MaxValue));
            TestMapping<byte, TimeSpan>(0, new TimeSpan(0));
            TestMapping<byte, TimeSpan>(1, new TimeSpan(1));
        }

        [TestMethod]
        public void TestLongToTimeSpanMapping()
        {
            TestMapping<long, TimeSpan>(long.MaxValue, TimeSpan.MaxValue);
            TestMapping<long, TimeSpan>(long.MinValue, TimeSpan.MinValue);
            TestMapping<long, TimeSpan>(TimeSpan.MaxValue.Ticks, TimeSpan.MaxValue);
            TestMapping<long, TimeSpan>(TimeSpan.MinValue.Ticks, TimeSpan.MinValue);
            TestMapping<long, TimeSpan>(0, new TimeSpan(0));
            TestMapping<long, TimeSpan>(1, new TimeSpan(1));
        }

        [TestMethod]
        public void TestBoolToTimeSpanMapping()
        {
            TestMapping<bool, TimeSpan>(true, new TimeSpan(1));
            TestMapping<bool, TimeSpan>(false, new TimeSpan(0));
        }

        [TestMethod]
        public void TestCharToTimeSpanMapping()
        {
            TestMapping<char, TimeSpan>((char)0, new TimeSpan(0));
            TestMapping<char, TimeSpan>('A', new TimeSpan('A'));
        }

        [TestMethod]
        public void TestDoubleToTimeSpanMapping()
        {
            TestMapping<double, TimeSpan>(double.MaxValue, TimeSpan.Zero);
            TestMapping<double, TimeSpan>(0, new TimeSpan(0));
            TestMapping<double, TimeSpan>(1, new TimeSpan(1));
            TestMapping<double, TimeSpan>(double.MinValue, TimeSpan.Zero);
            TestMapping<double, TimeSpan>(0.4999, new TimeSpan(0));
            TestMapping<double, TimeSpan>(0.5, new TimeSpan(0));
            TestMapping<double, TimeSpan>(0.5001, new TimeSpan(1));
            TestMapping<double, TimeSpan>(-1.5, new TimeSpan(-2));
        }

        [TestMethod]
        public void TestDecimalToTimeSpanMapping()
        {
            TestMapping<decimal, TimeSpan>(decimal.MaxValue, TimeSpan.Zero);
            TestMapping<decimal, TimeSpan>(0, new TimeSpan(0));
            TestMapping<decimal, TimeSpan>(1, new TimeSpan(1));
            TestMapping<decimal, TimeSpan>(decimal.MinValue, TimeSpan.Zero);
            TestMapping<decimal, TimeSpan>(0.4999M, new TimeSpan(0));
            TestMapping<decimal, TimeSpan>(0.5M, new TimeSpan(0));
            TestMapping<decimal, TimeSpan>(0.5001M, new TimeSpan(1));
            TestMapping<decimal, TimeSpan>(-1.5M, new TimeSpan(-2));
        }

        [TestMethod]
        public void TestFloatToTimeSpanMapping()
        {
            TestMapping<float, TimeSpan>(float.MaxValue, TimeSpan.Zero);
            TestMapping<float, TimeSpan>(0, new TimeSpan(0));
            TestMapping<float, TimeSpan>(1, new TimeSpan(1));
            TestMapping<float, TimeSpan>(float.MinValue, TimeSpan.Zero);
            TestMapping<float, TimeSpan>(0.4999f, new TimeSpan());
            TestMapping<float, TimeSpan>(0.5f, new TimeSpan(0));
            TestMapping<float, TimeSpan>(0.5001f, new TimeSpan(1));
            TestMapping<float, TimeSpan>(-1.5f, new TimeSpan(-2));

        }

        [TestMethod]
        public void TestUShortToTimeSpanMapping()
        {
            TestMapping<ushort, TimeSpan>(ushort.MaxValue, new TimeSpan(ushort.MaxValue));
            TestMapping<ushort, TimeSpan>(0, new TimeSpan(0));
            TestMapping<ushort, TimeSpan>(1, new TimeSpan(1));
        }

        [TestMethod]
        public void TestStringToTimeSpanMapping()
        {
            TestMapping<string, TimeSpan>("13:23:22", new TimeSpan(0,13,23,22));
            TestMapping<string, TimeSpan>("20.13:23:22", new TimeSpan(20, 13, 23, 22));
            TestMapping<string, TimeSpan>("-20.13:23:22", new TimeSpan(-20, -13, -23, -22));
            TestMapping<string, TimeSpan>(TimeSpan.MinValue.ToString(), TimeSpan.MinValue);
            TestMapping<string, TimeSpan>(TimeSpan.MaxValue.ToString(), TimeSpan.MaxValue);
            TestMapping<string, TimeSpan>(null, TimeSpan.Zero);
            TestMapping<string, TimeSpan>("0", TimeSpan.Zero);
            TestMapping<string, TimeSpan>(" ", TimeSpan.Zero);
            TestMapping<string, TimeSpan>("sdfsdf", TimeSpan.Zero);
        }

        [TestMethod]
        public void TestObjectToTimeSpanMapping()
        {
            TestMapping<object, TimeSpan>("10:23:22", new TimeSpan(10,23,22));
            TestMapping<object, TimeSpan>(21, new TimeSpan(21));
            TestMapping<object, TimeSpan>(1.2e2, new TimeSpan(120));
            TestMapping<object, TimeSpan>(SimpleEnumSource.a , new TimeSpan((long)SimpleEnumSource.a));
            TestMapping<object, TimeSpan>(new SimpleSourceClass() {a=10},TimeSpan.Zero);
        }

        [TestMethod]
        public void TestDateTimeToTimeSpanMapping()
        {
            TestMapping<DateTime, TimeSpan>(DateTime.MaxValue, new TimeSpan(DateTime.MaxValue.Ticks));
            TestMapping<DateTime, TimeSpan>(DateTime.MinValue, TimeSpan.Zero);
            var dt = DateTime.Now;
            TestMapping<DateTime, TimeSpan>(dt, new TimeSpan(dt.Ticks));
        }

        [TestMethod]
        public void TestGuidToTimeSpanMapping()
        {
            TestMapping<Guid, TimeSpan>(Guid.Empty,TimeSpan.Zero);
            TestMapping<Guid, TimeSpan>(ToGuid(BitConverter.GetBytes(TimeSpan.MinValue.Ticks)), TimeSpan.MinValue);
            TestMapping<Guid, TimeSpan>(ToGuid(BitConverter.GetBytes(TimeSpan.MaxValue.Ticks)), TimeSpan.MaxValue);
        }        
    }
}
