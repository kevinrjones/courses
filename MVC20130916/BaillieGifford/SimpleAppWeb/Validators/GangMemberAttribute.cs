using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleAppWeb.Validators
{
    public class GangMemberAttribute : ValidationAttribute, IClientValidatable
    {
        public override bool IsValid(object valueToCheck)
        {
            var value = valueToCheck as string;
            if (string.IsNullOrEmpty(value)) return true;
            return value == "Fred" || value == "Velma" || value == "Daphne" || value == "Shaggy";
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule();
            rule.ValidationType = "gangmember";
            rule.ErrorMessage = "You must be in the gang";
            yield return rule;
        }
    }
}