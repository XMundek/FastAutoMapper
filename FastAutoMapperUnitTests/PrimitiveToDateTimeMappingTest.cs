using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Moon.FastAutoMapper.UnitTest
{
    [TestClass]
    public class PrimitiveToDateTimeMappingTest : BaseMappingTest
    {
        [TestMethod]
        public void TestDateTimeToDateTimeMapping()
        {
            TestMapping<DateTime, DateTime>(DateTime.Now);
        }

        [TestMethod]
        public void TestIntToDateTimeMapping()
        {
            TestMapping<int, DateTime>(int.MinValue,DateTime.MinValue);
            TestMapping<int, DateTime>(int.MaxValue,new DateTime(int.MaxValue));
            TestMapping<int, DateTime>(0,new DateTime(0));
            TestMapping<int, DateTime>(1, new DateTime(1)); 
            TestMapping<int, DateTime>(-1,DateTime.MinValue);
        }

        [TestMethod]
        public void TestShortToDateTimeMapping()
        {
            TestMapping<short, DateTime>(short.MinValue, DateTime.MinValue);
            TestMapping<short, DateTime>(short.MaxValue, new DateTime(short.MaxValue));
            TestMapping<short, DateTime>(0, new DateTime(0));
            TestMapping<short, DateTime>(1, new DateTime(1));
            TestMapping<short, DateTime>(-1, DateTime.MinValue);
        }

        [TestMethod]
        public void TestSByteToDateTimeMapping()
        {
            TestMapping<sbyte, DateTime>(sbyte.MinValue, DateTime.MinValue);
            TestMapping<sbyte, DateTime>(sbyte.MaxValue, new DateTime(sbyte.MaxValue));
            TestMapping<sbyte, DateTime>(0, new DateTime(0));
            TestMapping<sbyte, DateTime>(1, new DateTime(1));
            TestMapping<sbyte, DateTime>(-1, DateTime.MinValue);
        }

        [TestMethod]
        public void TestUIntToDateTimeMapping()
        {
            TestMapping<uint, DateTime>(uint.MaxValue, new DateTime(uint.MaxValue));
            TestMapping<uint, DateTime>(0, new DateTime(0));
            TestMapping<uint, DateTime>(1, new DateTime(1));
        }

        [TestMethod]
        public void TestULongToDateTimeMapping()
        {
            TestMapping<ulong, DateTime>(ulong.MaxValue,DateTime.MinValue);
            TestMapping<ulong, DateTime>((ulong)DateTime.MaxValue.Ticks,DateTime.MaxValue);
            TestMapping<ulong, DateTime>(0, new DateTime(0));
            TestMapping<ulong, DateTime>(1, new DateTime(1));
        }

        [TestMethod]
        public void TestByteToDateTimeMapping()
        {
            TestMapping<byte, DateTime>(byte.MaxValue, new DateTime(byte.MaxValue));
            TestMapping<byte, DateTime>(0, new DateTime(0));
            TestMapping<byte, DateTime>(1, new DateTime(1));
        }

        [TestMethod]
        public void TestLongToDateTimeMapping()
        {
            TestMapping<long, DateTime>(long.MaxValue, DateTime.MinValue);
            TestMapping<long, DateTime>(DateTime.MaxValue.Ticks+1, DateTime.MinValue);
            TestMapping<long, DateTime>(DateTime.MaxValue.Ticks, DateTime.MaxValue);
            TestMapping<long, DateTime>(0, new DateTime(0));
            TestMapping<long, DateTime>(1, new DateTime(1));
            TestMapping<long, DateTime>(long.MinValue, DateTime.MinValue);

        }

        [TestMethod]
        public void TestBoolToDateTimeMapping()
        {
            TestMapping<bool, DateTime>(true, new DateTime(1));
            TestMapping<bool, DateTime>(false, new DateTime(0));
        }

        [TestMethod]
        public void TestCharToDateTimeMapping()
        {
            TestMapping<char, DateTime>((char)0, new DateTime(0));
            TestMapping<char, DateTime>('A', new DateTime('A'));
        }

        [TestMethod]
        public void TestDoubleToDateTimeMapping()
        {
            TestMapping<double, DateTime>(double.MaxValue, DateTime.MinValue);
            TestMapping<double, DateTime>(0, new DateTime(0));
            TestMapping<double, DateTime>(1, new DateTime(1));
            TestMapping<double, DateTime>(double.MinValue, DateTime.MinValue);
            TestMapping<double, DateTime>(0.4999, new DateTime(1));
            TestMapping<double, DateTime>(0.5, new DateTime(0));
            TestMapping<double, DateTime>(0.5001, new DateTime(1));
            TestMapping<double, DateTime>(-1.5, DateTime.MinValue);
        }

        [TestMethod]
        public void TestDecimalToDateTimeMapping()
        {
            TestMapping<decimal, DateTime>(decimal.MaxValue, DateTime.MinValue);
            TestMapping<decimal, DateTime>(DateTime.MaxValue.Ticks + 1, DateTime.MinValue);
            TestMapping<decimal, DateTime>(DateTime.MaxValue.Ticks, DateTime.MaxValue);
            TestMapping<decimal, DateTime>(0, new DateTime(0));
            TestMapping<decimal, DateTime>(1, new DateTime(1));
            TestMapping<decimal, DateTime>(decimal.MinValue, DateTime.MinValue);
            TestMapping<decimal, DateTime>(0.4999M, new DateTime(1));
            TestMapping<decimal, DateTime>(0.5M, new DateTime(0));
            TestMapping<decimal, DateTime>(0.5001M, new DateTime(1));
            TestMapping<decimal, DateTime>(-1.5M, DateTime.MinValue);
        }

        [TestMethod]
        public void TestFloatToDateTimeMapping()
        {
            TestMapping<float, DateTime>(float.MaxValue, DateTime.MinValue);
            TestMapping<float, DateTime>(0, new DateTime(0));
            TestMapping<float, DateTime>(1, new DateTime(1));
            TestMapping<float, DateTime>(float.MinValue, DateTime.MinValue);
            TestMapping<float, DateTime>(0.4999f, new DateTime(1));
            TestMapping<float, DateTime>(0.5f, new DateTime(0));
            TestMapping<float, DateTime>(0.5001f, new DateTime(1));
            TestMapping<float, DateTime>(-1.5f, DateTime.MinValue);

        }

        [TestMethod]
        public void TestUShortToDateTimeMapping()
        {
            TestMapping<ushort, DateTime>(ushort.MaxValue, new DateTime(ushort.MaxValue));
            TestMapping<ushort, DateTime>(0, new DateTime(0));
            TestMapping<ushort, DateTime>(1, new DateTime(1));
        }

        [TestMethod]
        public void TestStringToDateTimeMapping()
        {
            TestMapping<string, DateTime>("2001-01-02 13:23:22", new DateTime(2001,1,2,13,23,22));
            TestMapping<string, DateTime>("2001-02-01 13:23:22", new DateTime(2001, 2, 1, 13, 23, 22));
            TestMapping<string, DateTime>("2001-02-01", new DateTime(2001, 2, 1));
            TestMapping<string, DateTime>("2001/01/02 13:23:22", new DateTime(2001, 1, 2, 13, 23, 22));
            TestMapping<string, DateTime>("2001/02/01 13:23:22", new DateTime(2001, 2, 1, 13, 23, 22));
            TestMapping<string, DateTime>("2001/02/01", new DateTime(2001, 2, 1));
            TestMapping<string, DateTime>("2001.01.02 13:23:22", new DateTime(2001, 1, 2, 13, 23, 22));
            TestMapping<string, DateTime>("2001.02.01 13:23:22", new DateTime(2001, 2, 1, 13, 23, 22));
            TestMapping<string, DateTime>("2001.02.01", new DateTime(2001, 2, 1));
            TestMapping<string, DateTime>("2001-01-02 13:20", new DateTime(2001, 1, 2, 13, 20, 0));
            TestMapping<string, DateTime>("2001.02.30 13:23:22", DateTime.MinValue);
            TestMapping<string, DateTime>("2001.02 13:23", DateTime.MinValue);
            TestMapping<string, DateTime>("2001.02 13:23", DateTime.MinValue);
            TestMapping<string, DateTime>("04/10/2008 06:30:00 PM", new DateTime(2008, 4, 10, 18, 30, 0));
            TestMapping<string, DateTime>("Thursday, April 10, 2008 1:30:00 PM", new DateTime(2008, 4, 10, 13, 30, 0));
            var dt = DateTime.Now;
            TestMapping<string, DateTime>("13:23:22", new DateTime(dt.Year, dt.Month, dt.Day, 13, 23, 22));
            TestMapping<string, DateTime>(null, DateTime.MinValue);
            TestMapping<string, DateTime>("0", DateTime.MinValue);
            TestMapping<string, DateTime>(" ", DateTime.MinValue);
            TestMapping<string, DateTime>("sdfsdf", DateTime.MinValue);
        }

        [TestMethod]
        public void TestObjectToDateTimeMapping()
        {
            TestMapping<object, DateTime>("2010-01-02", new DateTime(2010,01,02));
            TestMapping<object, DateTime>(21, new DateTime(21));
            TestMapping<object, DateTime>(DateTime.Now);
            TestMapping<object, DateTime>(1.2e2, new DateTime(120));
            TestMapping<object, DateTime>(SimpleEnumSource.a , new DateTime((long)SimpleEnumSource.a));
            TestMapping<object, DateTime>(new SimpleSourceClass() {a=10},DateTime.MinValue);
        }

        [TestMethod]
        public void TestTimeSpanToDateTimeMapping()
        {
            TestMapping<TimeSpan, DateTime>(TimeSpan.MaxValue,DateTime.MinValue);
            TestMapping<TimeSpan, DateTime>(TimeSpan.MinValue, DateTime.MinValue);
            TestMapping<TimeSpan, DateTime>(TimeSpan.Zero, DateTime.MinValue);
            TestMapping<TimeSpan, DateTime>(new TimeSpan(10,20,30), new DateTime(1,1,1,10,20,30));
            TestMapping<TimeSpan, DateTime>(new TimeSpan(1), new DateTime(1));
            TestMapping<TimeSpan, DateTime>(new TimeSpan(DateTime.MaxValue.Ticks), DateTime.MaxValue);
            TestMapping<TimeSpan, DateTime>(new TimeSpan(DateTime.MaxValue.Ticks+1), DateTime.MinValue);
        }

        [TestMethod]
        public void TestGuidToDateTimeMapping()
        {
            TestMapping<Guid, DateTime>(Guid.Empty,DateTime.MinValue);
            var dt = DateTime.Now;
            TestMapping<Guid, DateTime>(ToGuid(BitConverter.GetBytes(dt.Ticks)), dt);
            TestMapping<Guid, DateTime>(ToGuid(BitConverter.GetBytes(DateTime.MaxValue.Ticks)), DateTime.MaxValue);
        }        
    }
}
