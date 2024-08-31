using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaDoCodigo.Domain.Entities
{
    public class Author
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }

        /// <summary>
        /// Author entity
        /// </summary>
        /// <param name="name">Its name. It must not be null or empty</param>
        /// <param name="description">Its description.It must not be null or empty. 
        /// Also not be greater than 400 characters.</param>
        /// <param name="email">Its email. It must be valid email.</param>
        /// <exception cref="ArgumentNullException">Exception in case an invalid parameter is passed</exception>
        public Author(string name, string description, string email)
        {
            if(string.IsNullOrEmpty(name)) throw new ArgumentNullException(nameof(name));
            if(string.IsNullOrEmpty(description)) throw new ArgumentNullException(nameof(description));
            if(description.Length <= 400) throw new ArgumentNullException(nameof(description));
            if(string.IsNullOrEmpty(email)) throw new ArgumentNullException(nameof(email));
            
            Id = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;
            Name = name;
            Description = description;
            Email = email;
        }
    }
}