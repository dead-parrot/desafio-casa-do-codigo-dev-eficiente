using CasaDoCódigo.API.Validation;
using System.ComponentModel.DataAnnotations;

namespace CasaDoCódigo.API.Models
{
    public class PaymentRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [BrazilianDocumentValidator]
        public string Document {  get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public Guid CountryID {  get; set; }
        public Guid StateID {  get; set; }
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
        [Required]
        public string PostalCode { get; set; }

    }
}
