using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Moon.FastAutoMapper.UnitTest
{
    [TestClass]
    public class CustomMappingTest : BaseMappingTest
    {
        private static readonly SourcePerson sourcePerson = new SourcePerson("Fasola", "Jasio")
        {
            Address = new SourceAddress()
            {
                AddressLine1 = "ul.Blotna",
                AddressLine2 = "20-292 Wygwizdow Dolny"
            }
        };
        private static readonly DestinationPerson expectedPerson = new DestinationPerson()
        {
            LastName = "Fasola",
            FirstName = "Jasio",
            Address = new DestinationAddress()
            {
                Street = "ul.Blotna",
                PostalCode = "20-292",
                City = "Wygwizdow Dolny",
            }
        };

        [TestMethod]
        public void TestMappingCultureChange()
        {
            var defaultMappingCulture = Mapper.MappingCulture;
            var newMappingCulture = new CultureInfo("pl-PL");
            Mapper.MappingCulture = newMappingCulture;
            var changedCulture = Mapper.MappingCulture;
            Mapper.MappingCulture = defaultMappingCulture;
            Assert.AreEqual(newMappingCulture, changedCulture);
        }

        [TestMethod]
        public void TestIfCustomMappingWorksCorrectly()
        {
            Mapper.DeleteMapping<SourcePerson, DestinationPerson>();
            Mapper.AddMapping<SourceAddress, DestinationAddress>(AddressMappingFunction);
            TestMapping<SourcePerson, DestinationPerson>(sourcePerson,expectedPerson);
            TestMapping<SourceAddress, DestinationAddress>(sourcePerson.Address, expectedPerson.Address);
        }

        [TestMethod]
        public void TestIfCustomMappingWithLambdaWorksCorrectly()
        {
            Mapper.DeleteMapping<SourcePerson, DestinationPerson>();
            Mapper.AddMapping<SourceAddress, DestinationAddress>(a=>new DestinationAddress(){Street = a.AddressLine1});
            var expectedAddress = new DestinationAddress() { Street = sourcePerson.Address.AddressLine1 };
            TestMapping<SourceAddress, DestinationAddress>(sourcePerson.Address, expectedAddress);
            TestMapping<SourcePerson, DestinationPerson>(sourcePerson,
                new DestinationPerson()
                {
                    LastName = "Fasola",
                    FirstName = "Jasio",
                    Address = expectedAddress
                });
        }


        [TestMethod]
        public void TestIfCustomMappingCanBeRemoved()
        {
            Mapper.AddMapping<SourceAddress, DestinationAddress>(AddressMappingFunction);
            Mapper.DeleteMapping<SourceAddress,DestinationAddress>();
            TestMapping<SourceAddress, DestinationAddress>(sourcePerson.Address, new DestinationAddress());
        }

        private static DestinationAddress AddressMappingFunction(SourceAddress a)
        {
            return new DestinationAddress()
            {
                Street = a.AddressLine1,
                City = a.AddressLine2.Substring(7),
                PostalCode = a.AddressLine2.Substring(0, 6)
            };
        }

        [TestMethod]
        public void TestClassToStringMapping()
        {
            TestMapping<SourcePerson, string>(sourcePerson, (object)"Fasola Jasio");
        }

    }
}