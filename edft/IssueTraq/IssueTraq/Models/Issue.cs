using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using IssueTraq.Validation;

namespace IssueTraq.Models
{
    public class Issue //: IValidatableObject
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }

        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    if (string.IsNullOrEmpty(Title))
        //    {
        //        yield return new ValidationResult("Title must contain a value", new string[]{"Title"});
        //    }
        //}
    }
}