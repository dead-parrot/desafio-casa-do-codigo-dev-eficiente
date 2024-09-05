namespace CasaDoCodigo.Domain.Entities
{
    public class State
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid CountryId { get; set; }

        public State(string name, Guid countryId) 
        { 
            if(string.IsNullOrEmpty(name)) { throw new ArgumentNullException(nameof(name)); }
            Name = name;
            CountryId = countryId;
            Id = Guid.NewGuid();
        }
    }
}