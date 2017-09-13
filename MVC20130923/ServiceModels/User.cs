using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceModels
{
    public class User
    {
        public int Id { get; set; }
        public string EMail { get; set; }
        public IList<Todo> Todos { get; set; }
    }
}
