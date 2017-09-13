using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Repository;
using TodoRepository.interfaces;

namespace InMemoryRepository
{
    public class TodoListRepository : ITodoRepository
    {
        static readonly IList<Todo> Todos = new List<Todo>
                                {
                                    new Todo{WhatToDo = "Finish Chapter"},
                                    new Todo{WhatToDo = "Have Lunch"},
                                    new Todo{WhatToDo = "Have Dinner"},
                                };
        public void Dispose()
        {
            
        }

        public IQueryable<Todo> Entities 
        {
            get { return Todos.AsQueryable(); }
        }
        public Todo New()
        {
            return new Todo();
        }

        public void Update(Todo entity)
        {
            throw new NotImplementedException();
        }

        public void Create(Todo entity)
        {
            Todos.Add(entity);
        }

        public void Delete(Todo entity)
        {
            throw new NotImplementedException();
        }
    }

}
