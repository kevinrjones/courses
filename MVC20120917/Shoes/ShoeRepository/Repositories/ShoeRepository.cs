using System.Linq;
using Repository;
using ShoeEFRepository.Contexts;
using ShoeEFRepository.Interfaces;
using ShoesModel;

namespace ShoeEFRepository.Repositories
{
    public class ShoeRepository : BaseEfRepository<Shoe>, IShoeRepository
    {
        public ShoeRepository(string connectionString)
            : base(new ShoeDbContext(connectionString))
        {
        }

        public Shoe GetShoe(string nickname)
        {
            return (from b in Entities                    
                    select b).FirstOrDefault();
        }
    }
}