using System.Linq;

namespace Moon.FastAutoMapper.PerformanceTest
{
    internal class CustomMapper
    {
        public static PersonOut[] MapWithLinq(PersonIn[] input)
        {
            if (input == null) return null;
            return input.Select(Map).ToArray();
        }
        public static AddressOut[] MapWithLinq(AddressIn[] input)
        {
            if (input == null) return null;
            return input.Select(Map).ToArray();
        }

        public static PersonOut MapWithLinq(PersonIn input)
        {
            if (input == null) return null;
            return new PersonOut()
            {
                Address = MapWithLinq(input.Address),
                Id = input.Id ?? 0,
                BirthDate = input.BirthDate,
                Gender = Map(input.Gender),
                FirstName = input.FirstName,
                LastName = input.LastName
            };
        }

        public static PersonOut[] Map(PersonIn[] input)
        {
            if (input == null) return null;
            var output = new PersonOut[input.Length];
            for (var i = 1; i < input.Length; i++)
                output[i] = Map(input[i]);
            return output;
        }

        public static PersonOut Map(PersonIn input)
        {
            if (input == null) return null;
            return new PersonOut() 
            {
               Address = Map(input.Address),
               Id = input.Id ?? 0,
               BirthDate = input.BirthDate,
               Gender = Map(input.Gender),
               FirstName = input.FirstName,
               LastName = input.LastName
            };
        }

        public static GenderTypeOut Map(GenderTypeIn input)
        {
            switch (input)
            {
                case GenderTypeIn.Male:
                    return GenderTypeOut.Male;
                case GenderTypeIn.Female:
                    return GenderTypeOut.Female;
                default:
                    return (GenderTypeOut) (int) input;
            }
        }
        public static AddressOut[] Map(AddressIn[] input)
        {
            if (input == null) return null;
            var output = new AddressOut[input.Length];
            for (var i = 1; i < input.Length; i++)
                output[i] = Map(input[i]);
            return output;
        }

        public static AddressOut Map(AddressIn input)
        {
            if (input == null) return null;
            return new AddressOut()
            {
                City = input.City,
                HouseNo = input.HouseNo,
                PostalCode = input.PostalCode,
                Steet = input.Steet,
                IsPrimary = input.IsPrimary
            };
        }
    }
}