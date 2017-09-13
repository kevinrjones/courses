using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TaskList.Validation
{
    public class MaxDaysAttribute : ValidationAttribute, IClientValidatable
    {
        public int Days { get; set; }
        public override bool IsValid(object value)
        {
            int val = int.Parse(value.ToString());
            return val <= Days;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule
                {
                    ErrorMessage = "You're taking too long",
                    ValidationType = "maxdays"
                };

            rule.ValidationParameters["days"] = Days;

            yield return rule;
        }
    }
}