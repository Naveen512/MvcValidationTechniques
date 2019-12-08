using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Extensions.Localization;

namespace MvcValidation.App.Attribute
{
    public class TextMatchAttributeAdapter : AttributeAdapterBase<TextMatchAttribute>
    {
        public TextMatchAttributeAdapter(TextMatchAttribute attribute, IStringLocalizer stringLocalizer):base(attribute, stringLocalizer)
        {

        }

        public override void AddValidation(ClientModelValidationContext context)
        {
            MergeAttribute(context.Attributes, "data-val", "true");
            MergeAttribute(context.Attributes, "data-val-textMatch", GetErrorMessage(context));
            MergeAttribute(context.Attributes, "data-val-textMatch-expectedText", Attribute.ExpectedText);
        }

        public override string GetErrorMessage(ModelValidationContextBase validationContext)
        {
            return Attribute.GetErrorMessage();
        }
    }
}
