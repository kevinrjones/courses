using System;

namespace Entities
{
    public class Todo
    {
        public Todo()
        {
            Id = Guid.NewGuid().ToString();
        }
        public string TodoText { get; set; }
        public DateTime? TodoDate { get; set; }
        public string Id { get; set; }
        public int Order { get; set; }
        public int NestingLevel { get; set; }
        public string Number { get; set; }
    }
}