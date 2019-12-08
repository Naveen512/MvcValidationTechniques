using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.Extensions.Localization;

namespace MvcValidation.App.Attribute
{
    public class CustomValidationAttributeAdopterProvider: IValidationAttributeAdapterProvider
    {
        private readonly IValidationAttributeAdapterProvider baseProvider = new ValidationAttributeAdapterProvider();
        public IAttributeAdapter GetAttributeAdapter(ValidationAttribute attribute, IStringLocalizer stringLocalizer)
        {
            if(attribute is TextMatchAttribute textMatchAttribute)
            {
                return new TextMatchAttributeAdapter(textMatchAttribute, stringLocalizer);
            }
            return baseProvider.GetAttributeAdapter(attribute, stringLocalizer);
        }
    }
}
