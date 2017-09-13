using System.Collections.Generic;
using Entities;

namespace ServiceInterfaces
{
    public interface ITodoService
    {
        List<Todo> GetTodos();
        void AddTodo(Todo todo);
        void SaveTodo(Todo todo);
    }
}