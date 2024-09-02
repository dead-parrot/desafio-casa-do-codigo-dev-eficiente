using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaDoCodigo.Domain.Entities
{
    public class Book
    {
        public Book(string title, string overview, string summary, decimal price, int numberOfPages, string iSBN, DateTime publicationDate, Guid categoryId, Guid authorId)
        {
            Title = title ?? throw new ArgumentNullException(nameof(title));
            
            Overview = overview ?? throw new ArgumentNullException(nameof(overview));
            if(overview.Length > 500) throw new ArgumentOutOfRangeException(nameof(overview));
            
            Summary = summary ?? throw new ArgumentNullException(nameof(summary));
            
            ArgumentOutOfRangeException.ThrowIfLessThan(price, 20);
            Price = price;
            
            ArgumentOutOfRangeException.ThrowIfLessThan(numberOfPages, 100);
            NumberOfPages = numberOfPages;
            
            ISBN = iSBN ?? throw new ArgumentNullException(nameof(iSBN));
            
            ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(publicationDate.Date, DateTime.UtcNow.Date);
            PublicationDate = publicationDate;
            
            if(categoryId == Guid.Empty)
                throw new ArgumentNullException(nameof(categoryId));
            CategoryId = categoryId;

            if (authorId == Guid.Empty)
                throw new ArgumentNullException(nameof(authorId));
            AuthorId = authorId;

            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Overview { get; set; }
        public string Summary { get; set; }
        public decimal Price { get; set; }
        public int NumberOfPages { get; set; }
        public string ISBN { get; set; }
        public DateTime PublicationDate { get; set; }
        public Category Category { get; set; }
        public Guid CategoryId { get; set; }

        public Author Author { get; set; }
        public Guid AuthorId { get; set; }
    }
}
