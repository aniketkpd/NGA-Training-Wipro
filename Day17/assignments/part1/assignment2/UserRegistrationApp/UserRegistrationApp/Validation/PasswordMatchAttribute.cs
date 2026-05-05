using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace UserRegistrationApp.Validation
{
    public class PasswordMatchAttribute : ValidationAttribute
    {
        private readonly string _comparisonProperty;

        public PasswordMatchAttribute(string comparisonProperty)
        {
            _comparisonProperty = comparisonProperty;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            PropertyInfo property = validationContext.ObjectType.GetProperty(_comparisonProperty);

            if (property == null)
                return new ValidationResult("Invalid property");

            var comparisonValue = property.GetValue(validationContext.ObjectInstance);

            if (!Equals(value, comparisonValue))
                return new ValidationResult(ErrorMessage);

            return ValidationResult.Success;
        }
    }
}