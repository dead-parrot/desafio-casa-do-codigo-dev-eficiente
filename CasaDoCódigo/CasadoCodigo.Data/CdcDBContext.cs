using CasaDoCodigo.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CasaDoCodigo.Domain
{
    public class CdcDBContext : DbContext
    {
        public CdcDBContext(DbContextOptions options) : base(options) { }

        public DbSet<Author> Authors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>()
                .HasIndex(x => x.Email).IsUnique();
        }
    }
}
