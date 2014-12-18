using System;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace EFvsNhibernate
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder builder = new StringBuilder();
            Database.SetInitializer(new DropCreateDatabaseAlways<EFContext>());

            var countries = RandomDataGenerator.GetRandomList(RandomDataGenerator.GetGeneralCode).ToList();
            var addressTypes = RandomDataGenerator.GetRandomList(RandomDataGenerator.GetGeneralCode).ToList();
            Employee emp1 = null;
            //Database.SetInitializer(new Initilizer());
            using (var context = new EFContext())
            {
                context.GeneralCodes.AddRange(countries);
                context.GeneralCodes.AddRange(addressTypes);

                var admin = RandomDataGenerator.Admin();
                context.Parties.Add(admin);
                
                emp1 = RandomDataGenerator.GetEmployee(countries, addressTypes);
                emp1.CreatedBy = admin;

                context.Parties.Add(emp1);

                context.SaveChanges();
                
            }

            using (var context = new EFContext())
            {
                emp1 = context.Parties.First(p => p.Id == emp1.Id) as Employee;
                var add = RandomDataGenerator.GetAddress(countries, addressTypes);
                emp1.Code = "Check";
                emp1.Addresses.RemoveAt(1);
                //emp1.Addresses.Add(add);

                context.Database.Log = (s) => builder.AppendLine(s);

                context.SaveChanges();

                var log = builder.ToString();

                Console.WriteLine(log);
            }
        }


    }

    public class Initilizer : DropCreateDatabaseIfModelChanges<EFContext>
    {
        public override void InitializeDatabase(EFContext context)
        {
            base.InitializeDatabase(context);
        }
    }
}
