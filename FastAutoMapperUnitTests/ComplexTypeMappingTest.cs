using System.Globalization;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Moon.FastAutoMapper.UnitTest
{
    [TestClass]
    public class ComplexTypeMappingTest:BaseMappingTest
    {
        [TestMethod]
        public void TestStructPointMapping()
        {
            TestMapping<SourcePointStruct, DestinationPointStruct>(
                new SourcePointStruct() { x = 21,y=33.4});
        }
        [TestMethod]
        public void TestClassPointMapping()
        {
            TestMapping<SourcePointClass, DestinationPointClass>(
                new SourcePointClass() { x = 21, y = 33.4 });
        }

        [TestMethod]
        public void TestClassPointToStructPointMapping()
        {
            TestMapping<SourcePointClass, DestinationPointStruct>(
                new SourcePointClass() { x = 21, y = 33.4 });
            TestMapping<SourcePointClass, DestinationPointStruct>(
                null,new DestinationPointStruct());
        }

        [TestMethod]
        public void TestStructPointToClassPointMapping()
        {
            TestMapping<SourcePointStruct, DestinationPointClass>(
                new SourcePointStruct() { x = 21, y = 33.4 });
        }
        [TestMethod]
        public void TestStructMapping()
        {
            TestMapping<SimpleSourceStruct, SimpleDestinationStruct>(
                new SimpleSourceStruct() { c = new SimpleSourceClass() { a = 10 } },
                new SimpleDestinationStruct() { c = new SimpleDestinationClass() { a = 10 } });
        }

        [TestMethod]
        public void TestSourcePointToStringMapping()
        {
            TestMapping<SourcePoint, string>(
                new SourcePoint() { x = 10, y = "A" }, expectedResult: "x=10,y=A");
        }

        [TestMethod]
        public void TestSourcePointToDestinationPointMapping()
        {
            TestMapping<SourcePoint, DestinationPoint>(
                new SourcePoint() { x = 10, y = null, a = 3, k = SimpleEnumSource.c },
                new DestinationPoint() { x = 10, y = 0, a = 3, k = (long)SimpleEnumSource.c }
                );
        }

        [TestMethod]
        public void TestDestinationPointToSourcePointMapping()
        {
            TestMapping<DestinationPoint, SourcePoint>(
                new DestinationPoint() { x = 10, y = 20.0, a = 3 },
                new SourcePoint()
                {
                    x = 10,
                    a = 3,
                    y = 20.0.ToString(CultureInfo.InvariantCulture)
                });
        }

        [TestMethod]
        public void TestSourceStructPointToDestinationStructPointMapping()
        {
            TestMapping<SourceStructPoint, DestinationStructPoint>(
                new SourceStructPoint()
                {
                    x = 109,
                    y = "209",
                    a = 31,
                    px = new SourcePoint()
                    {
                        a = 20,
                        k = SimpleEnumSource.c,
                        x = 20,
                        y = "10.1"
                    }
                },
                new DestinationStructPoint()
                {
                    x = 109,
                    y = 209,
                    a = 31,
                    px = new DestinationPoint()
                    {
                        a = 20,
                        k = (int)SimpleEnumSource.c,
                        x = 20,
                        y = 10.1
                    }
                });
        }

        [TestMethod]
        public void TestSourceStructPointToObjectMapping()
        {
            TestMapping<SourceStructPoint, object>(
                new SourceStructPoint() { x = 109, y = "209", a = 31, px = new SourcePoint() });
        }

        [TestMethod]
        public void TestSourcePointToObjectMapping()
        {
            TestMapping<SourcePoint, object>(
                new SourcePoint() { x = 109, y = "209", a = 31 });
        }

        [TestMethod]
        public void TestSourceStructPointToDestinationPointMapping()
        {
            TestMapping<SourceStructPoint, DestinationPoint>(
                new SourceStructPoint() { x = 109, y = "209", a = 31, px = new SourcePoint() });
        }
        [TestMethod]
        public void TestSourcePointToDestinationStructPointMapping()
        {
            TestMapping<SourcePoint, DestinationStructPoint>(
                new SourcePoint() { x = 109, y = "209", a = 31 });
        }
        [TestMethod]
        public void TestSourceClassToDestinationClassWithoutDefaultConstructorMapping()
        {
            TestMapping<SourceClassWithoutDefaultConstructor, DestinationClassWithoutContructor>(
                new SourceClassWithoutDefaultConstructor(1), (DestinationClassWithoutContructor)null);
        }
        [TestMethod]
        public void TestSourceClassToDestinationClassWithAutoPropertyMapping()
        {
            var cultureInfo = Thread.CurrentThread.CurrentCulture;
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            TestMapping<SourceClassWithAutoProperty, DestinationClassWithAutoProperty>(
                    new SourceClassWithAutoProperty()
                    {
                        x = 10,
                        y = 20.1,
                        z = "331.22"
                    }
                );
            Thread.CurrentThread.CurrentCulture = cultureInfo;
        }

        [TestMethod]
        public void TestClassWithEnumFieldToClassWithStringFieldMapping()
        {
            TestMapping<ClassWithEnumField, ClassWithStringField>(
                new ClassWithEnumField{type = SimpleEnumSource.a});
        }

        [TestMethod]
        public void TestClassWithEnumFieldToClassWithObjectFieldMapping()
        {
            TestMapping<ClassWithEnumField, ClassWithObjectField>(
                new ClassWithEnumField { type = SimpleEnumSource.a });
        }

        [TestMethod]
        public void TestClassWithEnumFieldToClassWithIntFieldMapping()
        {
            TestMapping<ClassWithEnumField, ClassWithIntField>(
                new ClassWithEnumField { type = SimpleEnumSource.a },
                new ClassWithIntField(){type=1});
        }

        [TestMethod]
        public void TestClassWithEnumFieldToClassWithNullableEnumFieldMapping()
        {
            TestMapping<ClassWithEnumField, ClassWithNullableEnumField>(
                new ClassWithEnumField { type = SimpleEnumSource.a },
                new ClassWithNullableEnumField { type = SimpleEnumDestination.a });

            TestMapping<ClassWithEnumField, ClassWithNullableEnumField>(
                new ClassWithEnumField { type = SimpleEnumSource.x },
                new ClassWithNullableEnumField { type = null });
        }

        [TestMethod]
        public void TestClassWithNullableEnumFieldToClassWithEnumFieldMapping()
        {
            TestMapping<ClassWithNullableEnumField, ClassWithEnumField>(
                new ClassWithNullableEnumField { type = SimpleEnumDestination.a },
                new ClassWithEnumField() { type = SimpleEnumSource.a });

            TestMapping<ClassWithNullableEnumField, ClassWithEnumField>(
                new ClassWithNullableEnumField { type = null },
                new ClassWithEnumField() { type =SimpleEnumSource.x });
        }

        [TestMethod]
        public void TestClassWithStructFieldToClassWithObjectFieldMapping()
        {
            TestMapping<ClassWithStructField, ClassWithObjectField>(
                new ClassWithStructField() { type =new SourcePointStruct(){x=10, y=20.1} });
        }

        [TestMethod]
        public void TestClassWithIntFieldToClassWithObjectFieldMapping()
        {
            TestMapping<ClassWithIntField, ClassWithObjectField>(
                new ClassWithIntField() { type = 20});
        }
        [TestMethod]
        public void TestClassWithObjectFieldToClassWithIntFieldMapping()
        {
            TestMapping<ClassWithObjectField, ClassWithIntField>(new ClassWithObjectField() { type = 20 });
            TestMapping<ClassWithObjectField, ClassWithIntField>(new ClassWithObjectField() {type = "20"});
            TestMapping<ClassWithObjectField, ClassWithIntField>(new ClassWithObjectField(),new ClassWithIntField());

        }

        [TestMethod]
        public void TestClassWithStringFieldToClassWithEnumFieldMapping()
        {
            TestMapping<ClassWithStringField, ClassWithEnumField>(
                new ClassWithStringField(), new ClassWithEnumField()) ;
            TestMapping<ClassWithStringField, ClassWithEnumField>(
                new ClassWithStringField() {type = "sss"},new ClassWithEnumField());
            TestMapping<ClassWithStringField, ClassWithEnumField>(
                new ClassWithStringField() { type = "a" });
        }
        [TestMethod]
        public void TestClassWithInheritanceAndPublicFieldsMapping()
        {
            TestMapping<SourceDerivedClass, DestinationDerivedClass>(new SourceDerivedClass(){x=20,y=49});
        }
        [TestMethod]
        public void TestClassWithInheritanceAndPrivateFieldsMapping()
        {
            TestMapping<SourceDerivedClassWithProperty, DestinationDerivedClassWithProperty>(
                new SourceDerivedClassWithProperty() { x = 20, y = 49 });
        }

        [TestMethod]
        public void TestClassWithFieldToClassWithPropertyMapping()
        {
            TestMapping<SourceDerivedClass, DestinationDerivedClassWithProperty>(
                new SourceDerivedClass() { x = 20, y = 49 });
        }

        [TestMethod]
        public void TestAnonymousClassToClassWithFieldMapping()
        {
            TestMapping<object, DestinationDerivedClassWithProperty>(
                new { x = 20, y = 49 },
                new SourceDerivedClass() { x = 20, y = 49 },true);
        }

        [TestMethod]
        public void TestEmptyClassToClassWithField()
        {
            TestMapping<EmptyClass, DestinationDerivedClass>(new EmptyClass(),new DestinationDerivedClass());
        }

        [TestMethod]
        public void TestRecurrentStructureInMapping()
        {
            TestMapping<RecurrencyTestSourceClass, RecurrencyTestDestinationClass>(
                new RecurrencyTestSourceClass()
                {
                    Id = 1,
                    Parent = new RecurrencyTestSourceClass() { Id=2}
                });
        }


    }
}