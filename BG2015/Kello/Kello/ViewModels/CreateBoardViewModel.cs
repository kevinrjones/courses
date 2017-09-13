using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using KelloRepository.Repositories;

namespace Kello.ViewModels
{
    public class CreateBoardViewModel //: IValidatableObject
    {
        [Required]
        [StringLength(int.MaxValue, MinimumLength = 3)]
        public string Title { get; set; }
//        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
//        {
//            if (string.IsNullOrEmpty(Title))
//            {
//                yield return new ValidationResult("Title is required", new []{"Title"});
//            }
//        }
    }
}