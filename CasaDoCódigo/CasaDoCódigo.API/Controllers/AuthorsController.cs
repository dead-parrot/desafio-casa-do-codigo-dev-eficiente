using CasaDoCódigo.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace CasaDoCódigo.API.Controllers;


[ApiController]
[Route("api/[Controller]")]
public class AuthorsController : ControllerBase
{

    [HttpPost]
    public IActionResult CreateAuthor(CreateAuthorRequest request)
    {
        var model = request.ToModel();
        return Ok(model);
    }
}
