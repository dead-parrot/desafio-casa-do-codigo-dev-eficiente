using CasaDoCódigo.API.Validation;
using CasaDoCodigo.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace CasaDoCódigo.API.Models
{
    public class CreateCategoryRequest
    {
        [Required(AllowEmptyStrings = false)]
        [Uniqueness(typeof(Category))]
        public string Name { get; set; }

        public Category ToModel()
        {
            return new Category(Name);
        }
    }
}