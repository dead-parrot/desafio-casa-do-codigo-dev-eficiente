using CasaDoCodigo.Domain.Entities;

namespace CasaDoCódigo.API.Models
{
    public class BookByIdResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Overview { get; set; }
        public string Summary { get; set; }
        public decimal Price { get; set; }
        public int NumberOfPages { get; set; }
        public string ISBN { get; set; }
        public DateTime PublicationDate { get; set; }
        public CategoryInfo Category { get; set; } = new CategoryInfo();
        public AuthorInfo Author { get; set; } = new AuthorInfo();

        public BookByIdResponse(Book model)
        {
            Id = model.Id;
            Title = model.Title;
            Overview = model.Overview;
            Summary = model.Summary;
            Price = model.Price;
            NumberOfPages = model.NumberOfPages;
            ISBN = model.ISBN;
            PublicationDate = model.PublicationDate;
            Category.Name = model.Category?.Name;
            Category.Id = model.Category?.Id;
            Author.Name = model.Author?.Name;
            Author.Id = model.Author?.Id;
            Author.Description = model.Author?.Description; 
        }
    }

    public class AuthorInfo
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class CategoryInfo 
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
    }
}
