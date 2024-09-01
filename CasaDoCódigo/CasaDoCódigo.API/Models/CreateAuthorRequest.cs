using CasaDoCódigo.API.Validation;
using CasaDoCodigo.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace CasaDoCódigo.API.Models
{
    public class CreateAuthorRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        [UniquenessValidator(typeof(Author))]
        public string Email { get; set; }
        [Required]
        [Length(1, 400)]
        public string Description { get; set; }

        public Author ToModel()
        {
            return new Author(Name, Description, Email);
        }
    }
}
