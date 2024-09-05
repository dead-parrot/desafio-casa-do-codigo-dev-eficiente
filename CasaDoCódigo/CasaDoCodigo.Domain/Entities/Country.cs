namespace CasaDoCodigo.Domain.Entities;

public class Country
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public List<State> States { get; set; } = new List<State>();
    public Country(string name)
    {
        if(string.IsNullOrEmpty(name)) throw new ArgumentNullException(nameof(name)); 
        Name = name;
        Id = Guid.NewGuid();
    }
}
