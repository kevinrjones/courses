using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Repository;

namespace TodoRepository.interfaces
{
    public interface ITodoRepository : IRepository<Todo>
    {
    }
}
