using System;
using System.Diagnostics;
using AutoMapper.Configuration;

namespace Moon.FastAutoMapper.PerformanceTest
{
    class Program
    {
        private const int TestObjectCount = 100000;

        private static PersonIn[] GetTestData()
        {
            var personList = new PersonIn[TestObjectCount];
            for (var i = 0; i < TestObjectCount; i++)
            {
                personList[i] = new PersonIn()
                {
                    BirthDate = DateTime.Now,
                    Id = i,
                    Gender = i % 2 == 0 ? GenderTypeIn.Male : GenderTypeIn.Female,
                    LastName = "LastName" + i.ToString(),
                    FirstName = "FName" + i.ToString(),
                    Address = new AddressIn[]
                    {
                        new AddressIn()
                        {
                            City = "c" + i.ToString(),
                            PostalCode = "2" + i.ToString(),
                            HouseNo = "12",
                            Steet = "S" + i.ToString(),
                            IsPrimary = true
                        },
                        null,
                        new AddressIn() {City = "testx"}
                    }
                };
            }
            return personList;
        }

        private static void RunTest<T>(string testName, T testData, Action<T> testFunction)
        {
            try
            {
                Console.WriteLine($"{testName} first test started");
                Stopwatch testTimer = Stopwatch.StartNew();
                testFunction(testData);
                testTimer.Stop();
                Console.WriteLine("First test mapping time: {0} ms", testTimer.ElapsedMilliseconds);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{testName}:{ex.Message}");
            }
        }

        static void Main()
        {
            Console.WriteLine("PrepareTestData...");
            var testData = GetTestData();

            RunTest("Automapper 7.0.1",testData,
                data =>
                {
                    AutoMapper.Mapper.Initialize(new MapperConfigurationExpression());
                    var result = AutoMapper.Mapper.Map<PersonIn[], PersonOut[]>(data);
                });

            RunTest("Moon.FastAutoMapper", testData,
                data =>
                {
                    var result = FastAutoMapper.Mapper.Map<PersonIn[], PersonOut[]>(data);
                });

            RunTest("CustomWithFor", testData,
                data =>
                {
                    var result = CustomMapper.Map(data);
                });

            RunTest("CustomWithLinq", testData,
                data =>
                {
                    var result = CustomMapper.MapWithLinq(data);
                });
            Console.ReadLine();
        }
    }
}