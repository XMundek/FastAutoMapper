using System;

namespace Moon.FastAutoMapper.PerformanceTest
{
    enum GenderTypeIn
    {
        Male,
        Female
    };

    class AddressIn
    {
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Steet { get; set; }
        public string HouseNo { get; set; }
        public bool IsPrimary { get; set; }
    }

    class PersonIn
    {
        public int? Id { get; set; }
        public DateTime BirthDate { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public AddressIn[] Address { get; set; }
        public GenderTypeIn Gender { get; set; }
    }

    enum GenderTypeOut
    {
        Male,
        Female
    };


    class AddressOut
    {
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Steet { get; set; }
        public string HouseNo { get; set; }
        public bool IsPrimary { get; set; }
    }

    class PersonOut
    {
        public long Id { get; set; }
        public DateTime BirthDate { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public AddressOut[] Address { get; set; }
        public GenderTypeOut Gender { get; set; }
    }
}