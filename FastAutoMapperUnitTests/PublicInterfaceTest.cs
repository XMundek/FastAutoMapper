using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moon.FastAutoMapper;
namespace Moon.FastAutoMapper.UnitTest
{
    [TestClass]
    public class PublicInterfaceTest
    {
        [TestMethod]
        public void TestStrongTypeMappingByInterface()
        {
            var result = new Mapper().Map<int,string>(2);
            Assert.AreEqual(result, "2");
        }
        [TestMethod]
        public void TestObjectMappingByInterface()
        {
            var result = new Mapper().Map<string>(2);
            Assert.AreEqual(result, "2");
        }
        [TestMethod]
        public void TestStrongTypeMappingByExtension()
        {
            Assert.AreEqual(2.Map<int,string>(), "2");
        }
        [TestMethod]
        public void TestObjectMappingByExtension()
        {
            Assert.AreEqual(2.Map<string>(), "2");
        }

    }
}