using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceModels
{
    public class Todo
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime FinishBy { get; set; }
        public int Priority { get; set; }
    }
}
