using System.ComponentModel.DataAnnotations;

namespace CasaDoCódigo.API.Validation
{
    public class FutureDate : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null) return null;

            if(value.GetType() != typeof(DateTime)) return null;

            DateTime valueDateTime = (DateTime)value;

            DateOnly valueDateOnly = DateOnly.FromDateTime(valueDateTime);
            DateOnly todayDate = DateOnly.FromDateTime(DateTime.UtcNow);

            bool isFuture = valueDateOnly.CompareTo(todayDate) > 0;

            if (!isFuture)
                return new ValidationResult("Date is not a future date");

            return ValidationResult.Success;
        }
    }
}
