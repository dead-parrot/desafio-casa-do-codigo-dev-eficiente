using DocumentValidator;
using System.ComponentModel.DataAnnotations;

namespace CasaDoCódigo.API.Validation
{
    public class BrazilianDocumentValidator : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null) return ValidationResult.Success; ;
            
            string docnumber = value.ToString();

            if (CnpjValidation.Validate(docnumber) ||
                CpfValidation.Validate(docnumber))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("CPF or CNPJ invalid");

        }
    }
}
