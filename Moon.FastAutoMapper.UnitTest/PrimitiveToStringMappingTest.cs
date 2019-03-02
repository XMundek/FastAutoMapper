using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Moon.FastAutoMapper.UnitTest
{
    [TestClass]
    public class PrimitiveToMappingTest : BaseMappingTest
    {
        [TestMethod]
        public void TeststringToStringMapping()
        {
            TestMapping<string, string>("XXX");
            TestMapping<string, string>(null);
            TestMapping<string, string>(string.Empty);
        }

        [TestMethod]
        public void TestIntToStringMapping()
        {
            TestMapping<int, string>(int.MinValue);
            TestMapping<int, string>(int.MaxValue);
            TestMapping<int, string>(0);
            TestMapping<int, string>(21312);

        }

        [TestMethod]
        public void TestShortToStringMapping()
        {
            TestMapping<short, string>(short.MinValue);
            TestMapping<short, string>(short.MaxValue);
            TestMapping<short, string>(0);
            TestMapping<short, string>(21312);
        }

        [TestMethod]
        public void TestSByteToStringMapping()
        {
            TestMapping<sbyte, string>(sbyte.MinValue);
            TestMapping<sbyte, string>(sbyte.MaxValue);
            TestMapping<sbyte, string>(0);
            TestMapping<sbyte, string>(21);
        }

        [TestMethod]
        public void TestUIntToStringMapping()
        {
            TestMapping<uint, string>(uint.MaxValue);
            TestMapping<uint, string>(0);
            TestMapping<uint, string>(2131);
        }

        [TestMethod]
        public void TestULongToStringMapping()
        {
            TestMapping<ulong, string>(ulong.MaxValue);
            TestMapping<ulong, string>(0);
            TestMapping<ulong, string>(21313453);
        }

        [TestMethod]
        public void TestUShortToStringMapping()
        {
            TestMapping<ushort, string>(ushort.MaxValue);
            TestMapping<ushort, string>(0);
            TestMapping<ushort, string>(2133);
        }


        [TestMethod]
        public void TestByteToStringMapping()
        {
            TestMapping<byte, string>(byte.MaxValue);
            TestMapping<byte, string>(0);
            TestMapping<byte, string>(213);
        }

        [TestMethod]
        public void TestLongToStringMapping()
        {
            TestMapping<long, string>(long.MaxValue);
            TestMapping<long, string>(long.MinValue);
            TestMapping<long, string>(0);
            TestMapping<long, string>(-21313453);
        }

        [TestMethod]
        public void TestBoolToStringMapping()
        {
            TestMapping<bool, string>(true);
            TestMapping<bool, string>(false);
        }

        [TestMethod]
        public void TestCharToStringMapping()
        {
            TestMapping<char, string>((char)0, (object) string.Empty);
            TestMapping<char, string>('A', (object) "A");
        }

        [TestMethod]
        public void TestDoubleToStringMapping()
        {
            TestMapping<double, string>(double.MaxValue, (object) double.MaxValue.ToString(CultureInfo.InvariantCulture));
            TestMapping<double, string>(double.MinValue, (object)double.MinValue.ToString(CultureInfo.InvariantCulture));
            TestMapping<double, string>(0, (object)0d.ToString(CultureInfo.InvariantCulture));
            TestMapping<double, string>(21312.244, (object)21312.244.ToString(CultureInfo.InvariantCulture));
        }

        [TestMethod]
        public void TestDecimalToStringMapping()
        {
            TestMapping<decimal, string>(decimal.MaxValue, (object)decimal.MaxValue.ToString(CultureInfo.InvariantCulture));
            TestMapping<decimal, string>(decimal.MinValue, (object)decimal.MinValue.ToString(CultureInfo.InvariantCulture));
            TestMapping<decimal, string>(0, (object)0M.ToString(CultureInfo.InvariantCulture));
            TestMapping<decimal, string>(21312.244M, (object)21312.244M.ToString(CultureInfo.InvariantCulture));
        }

        [TestMethod]       
        public void TestFloatToStringMapping()
        {
            TestMapping<float, string>(float.MaxValue, (object)float.MaxValue.ToString(CultureInfo.InvariantCulture));
            TestMapping<float, string>(float.MinValue, (object)float.MinValue.ToString(CultureInfo.InvariantCulture));
            TestMapping<float, string>(0, (object)0d.ToString(CultureInfo.InvariantCulture));
            TestMapping<float, string>(21312.244f, (object)21312.244f.ToString(CultureInfo.InvariantCulture));
        }

        [TestMethod]
        public void TestDateTimeToStringMapping()
        {
            TestMapping<DateTime, string>(new DateTime(1001),(object) new DateTime(1001).ToString("HH:mm:ss.FFF"));
            TestMapping<DateTime, string>(new DateTime(2010, 2, 1), (object)"2010-02-01 00:00:00");
            TestMapping<DateTime, string>(new DateTime(2010, 1, 2,13,21,22), (object)"2010-01-02 13:21:22");
            TestMapping<DateTime, string>(DateTime.MaxValue, (object)"9999-12-31 23:59:59.999");
            TestMapping<DateTime, string>(DateTime.MinValue, (object)"00:00:00");            
        }
   
        [TestMethod]
        public void TestObjectToStringMapping()
        {
            TestMapping<object, string>("20",(object)"20");
            TestMapping<object, string>(-21, (object)"-21");
            TestMapping<object, string>(1.2e2, (object)1.2e2.ToString(CultureInfo.InvariantCulture));
            TestMapping<object, string>(SimpleEnumSource.a , (object)SimpleEnumSource.a.ToString());
            var classItem = new SimpleSourceClass() {a = 10};
            TestMapping<object, string>(classItem,(object)classItem.ToString());
        }

        [TestMethod]
        public void TestTimeSpanToStringMapping()
        {
            TestMapping<TimeSpan, string>(TimeSpan.MinValue,(object)TimeSpan.MinValue.ToString());
            TestMapping<TimeSpan, string>(new TimeSpan(0), (object)"00:00:00");
            TestMapping<TimeSpan, string>(new TimeSpan(23,33,35), (object)"23:33:35");
            TestMapping<TimeSpan, string>(new TimeSpan(10, 21, 35, 36,342), (object)"10.21:35:36.3420000");
        }


        [TestMethod]
        public void TestGuidToStringMapping()
        {
            TestMapping<Guid, string>(Guid.Empty,(object)Guid.Empty.ToString());
            var guid = Guid.NewGuid();
            TestMapping<Guid, string>(guid, (object)guid.ToString());
        }
    }
}
