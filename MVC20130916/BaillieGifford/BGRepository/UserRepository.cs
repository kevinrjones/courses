using DataModels;
using Repository;

namespace AtriumRepository
{
    public class UserRepository : BaseEfRepository<User>, IUserRepository
    {
        public UserRepository(BaillieGiffordEntities ctx)
            : base(ctx)
        {

        }
    }
}