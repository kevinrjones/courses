using System;

namespace SimpleAppWeb.Models
{
    public class TodoViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
        public DateTime DoBy { get; set; }
    }
}