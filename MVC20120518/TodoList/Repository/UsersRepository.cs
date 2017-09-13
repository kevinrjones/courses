using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public interface IUsersRepository
    {
        IEnumerable<User> GetUsers();
    }

    public class UsersRepository : IUsersRepository
    {
        public IEnumerable<User> GetUsers()
        {
            List<User> users = new List<User>
                            {
                                new User{Id = 1, Name = "Hardik", Age = 27},
                                new User{Id = 2, Name = "Elliot", Age = 22},
                                new User{Id = 3, Name = "Mark", Age = 43},
                                new User{Id = 4, Name = "Hugo", Age = 45},
                                new User{Id = 5, Name = "Kevin", Age = 0x32},
                            };
            return users;
        }
    }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
