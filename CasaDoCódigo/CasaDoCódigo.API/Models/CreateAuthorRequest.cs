﻿using CasaDoCodigo.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace CasaDoCódigo.API.Models
{
    public class CreateAuthorRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Length(1, 400)]
        public string Description { get; set; }

        public Author ToModel()
        {
            return new Author(Guid.NewGuid(), DateTime.UtcNow, Name, Email, Description);
        }
    }
}
