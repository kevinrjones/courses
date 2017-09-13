using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModels;
using TodoRepository;
using Todo = ServiceModels.Todo;

namespace TodoServices
{
    public class TodoService : ITodoService
    {
        private readonly IUserRepository _userRespository;

        public TodoService(IUserRepository userRespository)
        {
            _userRespository = userRespository;
        }

        public ServiceModels.User GetTodos(int userId)
        {
            var userEntity = _userRespository
                .Entities
                .Include("Todos")
                .First(u => u.Id == userId);

            var user = new ServiceModels.User
            {
                EMail = userEntity.EMail,
                Id = userEntity.Id,
                Todos =
                    userEntity.Todos.Select(
                        entity => new Todo {Id = entity.Id, Description = entity.Description, FinishBy = entity.DoBy, Priority = entity.Priority})
                        .ToList()
            };

            return user;
        }

        public void Add(int userId, Todo todo)
        {
            var user = _userRespository.Entities.First(u => u.Id == userId);
            user.Todos.Add(new DataModels.Todo{Description = todo.Description, DoBy = todo.FinishBy, Priority = todo.Priority});
            _userRespository.Save();
        }
    }
}
