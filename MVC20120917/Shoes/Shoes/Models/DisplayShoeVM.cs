using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shoes.Validator;
using ShoesModel;

namespace Shoes.Models
{
    public class DisplayShoeVM : IValidatableObject
    {
        public DisplayShoeVM(Shoe shoe)
        {
            Type = shoe.Type;
            Colour = shoe.Color;
            Size = shoe.Size;
            Id = shoe.Id;
            OwnerEmail = shoe.OwnerEmail;
            OrderedOn = shoe.TimeAdded;
        }

        public DisplayShoeVM()
        {
            OrderedOn = DateTime.Now;
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "You must speicfy a style")]
        public string Type { get; set; }

        [DisplayName("Color")]
        [Required(ErrorMessage = "You must specify a color")]
        public string Colour { get; set; }

        [ShoeSize(MinSize = 10)]
        public int Size { get; set; }

        //[DataType(DataType.EmailAddress)]
        [Remote("IsEmailValid", "Validation", HttpMethod = "POST")]
        public string OwnerEmail { get; set; }

        public DateTime OrderedOn { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            yield break;
            //if(Size < 10)
            //{
            //    yield return new ValidationResult("Invalid shoe size",new[]{"Size"});
            //}
        }
    }
}