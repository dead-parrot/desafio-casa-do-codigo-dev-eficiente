using Azure.Core;
using CasaDoCódigo.API.Models;
using CasaDoCodigo.Domain;
using Microsoft.AspNetCore.Mvc;

namespace CasaDoCódigo.API.Controllers
{
    [ApiController]
    [Route("api")]
    public class CountryStateController : ControllerBase
    {
        private readonly CdcDBContext _dbContext;

        public CountryStateController(CdcDBContext cdc)
        {
            _dbContext = cdc;
        }

        [HttpPost("country")]
        public IActionResult CreateCountry(CreateCountryRequest request)
        {
            var model = request.ToModel();
            _dbContext.Countries.Add(model);
            _dbContext.SaveChanges();
            return Ok();
        }

        [HttpPost("state")]
        public IActionResult CreateState(CreateStateRequest request)
        {
            string lowerCountryName = request.Country.ToLower();
            var countryId = _dbContext.Countries
                        .Where(y => y.Name.Equals(lowerCountryName))
                        .Select(x => x.Id)
                        .FirstOrDefault();

            if (countryId == default)
                return BadRequest("Country does not exists");
                        
            var model = request.ToModel(countryId);
            _dbContext.States.Add(model);
            _dbContext.SaveChanges();
            return Ok(model.Id);
        }
    }
}
