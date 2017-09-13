using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Antlr.Runtime;

namespace Movie.Models
{
    public class User
    {
        public string Name { get; set; }
    }

    public class CreateMovieViewModel : IValidatableObject
    {
        [Required]
        public string Title { get; set; }
        
        public string Director { get; set; }

        [UIHint("EmailAddress")]
        public string ContactMe { get; set; }

        public User User { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            //if (string.IsNullOrEmpty(Title))
            //{
            //    yield return new ValidationResult("Title cannot be empty", new[] { "Title" });
            //}
            if (string.IsNullOrEmpty(Director))
            {
                yield return new ValidationResult("The name of the director must be set", new[] { "Director" });
            }

        }
    }
}