using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using SimpleAppWeb.Validators;

namespace SimpleAppWeb.Models
{
    public class TodoItemCreateViewModel //: IValidatableObject
    {
        public TodoItemCreateViewModel()
        {
            Priorities = new List<SelectListItem>
            {
                new SelectListItem{Text = "1", Value = "1"},
                new SelectListItem{Text = "2", Value = "2"},
                new SelectListItem{Text = "3", Value = "3"},
                new SelectListItem{Text = "4", Value = "4"},
                new SelectListItem{Text = "5", Value = "5"},
            };
        }
        public List<SelectListItem> Priorities { get; set; }

        [Required]
        public string Description { get; set; }

        [Remote("IsShoe", "ValidateController", HttpMethod = "POST")]
        public string Shoes { get; set; }

        [GangMember]
        public string GangMember { get; set; }

        public int Priority { get; set; }

        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    yield return new ValidationResult("Description is really required", new[] { "Description" });
        //}
    }
}