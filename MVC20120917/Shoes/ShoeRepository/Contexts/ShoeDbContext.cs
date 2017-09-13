using System.Data.Entity;

namespace ShoeEFRepository.Contexts
{
    public class ShoeDbContext : DbContext
    {
        public ShoeDbContext(string connectionString) : base(connectionString)
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<ShoeDbContext>(null);
            base.OnModelCreating(modelBuilder);
        }

    }
}