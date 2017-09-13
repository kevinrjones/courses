using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TodoWeb.Validators
{
    public class MaxDaysAttribute : ValidationAttribute , IClientValidatable
    {
        public int Days { get; set; }
        public override bool IsValid(object value)
        {
            var val = int.Parse(value.ToString());
            return val <= Days;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule();
            rule.ErrorMessage = "You're taking too long";
            rule.ValidationType = "maxdays";
            rule.ValidationParameters["howlong"] = Days;

            yield return rule;
        }
    }
}