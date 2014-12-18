using System.Data.Entity;

namespace EFvsNhibernate
{
    public class EFContext : DbContext
    {
        public DbSet<GeneralCode> GeneralCodes { get; set; }
        public DbSet<Party> Parties { get; set; }
    }
}
