using CasaDoCodigo.Domain.Entities;

namespace CasaDoCódigo.API.Models;

public class CreateStateRequest
{
    public string Name { get; set; }
    public string Country { get; set; }

    public State ToModel(Guid CountryId)
    {
        return new State(Name, CountryId);
    }
}