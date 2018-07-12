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
            IMapper mapper = new Mapper();
            var result = mapper.Map<int,string>(2);
            Assert.AreEqual(result, "2");
        }
        [TestMethod]
        public void TestObjectMappingByInterface()
        {
            IMapper mapper = new Mapper();
            var result = mapper.Map<string>(2);
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