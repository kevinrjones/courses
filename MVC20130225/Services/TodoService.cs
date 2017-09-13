using System.Collections.Generic;
using System.Linq;
using Entities;
using ServiceInterfaces;
using TodoRepository.Interfaces;

namespace Services
{
    public class TodoService : ITodoService
    {
        private readonly ITodoRepository _todoRepository;

        public TodoService(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }
        public List<Todo> GetTodos()
        {
            return _todoRepository.Entities.ToList();
        }

        public void AddTodo(Todo todo)
        {
            _todoRepository.Create(todo);
        }

        public void SaveTodo(Todo todo)
        {
            _todoRepository.Update(todo);
        }
    }
}