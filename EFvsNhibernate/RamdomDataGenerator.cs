using System;
using System.Collections.Generic;

namespace EFvsNhibernate
{
    public static class RandomDataGenerator
    {
        public static IList<T> GetRandomList<T>(Func<T> func, int count = -1)
        {
            var list = new List<T>();
            var rand = new Random();
            var num = (count == -1) ? 3 : rand.Next(1, count);

            for (int i = 0; i < num; i++)
            {
                list.Add(func());
            }
            return list;
        }

        public static GeneralCode GetGeneralCode()
        {
            return new GeneralCode
            {
                Code = Guid.NewGuid().ToString(),
                RecordState = RecordState.Active,
                Type = Guid.NewGuid().ToString(),
                Value = Guid.NewGuid().ToString()
            };
        }

        public static Address GetAddress(List<GeneralCode> countries = null, List<GeneralCode> addresstypes = null)
        {
            return new Address
            {
                Street = Guid.NewGuid().ToString(),
                AddressType = addresstypes == null ? GetGeneralCode() : addresstypes[new Random().Next(addresstypes.Count)],
                City = Guid.NewGuid().ToString(),
                State = Guid.NewGuid().ToString(),
                RecordState = RecordState.Active,
                Country = countries == null ? GetGeneralCode() : countries[new Random().Next(addresstypes.Count)],
            };
        }

        public static Employee GetEmployee(List<GeneralCode> countries = null, List<GeneralCode> addresstypes = null)
        {
            return new Employee
            {
                Addresses = GetRandomList(() => GetAddress(countries, addresstypes)),
                Code = Guid.NewGuid().ToString(),
                CreatedBy = Admin(),
                CreatedOn = DateTime.Now.AddDays(-1),
                DateOfBirth = DateTime.Now.AddDays(-10),
                Name = Guid.NewGuid().ToString(),
                Gender = GenderTypes.Female,
                RecordState = RecordState.Active
            };
        }

        public static Customer GetCustomer(List<GeneralCode> countries = null, List<GeneralCode> addresstypes = null)
        {
            return new Customer
            {
                Addresses = GetRandomList(() => GetAddress(countries, addresstypes)),
                Code = Guid.NewGuid().ToString(),
                CreatedBy = Admin(),
                CreatedOn = DateTime.Now.AddDays(-1),
                DateOfBirth = DateTime.Now.AddDays(-10),
                Name = Guid.NewGuid().ToString(),
                Gender = GenderTypes.Female,
                RecordState = RecordState.Active
            };
        }

        public static Company GetCompany(List<GeneralCode> countries = null, List<GeneralCode> addresstypes = null)
        {
            return new Company
            {
                Addresses = GetRandomList(() => GetAddress(countries, addresstypes)),
                Code = Guid.NewGuid().ToString(),
                CreatedBy = Admin(),
                CreatedOn = DateTime.Now.AddDays(-1),
                RecordState = RecordState.Active
            };
        }


        public static Employee Admin()
        {
            return new Employee
            {
                Code = "Admin",
                Name = "Admins",
                Gender = GenderTypes.Male,
                RecordState = RecordState.Active
            };
        }
    }
}
