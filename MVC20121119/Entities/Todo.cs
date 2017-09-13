using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Todo
    {
        public Todo()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public string WhatToDo { get; set; }
        public DateTime WhenToDoIt { get; set; }
    }
}
