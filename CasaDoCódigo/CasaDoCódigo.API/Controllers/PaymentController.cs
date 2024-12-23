using CasaDoCódigo.API.Models;
using CasaDoCodigo.Domain;
using CasaDoCodigo.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CasaDoCódigo.API.Controllers
{
    [ApiController]
    [Route("pay")]
    public class PaymentController : ControllerBase
    {
        public CdcDBContext _dbContext { get; set; }

        [HttpPost]
        public IActionResult Pay(PaymentRequest paymentRequest)
        {
            Country? country = _dbContext.Countries.Find(paymentRequest.CountryID);
            if(country == null ) 
            {
                return BadRequest("Country not found");
            }

            if(country.States.Count > 0) 
            {
                if (paymentRequest.StateID == Guid.Empty)
                    return BadRequest("Missing state");

                var state = country.States.FirstOrDefault(x => x.Id == paymentRequest.StateID);
                if (state == null) 
                {
                    return BadRequest("State not found for this country");
                }
            }

            return Ok();
        }
    }
}
