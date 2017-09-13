using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskList.Validation;

namespace TaskList.Models
{
    public class TodoViewModel// : IValidatableObject
    {
        public TodoViewModel()
        {
            //When = DateTime.Now;
        }

        [Required]
        public string Todo { get; set; }
        public string Who { get; set; }
        [MaxDays(Days = 5)]
        public int Days { get; set; }
        [UIHint("EMailAddress")]
        //[Remote("IsValid", "Valid", ErrorMessage = "EMail is not valid")]
        public string EMail { get; set; }
        //[DataType(DataType.Date)]
        //[DateRange("2010/12/01", "2010/12/16")]
        public DateTime? When { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(EMail == null )
                yield return new ValidationResult("EMail is invalid", new []{"EMail"});
        }
    }
}