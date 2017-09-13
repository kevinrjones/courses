using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TodoList.Models
{
    public class NewTodoModel : IValidatableObject
    {
        public NewTodoModel()
        {
            PriorityList = new Dictionary<int, string>();
            PriorityList.Add(1, "High");
            PriorityList.Add(2, "Normal");
            PriorityList.Add(3, "Low");

            Completed = DateTime.Now;
        }

        [Required(ErrorMessage = "Required")]
        public string Title { get; set; }
        [Required]
        public string Entry { get; set; }
        [DataType(DataType.Date)]
        public DateTime Completed { get; set; }
        public int Priority { get; set; }
        public Dictionary<int, string> PriorityList { get; private set; }
        
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(Title == Entry)
            {
                yield return new ValidationResult("Title and Entry cannot be the same");
            }

            if(Completed < DateTime.Now)
            {
                yield return new ValidationResult("Date is invalid", new[] { "Completed" });
            }
        }
    }
}