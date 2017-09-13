using System.Data.Entity;
using System.Linq;
using AtriumRepository;
using DataModels;

namespace BGServices
{
    public class TodoService : ITodoService
    {
        private readonly IUserRepository _userRepository;

        public TodoService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User GetTodoItemsForUser(int userId)
        {
            return _userRepository.Entities.First(u => u.Id == userId);
        }

        public User GetTodoItemForUser(int userId, int todoItemId)
        {
            var user = _userRepository.Entities.Include("Todos").First(u => u.Id == userId);
            user.Todos = user.Todos.Where(t => t.Id == todoItemId).ToList();
            return user;
        }

        public void AddTodoItem(int userId, Todo todo)
        {
            var user =_userRepository.Entities.First(u => u.Id == userId);
            user.Todos.Add(todo);
            _userRepository.Save();
        }
    }
}
