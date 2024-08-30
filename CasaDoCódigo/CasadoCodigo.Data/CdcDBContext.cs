using CasaDoCodigo.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CasaDoCodigo.Domain
{
    public class CdcDBContext : DbContext
    {
        public CdcDBContext(DbContextOptions options) : base(options) { }

        public DbSet<Author> Authors { get; set; }
    }
}
