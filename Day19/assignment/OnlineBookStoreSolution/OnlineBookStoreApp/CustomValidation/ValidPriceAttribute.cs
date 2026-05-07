using System.ComponentModel.DataAnnotations;

namespace OnlineBookStoreApp.CustomValidation
{
    public class ValidPriceAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            double price = Convert.ToDouble(value);

            return price > 0 && price <= 5000;
        }
    }
}