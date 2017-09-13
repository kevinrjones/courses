using System.Data.Entity;
using KelloData;
using Microsoft.AspNet.Identity.EntityFramework;

namespace KelloRepository.Contexts
{
    public class KelloContext : IdentityDbContext<KelloUser>
//    public class KelloContext : DbContext
    {
        public KelloContext(string connectionString) : base(connectionString) { }
        public KelloContext()
            : this("KelloContext") { }

        public DbSet<Board> Boards { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<KelloList> Lists { get; set; }
        public DbSet<Image> Images { get; set; }
    }
}