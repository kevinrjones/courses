using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using TodoWeb.Validation;

namespace TodoWeb.Models
{
    public class TodoCreationViewModel //: IValidatableObject
    {
        public TodoCreationViewModel()
        {
            Priorities = new List<SelectListItem>
            {
                new SelectListItem{Text = "One", Value = "1"},
                new SelectListItem{Text = "Two", Value = "2"},
                new SelectListItem{Text = "3", Value = "3"},
                new SelectListItem{Text = "4", Value = "4"},
                new SelectListItem{Text = "5", Value = "5"},
            };
        }

        public List<SelectListItem> Priorities { get; set; }


        [Required]
        public string Description { get; set; }
        public int Priority { get; set; }
        [DisplayName("Finish By")]
        public DateTime FinishBy { get; set; }

        [Required]
        [DoByValidation]
        [DisplayName("Do By")]
        public string DoBy { get; set; }

        [Remote("ValidateColor", "ValidationController", HttpMethod = "POST")]
        [DisplayName("Shoe Colour")]
        public string ShoeColor { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(Description))
            {
                yield return new ValidationResult("Cannot be empty", new[] { "Description" });
            }
        }
    }
}