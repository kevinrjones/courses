using DataModels;
using Repository;

namespace TodoRepository
{
    public class UserRepository : BaseEfRepository<User>, IUserRepository
    {
        public UserRepository(TodoEntities ctx)
            : base(ctx)
        {

        }
    }
}