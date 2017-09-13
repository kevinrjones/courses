using Repository;
using ShoesModel;

namespace ShoeEFRepository.Interfaces
{
    public interface IShoeRepository : IRepository<Shoe>
    {
        Shoe GetShoe(string nickname);
    }
}