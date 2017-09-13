using System.Security.Cryptography.X509Certificates;
using DataModels;

namespace BGServices
{
    public interface ITodoService
    {
        User GetTodoItemsForUser(int userId);
        User GetTodoItemForUser(int userId, int todoItemId);
        void AddTodoItem(int userId, Todo todo);
    }
}