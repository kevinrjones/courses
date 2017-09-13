using Repository;
using ShoesModel;

namespace ShoeInMemoryRepository.Interfaces
{
    public interface IShoeRepository : IRepository<Shoe>
    {
        Shoe GetShoe(int id);
    }
}