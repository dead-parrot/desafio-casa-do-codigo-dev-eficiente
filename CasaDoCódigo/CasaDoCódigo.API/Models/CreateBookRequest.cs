using CasaDoCódigo.API.Validation;
using CasaDoCodigo.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.Windows.Markup;

namespace CasaDoCódigo.API.Models
{
    public class CreateBookRequest
    {
        [Required]
        [Uniqueness(typeof(Book))]
        public string Title { get; set; }
        [Required(AllowEmptyStrings = false)]
        [MaxLength(500)]
        public string Overview { get; set; }
        public string Summary { get; set; }
        [Required]
        [Range(typeof(decimal), "20", "1000000", MaximumIsExclusive = false, ErrorMessage = "The book price must be at least 20")] //Pensar numa melhor forma
        public decimal Price { get; set; }
        [Required]
        [Range(100, int.MaxValue, MinimumIsExclusive = false, ErrorMessage = "The book must have at least 100 pages")]
        public int NumberOfPages { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Uniqueness(typeof(Book))]
        public string ISBN { get; set; }
        [Required]
        [FutureDate]
        public DateTime PublicationDate { get; set; }
        [Required]
        public Guid CategoryID { get; set; }
        [Required]
        public Guid AuthorID { get; set; }

        public Book toModel()
        {
            return new Book(
                title: Title, 
                overview: Overview, 
                summary: Summary, 
                price: Price, 
                numberOfPages: NumberOfPages,
                iSBN: ISBN,
                publicationDate: PublicationDate,
                authorId: AuthorID,
                categoryId: CategoryID);
        }
    }
}