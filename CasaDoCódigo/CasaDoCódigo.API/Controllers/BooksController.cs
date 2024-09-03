using CasaDoCódigo.API.Models;
using CasaDoCodigo.Domain;
using CasaDoCodigo.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CasaDoCódigo.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class BooksController : ControllerBase
    {
        private readonly CdcDBContext _dbContext;

        public BooksController(CdcDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        [HttpPost]
        public IActionResult CreateBook(CreateBookRequest request) 
        {
            var model = request.toModel();
            _dbContext.Books.Add(model);
            _dbContext.SaveChanges();
            return Ok(model);
        }

        [HttpGet]
        public IActionResult GetAllBooks()
        {
            var allBooks = _dbContext.Books.Select(x => new { x.Id, x.Title }).ToList();
            return Ok(allBooks);
        }

        [HttpGet("id")]
        public IActionResult GetBookById(Guid id)
        {
            Book? book = _dbContext.Books
                                    .Include(x => x.Author)
                                    .Include(y => y.Category)
                                    .Where(z => z.Id == id)
                                    .FirstOrDefault();
            if(book == null) 
            {
                return NotFound();
            }

            BookByIdResponse response = new BookByIdResponse(book);
            return Ok(response);
        }
    }
}
