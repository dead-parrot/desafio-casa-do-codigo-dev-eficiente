using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaDoCodigo.Domain.Entities
{
    public class Author(Guid id, DateTime createdAt, string name, string description, string email)
    {
        public Guid Id { get; set; } = id;
        public DateTime CreatedAt { get; set; } = createdAt;
        public string Name { get; set; } = name;
        public string Description { get; set; } = description;
        public string Email { get; set; } = email;
    }
}
