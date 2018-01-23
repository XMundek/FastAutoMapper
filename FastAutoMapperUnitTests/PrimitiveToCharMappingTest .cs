using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Moon.FastAutoMapper.UnitTest
{
    [TestClass]
    public class PrimitiveToChartMappingTest : BaseMappingTest
    {
        [TestMethod]
        public void TestCharToCharMapping()
        {
            TestMapping<char, char>('A');
        }

        [TestMethod]
        public void TestIntToCharMapping()
        {
            TestMapping<int, char>(int.MinValue,'\0');
            TestMapping<int, char>(int.MaxValue,'\0');
            TestMapping<int, char>(char.MaxValue + 1, '\0');
            TestMapping<int, char>(char.MaxValue - 1,(char)(char.MaxValue - 1));
            TestMapping<int, char>(0, '\0');
            TestMapping<int, char>(1, (char)1);
            TestMapping<int, char>(-1, '\0');
            TestMapping<int, char>('a', 'a');
            TestMapping<int, char>(2131, (char)2131);
        }

        [TestMethod]
        public void TestShortToCharMapping()
        {
            TestMapping<short, char>(short.MinValue,'\0');
            TestMapping<short, char>(short.MaxValue,(char)short.MaxValue);
            TestMapping<short, char>(0, '\0');
            TestMapping<short, char>(1, (char)1);
            TestMapping<short, char>(-1, '\0');
            TestMapping<short, char>((short)'a', 'a');
            TestMapping<short, char>(21312, (char)21312);
        }

        [TestMethod]
        public void TestSByteToCharMapping()
        {
            TestMapping<sbyte, char>(sbyte.MinValue, '\0');
            TestMapping<sbyte, char>(sbyte.MaxValue,(char) sbyte.MaxValue);
            TestMapping<sbyte, char>(0,'\0');
            TestMapping<sbyte, char>(1,(char)1);
            TestMapping<sbyte, char>(-1, '\0');
            TestMapping<sbyte, char>((sbyte)'a', 'a');
            TestMapping<sbyte, char>(21, (char)21);
        }

        [TestMethod]
        public void TestUIntToCharMapping()
        {
            TestMapping<uint, char>(uint.MaxValue, '\0');
            TestMapping<uint, char>(char.MaxValue, char.MaxValue);
            TestMapping<uint, char>(0, '\0');
            TestMapping<uint, char>(1,(char)1);
            TestMapping<uint, char>(2131,(char)2131);
            TestMapping<uint, char>('a', 'a');
        }

        [TestMethod]
        public void TestULongToCharMapping()
        {
            TestMapping<ulong, char>(ulong.MaxValue, '\0');
            TestMapping<ulong, char>(char.MaxValue,char.MaxValue);
            TestMapping<ulong, char>(0, '\0');
            TestMapping<ulong, char>(1,(char)1);
            TestMapping<ulong, char>(21312, (char)21312);
            TestMapping<ulong, char>('a', 'a');
        }

        [TestMethod]
        public void TestByteToCharMapping()
        {
            for (var i = 0; i <= byte.MaxValue;i++)
                TestMapping<byte, char>((byte)i, (char)i);
        }

        [TestMethod]
        public void TestLongToCharMapping()
        {
            TestMapping<long, char>(long.MaxValue, '\0');
            TestMapping<long, char>(long.MinValue, '\0');
            TestMapping<long, char>(char.MaxValue, char.MaxValue);
            TestMapping<long, char>(0, '\0');
            TestMapping<long, char>(-1, '\0');
            TestMapping<long, char>(21312, (char)21312);
        }

        [TestMethod]
        public void TestBoolToCharMapping()
        {
            TestMapping<bool, char>(true,(char)1);
            TestMapping<bool, char>(false, '\0');
        }

        [TestMethod]
        public void TestUShortToCharMapping()
        {
            for (int i = 0; i <= ushort.MaxValue; i++)
                TestMapping<ushort, char>((ushort)i, (char)i);
        }

        [TestMethod]
        public void TestDoubleToCharMapping()
        {
            TestMapping<double, char>(double.MaxValue, '\0');
            TestMapping<double, char>(double.MinValue, '\0');
            TestMapping<double, char>(char.MaxValue, char.MaxValue);
            TestMapping<double, char>(0, '\0');
            TestMapping<double, char>(0.2, '\0');
            TestMapping<double, char>(0.4999, '\0');
            TestMapping<double, char>(0.5, '\0');
            TestMapping<double, char>(0.5001, (char)1);
            TestMapping<double, char>(0.7, (char)1);
            TestMapping<double, char>(1,(char)1);
            TestMapping<double, char>(1.5, (char)2);
            TestMapping<double, char>(-1, '\0');
            TestMapping<double, char>(-1.5, '\0');
            TestMapping<double, char>(21312.244, (char)21312);
            TestMapping<double, char>('a', 'a');
        }

        [TestMethod]
        public void TestDecimalToCharMapping()
        {
            TestMapping<decimal, char>(decimal.MaxValue, '\0');
            TestMapping<decimal, char>(decimal.MinValue, '\0');
            TestMapping<decimal, char>(char.MaxValue, char.MaxValue);
            TestMapping<decimal, char>(0, '\0');
            TestMapping<decimal, char>(0.2M, '\0');
            TestMapping<decimal, char>(0.4999M, '\0');
            TestMapping<decimal, char>(0.5M, '\0');
            TestMapping<decimal, char>(0.5001M, (char)1);
            TestMapping<decimal, char>(0.7M, (char)1);
            TestMapping<decimal, char>(1, (char)1);
            TestMapping<decimal, char>(1.5M, (char)2);
            TestMapping<decimal, char>(-1, '\0');
            TestMapping<decimal, char>(-1.5M, '\0');
            TestMapping<decimal, char>(21312.244M, (char)21312);
            TestMapping<decimal, char>('a', 'a');
        }

        [TestMethod]       
        public void TestFloatToCharMapping()
        {
            TestMapping<float, char>(float.MaxValue, '\0');
            TestMapping<float, char>(float.MinValue, '\0');
            TestMapping<float, char>(char.MaxValue, char.MaxValue);
            TestMapping<float, char>(0, '\0');
            TestMapping<float, char>(0.2f, '\0');
            TestMapping<float, char>(0.4999f, '\0');
            TestMapping<float, char>(0.5f, '\0');
            TestMapping<float, char>(0.5001f, (char)1);
            TestMapping<float, char>(0.7f, (char)1);
            TestMapping<float, char>(1, (char)1);
            TestMapping<float, char>(1.5f, (char)2);
            TestMapping<float, char>(-1f, '\0');
            TestMapping<float, char>(-1.5f, '\0');
            TestMapping<float, char>(21312.244f, (char)21312);
            TestMapping<float, char>('a', 'a');
        }

        [TestMethod]
        public void TestDateTimeToCharMapping()
        {
            TestMapping<DateTime, char>(new DateTime(1001), (char)1001);
            TestMapping<DateTime, char>(new DateTime('a'), 'a');
            TestMapping<DateTime, char>(DateTime.MaxValue, '\0');
            TestMapping<DateTime, char>(DateTime.MinValue, '\0');
        }

        [TestMethod]
        public void TestStringToCharMapping()
        {
            TestMapping<string, char>("-20", '-');
            TestMapping<string, char>("21.1", '2');
            TestMapping<string, char>(null, '\0');
            TestMapping<string, char>(string.Empty, '\0');
            TestMapping<string, char>(" ", ' ');
            TestMapping<string, char>("A", 'A');
            TestMapping<string, char>("#s3d", '#');
        }

        [TestMethod]
        public void TestObjectToCharMapping()
        {
            TestMapping<object, char>("20", '2');
            TestMapping<object, char>(41, (char)41);
            TestMapping<object, char>(char.MaxValue);
            TestMapping<object, char>(1.2e2, (char)120);
            TestMapping<object, char>(SimpleEnumSource.a , (char)SimpleEnumSource.a);
            TestMapping<object, char>(new SimpleSourceClass() {a=10},'\0');
        }

        [TestMethod]
        public void TestTimeSpanToCharMapping()
        {
            TestMapping<TimeSpan, char>(TimeSpan.MaxValue, '\0');
            TestMapping<TimeSpan, char>(TimeSpan.MinValue, '\0');
            TestMapping<TimeSpan, char>(new TimeSpan(1001), (char)1001);
            TestMapping<TimeSpan, char>(new TimeSpan('A'), 'A');
        }

        [TestMethod]
        public void TestGuidToCharMapping()
        {
            TestMapping<Guid, char>(Guid.Empty, '\0');
            var guid = Guid.NewGuid();
            TestMapping<Guid, char>(guid, BitConverter.ToChar(guid.ToByteArray(), 0));
        }
    }
}
