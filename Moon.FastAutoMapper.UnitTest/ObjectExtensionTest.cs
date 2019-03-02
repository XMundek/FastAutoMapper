using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moon.FastAutoMapper.UnitTest.Utils;
namespace Moon.FastAutoMapper.UnitTest
{
    [TestClass]
    public class ObjectExtensionTest
    {

        
        private void TestEqualObjects(object a, object b)
        {
            var result = a.GetObjectDifferences(b);
            Assert.AreEqual(0,result.Count);
        }
        private void TestDifferentObjects(object a, object b)
        {
            var result = a.GetObjectDifferences(b);
            Assert.IsTrue(result.Count>0);
        }

        [TestMethod]
        public void TestIfEqualObjectsAreCheckedCorrectly()
        {
            TestEqualObjects(2,"2");
            TestEqualObjects(null, null);
            var p = new SourcePointClass();
            TestEqualObjects(p,p);
            TestEqualObjects(
                new SourceDerivedClass(){x=20,y=30}, 
                new SourceDerivedClassWithProperty() { x = 20, y = 30 });
            TestEqualObjects(
                new[]{
                    new SourceDerivedClass() { x = 20, y = 30 },
                    new SourceDerivedClass() { x = 40, y = 50 }
                },
                new List < SourceDerivedClassWithProperty>() { 
                    new SourceDerivedClassWithProperty() { x = 20, y = 30 },
                    new SourceDerivedClassWithProperty() { x = 40, y = 50 }
                    });

            TestEqualObjects(
                new Dictionary<int, SourceDerivedClass>() {
                    {1, new SourceDerivedClass() { x = 20, y = 30 }},
                    {4, new SourceDerivedClass() { x = 40, y = 50 }}
                },
                new Dictionary<string, SourceDerivedClassWithProperty>() {
                    {"1", new SourceDerivedClassWithProperty() { x = 20, y = 30 }},
                    {"4", new SourceDerivedClassWithProperty() { x = 40, y = 50 }}
                });
        }
        [TestMethod]
        public void TestIfDifferentObjectsAreCheckedCorrectly()
        {
            TestDifferentObjects(2.1, 2);
            TestDifferentObjects("", null);
            TestDifferentObjects(new SourcePointClass(), new SourcePointClass(){x=1});
            TestDifferentObjects(
                new SourceDerivedClass() { x = 20, y = 30 },
                new SourceDerivedClassWithProperty() { x = 20, y = 31 });
            TestDifferentObjects(
                new[]{
                    new SourceDerivedClass() { x = 21, y = 30 },
                    new SourceDerivedClass() { x = 40, y = 50 }
                },
                new List<SourceDerivedClassWithProperty>() {
                    new SourceDerivedClassWithProperty() { x = 20, y = 30 },
                    new SourceDerivedClassWithProperty() { x = 40, y = 50 }
                });
            TestDifferentObjects(
                new[]{
                    new SourceDerivedClass() { x = 20, y = 30 },
                    new SourceDerivedClass() { x = 40, y = 50 }
                },
                new List<SourceDerivedClassWithProperty>() {
                    new SourceDerivedClassWithProperty() { x = 20, y = 30 },
                    new SourceDerivedClassWithProperty() { x = 40, y = 50 },
                    new SourceDerivedClassWithProperty() { x = 40, y = 50 }
                });
            TestDifferentObjects(
                new[]{
                    new SourceDerivedClass() { x = 20, y = 30 },
                    new SourceDerivedClass() { x = 40, y = 50 }
                },
                2);
            TestDifferentObjects(
                new Dictionary<int, SourceDerivedClass>() {
                    {1, new SourceDerivedClass() { x = 20, y = 30 }},
                    {4, new SourceDerivedClass() { x = 40, y = 50 }}
                },
                new Dictionary<string, SourceDerivedClassWithProperty>() {
                    {"1", new SourceDerivedClassWithProperty() { x = 20, y = 30 }},
                    {"4", new SourceDerivedClassWithProperty() { x = 41, y = 50 }}
                });
            TestDifferentObjects(
                2,
                new Dictionary<string, SourceDerivedClassWithProperty>() {
                    {"1", new SourceDerivedClassWithProperty() { x = 20, y = 30 }},
                    {"4", new SourceDerivedClassWithProperty() { x = 41, y = 50 }}
                });
            TestDifferentObjects(
                new Dictionary<int, SourceDerivedClass>() {
                    {1, new SourceDerivedClass() { x = 20, y = 30 }},
                    {4, new SourceDerivedClass() { x = 40, y = 50 }},
                    {5, new SourceDerivedClass() { x = 40, y = 50 }}
                },
                new Dictionary<string, SourceDerivedClassWithProperty>() {
                    {"1", new SourceDerivedClassWithProperty() { x = 20, y = 30 }},
                    {"4", new SourceDerivedClassWithProperty() { x = 41, y = 50 }}
                });
        }

    }
}