using System.ComponentModel.DataAnnotations;
using MvcValidation.App.Attribute;

namespace MvcValidation.App.Models
{
    public class Person
    {
        [TextMatch2("Iron Man")]
        public string Name { get; set; }
    }
}
