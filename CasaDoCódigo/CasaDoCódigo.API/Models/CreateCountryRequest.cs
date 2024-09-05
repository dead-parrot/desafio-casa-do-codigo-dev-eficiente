using CasaDoCódigo.API.Validation;
using CasaDoCodigo.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace CasaDoCódigo.API.Models
{
    public class CreateCountryRequest
    {
        [Required]
        [Uniqueness(typeof(Country))]
        public string Name { get; set; }

        public Country ToModel()
        {
            Country country = new(Name.ToLower());
            return country;
        }
    }
}