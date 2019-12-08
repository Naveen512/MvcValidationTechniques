using System.ComponentModel.DataAnnotations;
using MvcValidation.App.Models;

namespace MvcValidation.App.Attribute
{
    public class TextMatchAttribute : ValidationAttribute
    {
        public string ExpectedText { get; set; }
        public TextMatchAttribute(string expectedText)
        {
            ExpectedText = expectedText;
        }

        public string GetErrorMessage() => $"Enter value should always be {ExpectedText}";
        protected override  ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var person = (Person)validationContext.ObjectInstance;
            if(string.IsNullOrEmpty(person.Name) || person.Name.ToLower() != ExpectedText.ToLower())
            {
                return new ValidationResult(GetErrorMessage());
            }
            return ValidationResult.Success;
        }
    }
}
