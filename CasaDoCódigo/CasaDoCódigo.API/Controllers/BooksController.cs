using CasaDoCódigo.API.Models;
using CasaDoCodigo.Domain;
using Microsoft.AspNetCore.Mvc;

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
    }
}
