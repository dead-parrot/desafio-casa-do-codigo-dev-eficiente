using CasaDoCódigo.API.Models;
using CasaDoCodigo.Domain;
using Microsoft.AspNetCore.Mvc;

namespace CasaDoCódigo.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly CdcDBContext _dbContext;

        public CategoryController(CdcDBContext cdcDBContext)
        {
            _dbContext = cdcDBContext;
        }

        [HttpPost]
        public ActionResult CreateCategory(CreateCategoryRequest request) 
        {
            var model = request.ToModel();
            var isNameDuplicated = _dbContext.Categories.Any(x => x.Name == model.Name);
            if(isNameDuplicated) 
            {
                return BadRequest("Category name is duplicated");
            }
            _dbContext.Categories.Add(model);
            _dbContext.SaveChanges();
            return Ok(model);
        }
    }
}
