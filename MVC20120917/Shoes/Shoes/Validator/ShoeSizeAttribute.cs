using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shoes.Validator
{
    public class ShoeSizeAttribute : ValidationAttribute, IClientValidatable
    {
        public int MinSize { get; set; }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule
                {
                    ErrorMessage = "Shoe size must be greater than " + MinSize,
                    ValidationType = "shoesize"
                };
            rule.ValidationParameters ["shoesize"] = MinSize;
            yield return rule;
        }
    }
}