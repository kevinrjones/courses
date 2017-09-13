using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TodoWeb.Validation
{
    public class DoByValidationAttribute : ValidationAttribute, IClientValidatable
    {        
        public override bool IsValid(object value)
        {
            var val = value as string;
            if (String.IsNullOrWhiteSpace(val)) return true;

            return (val == "Fred" || val == "Zelma" || val == "Daphne" || val == "Shaggy" || val == "Scooby");
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            yield return new ModelClientValidationRule{ErrorMessage = "Pesky kids", ValidationType = "scooby"};
        }
    }
}