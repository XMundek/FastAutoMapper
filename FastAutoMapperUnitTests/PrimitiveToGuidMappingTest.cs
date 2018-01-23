using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Moon.FastAutoMapper.UnitTest
{
    [TestClass]
    public class PrimitiveToGuidMappingTest : BaseMappingTest
    {
        [TestMethod]
        public void TestGuidToGuidMapping()
        {            
            TestMapping<Guid, Guid>(Guid.NewGuid());
            TestMapping<Guid, Guid>(Guid.Empty);
        }

        [TestMethod]
        public void TestIntToGuidMapping()
        {
            TestMapping<int,Guid>(int.MinValue,ToGuid(BitConverter.GetBytes(int.MinValue)));
            TestMapping<int,Guid>(int.MaxValue,ToGuid(BitConverter.GetBytes(int.MaxValue)));
            TestMapping<int, Guid>(-1, ToGuid(BitConverter.GetBytes(-1)));
            TestMapping<int, Guid>(1, ToGuid(BitConverter.GetBytes(1)));
            TestMapping<int, Guid>(0,Guid.Empty);
        }

        [TestMethod]
        public void TestShortToGuidMapping()
        {
            TestMapping<short, Guid>(short.MinValue, ToGuid(BitConverter.GetBytes(short.MinValue)));
            TestMapping<short, Guid>(short.MaxValue, ToGuid(BitConverter.GetBytes(short.MaxValue)));
            TestMapping<short, Guid>(-1, ToGuid(BitConverter.GetBytes((short)-1)));
            TestMapping<short, Guid>(1, ToGuid(BitConverter.GetBytes((short)1)));
            TestMapping<short, Guid>(0, Guid.Empty);
        }

        [TestMethod]
        public void TestSByteToGuidMapping()
        {
            TestMapping<sbyte, Guid>(sbyte.MinValue, ToGuid(BitConverter.GetBytes(128)));
            TestMapping<sbyte, Guid>(sbyte.MaxValue, ToGuid(BitConverter.GetBytes((byte)sbyte.MaxValue)));
            TestMapping<sbyte, Guid>(1, ToGuid(BitConverter.GetBytes(1)));
            TestMapping<sbyte, Guid>(0, Guid.Empty);
        }

        [TestMethod]
        public void TestUShortTGuidMapping()
        {
            TestMapping<ushort, Guid>(ushort.MaxValue, ToGuid(BitConverter.GetBytes(ushort.MaxValue)));
            TestMapping<ushort, Guid>(1, ToGuid(BitConverter.GetBytes((ushort)1)));
            TestMapping<ushort, Guid>(0, Guid.Empty);
        }

        [TestMethod]
        public void TestByteToGuidMapping()
        {
            TestMapping<byte, Guid>(byte.MaxValue, ToGuid(BitConverter.GetBytes(byte.MaxValue)));
            TestMapping<byte, Guid>(1, ToGuid(BitConverter.GetBytes((byte)1)));
            TestMapping<byte, Guid>(0, Guid.Empty);
        }

        [TestMethod]
        public void TestLongToGuidMapping()
        {
            TestMapping<long, Guid>(long.MaxValue, ToGuid(BitConverter.GetBytes(long.MaxValue)));
            TestMapping<long, Guid>(long.MinValue, ToGuid(BitConverter.GetBytes(long.MinValue)));
            TestMapping<long,Guid>(132423234, ToGuid(BitConverter.GetBytes(((long)132423234))));
            TestMapping<long, Guid>(0, Guid.Empty);
        }
        [TestMethod]
        public void TestUIntToGuidMapping()
        {
            TestMapping<uint, Guid>(uint.MaxValue, ToGuid(BitConverter.GetBytes(uint.MaxValue)));
            TestMapping<uint, Guid>(1, ToGuid(BitConverter.GetBytes((uint)1)));
            TestMapping<uint, Guid>(0, Guid.Empty);
        }
        [TestMethod]
        public void TestBoolToGuidMapping()
        {
            TestMapping<bool, Guid>(true, ToGuid(BitConverter.GetBytes(1)));
            TestMapping<bool, Guid>(false, Guid.Empty);
        }

        [TestMethod]
        public void TestCharToGuidMapping()
        {
            TestMapping<char, Guid>((char)0,Guid.Empty);
            TestMapping<char, Guid>('A', ToGuid(BitConverter.GetBytes((uint)'A')));
        }

        [TestMethod]
        public void TestDoubleToGuidMapping()
        {
            TestMapping<double, Guid>(double.MaxValue, Guid.Empty);
            TestMapping<double, Guid>(double.MinValue, Guid.Empty);
            TestMapping<double, Guid>(0, Guid.Empty);
            TestMapping<double, Guid>(0.2, Guid.Empty);
            TestMapping<double, Guid>(0.4999, Guid.Empty);
            TestMapping<double, Guid>(0.5,Guid.Empty);
            TestMapping<double, Guid>(0.5001, ToGuid(BitConverter.GetBytes(1L)));
            TestMapping<double, Guid>(0.7, ToGuid(BitConverter.GetBytes(1L)));
            TestMapping<double, Guid>(1, ToGuid(BitConverter.GetBytes(1L)));
            TestMapping<double, Guid>(1.5, ToGuid(BitConverter.GetBytes(2L)));
            TestMapping<double, Guid>(-1, ToGuid(BitConverter.GetBytes(-1L)));
            TestMapping<double, Guid>(-1.5, ToGuid(BitConverter.GetBytes(-2L)));
            TestMapping<double, Guid>(213123323453345.244, ToGuid(BitConverter.GetBytes(213123323453345)));
        }

        [TestMethod]
        public void TestDecimalToGuidMapping()
        {
            TestMapping<decimal, Guid>(decimal.MaxValue, Guid.Empty);
            TestMapping<decimal, Guid>(decimal.MinValue, Guid.Empty);
            TestMapping<decimal, Guid>(0, Guid.Empty);
            TestMapping<decimal, Guid>(0.2M, Guid.Empty);
            TestMapping<decimal, Guid>(0.4999M, Guid.Empty);
            TestMapping<decimal, Guid>(0.5M, Guid.Empty);
            TestMapping<decimal, Guid>(0.5001M, ToGuid(BitConverter.GetBytes(1L)));
            TestMapping<decimal, Guid>(0.7M, ToGuid(BitConverter.GetBytes(1L)));
            TestMapping<decimal, Guid>(1, ToGuid(BitConverter.GetBytes(1L)));
            TestMapping<decimal, Guid>(1.5M, ToGuid(BitConverter.GetBytes(2L)));
            TestMapping<decimal, Guid>(-1, ToGuid(BitConverter.GetBytes(-1L)));
            TestMapping<decimal, Guid>(-1.5M, ToGuid(BitConverter.GetBytes(-2L)));
            TestMapping<decimal, Guid>(213123323453345.244M, ToGuid(BitConverter.GetBytes(213123323453345)));
        }

        [TestMethod]       
        public void TestFloatToGuidMapping()
        {
            TestMapping<float, Guid>(float.MaxValue, Guid.Empty);
            TestMapping<float, Guid>(float.MinValue, Guid.Empty);
            TestMapping<float, Guid>(0, Guid.Empty);
            TestMapping<float, Guid>(0.2f, Guid.Empty);
            TestMapping<float, Guid>(0.4999f, Guid.Empty);
            TestMapping<float, Guid>(0.5f, Guid.Empty);
            TestMapping<float, Guid>(0.5001f, ToGuid(BitConverter.GetBytes(1L)));
            TestMapping<float, Guid>(0.7f, ToGuid(BitConverter.GetBytes(1L)));
            TestMapping<float, Guid>(1, ToGuid(BitConverter.GetBytes(1L)));
            TestMapping<float, Guid>(1.5f, ToGuid(BitConverter.GetBytes(2L)));
            TestMapping<float, Guid>(-1, ToGuid(BitConverter.GetBytes(-1L)));
            TestMapping<float, Guid>(-1.5f, ToGuid(BitConverter.GetBytes(-2L)));
            TestMapping<float, Guid>(2131.244f, ToGuid(BitConverter.GetBytes(2131L)));
        }

        [TestMethod]
        public void TestDateTimeToGuidMapping()
        {
            TestMapping<DateTime, Guid>(DateTime.MaxValue, ToGuid(BitConverter.GetBytes(DateTime.MaxValue.Ticks)));
            TestMapping<DateTime, Guid>(DateTime.MinValue, Guid.Empty);
            var dt = new DateTime(2010, 3, 4, 2, 33, 3);
            TestMapping<DateTime, Guid>(dt, ToGuid(BitConverter.GetBytes(dt.Ticks)));
        }

        [TestMethod]
        public void TestStringToGuidMapping()
        {
            var guid = Guid.NewGuid();
            TestMapping<string, Guid>(guid.ToString(), guid);
            TestMapping<string, Guid>(Guid.Empty.ToString(),Guid.Empty);
            TestMapping<string, Guid>("1.2e2", Guid.Empty);
            TestMapping<string, Guid>("232342344823424323", Guid.Empty);
            TestMapping<string, Guid>(null, Guid.Empty);
            TestMapping<string, Guid>("0", Guid.Empty);
            TestMapping<string, Guid>(" ", Guid.Empty);
            TestMapping<string, Guid>("sdfsdf", Guid.Empty);
        }

        [TestMethod]
        public void TestObjectToGuidMapping()
        {
            TestMapping<object , Guid>("20", Guid.Empty);
            TestMapping<object, Guid>(21, ToGuid(BitConverter.GetBytes(21)));
            TestMapping<object, Guid>(Guid.NewGuid());
            TestMapping<object, Guid>(1.2e2, ToGuid(BitConverter.GetBytes(120L)));
            TestMapping<object, Guid>(SimpleEnumSource.a , ToGuid(BitConverter.GetBytes((int)SimpleEnumSource.a)));
            TestMapping<object, Guid>(new SimpleSourceClass() {a=10}, Guid.Empty);
        }

        [TestMethod]
        public void TestTimeSpanToGuidMapping()
        {
            TestMapping<TimeSpan, Guid>(TimeSpan.MaxValue, ToGuid(BitConverter.GetBytes(TimeSpan.MaxValue.Ticks)));
            TestMapping<TimeSpan, Guid>(TimeSpan.MinValue, ToGuid(BitConverter.GetBytes(TimeSpan.MinValue.Ticks)));
            var ts = new TimeSpan(30, 10, 1);
            TestMapping<TimeSpan, Guid>(ts, ToGuid(BitConverter.GetBytes(ts.Ticks)));
            TestMapping<TimeSpan, Guid>(TimeSpan.Zero, Guid.Empty);
        }

        [TestMethod]
        public void TestULongToGuidMapping()
        {
            TestMapping<ulong, Guid>(ulong.MaxValue, ToGuid(BitConverter.GetBytes(ulong.MaxValue)));
            TestMapping<ulong, Guid>(1, ToGuid(BitConverter.GetBytes((uint)1)));
            TestMapping<ulong, Guid>(0, Guid.Empty);
        }
    }
}
