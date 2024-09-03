using CasaDoCódigo.API.Models;
using CasaDoCodigo.Domain;
using Microsoft.AspNetCore.Mvc;

namespace CasaDoCódigo.API.Controllers;

[ApiController]
[Route("api/[Controller]")]
public class AuthorsController : ControllerBase
{
    private readonly CdcDBContext _dbContext;

    public AuthorsController(CdcDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpPost]
    public IActionResult CreateAuthor(CreateAuthorRequest request)
    {
        var model = request.ToModel();
        _dbContext.Authors.Add(model);
        _dbContext.SaveChanges();
        return Ok(model);
    }

}