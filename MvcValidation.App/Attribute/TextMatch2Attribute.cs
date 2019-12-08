using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using MvcValidation.App.Models;

namespace MvcValidation.App.Attribute
{
    public class TextMatch2Attribute : ValidationAttribute, IClientModelValidator
    {
        public string ExpectedText { get; set; }
        public TextMatch2Attribute(string expectedText)
        {
            ExpectedText = expectedText;
        }

        public string GetErrorMessage() => $"Enter value should always be {ExpectedText}";
        public void AddValidation(ClientModelValidationContext context)
        {
            MergeAttribute(context.Attributes, "data-val", "true");
            MergeAttribute(context.Attributes, "data-val-textMatch", GetErrorMessage());
            MergeAttribute(context.Attributes, "data-val-textMatch-expectedText", ExpectedText);
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var person = (Person)validationContext.ObjectInstance;
            if (string.IsNullOrEmpty(person.Name) || person.Name.ToLower() != ExpectedText.ToLower())
            {
                return new ValidationResult(GetErrorMessage());
            }
            return ValidationResult.Success;
        }

        private bool MergeAttribute(IDictionary<string, string> attributes, string key, string value)
        {
            if (attributes.ContainsKey(key))
            {
                return false;
            }

            attributes.Add(key, value);
            return true;
        }
    }
}
