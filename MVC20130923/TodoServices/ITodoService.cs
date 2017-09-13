using System.Collections;
using System.Collections.Generic;
using ServiceModels;

namespace TodoServices
{
    public interface ITodoService
    {
        User GetTodos(int userId);
        void Add(int userId, Todo todo);
    }
}