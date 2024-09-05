using CasaDoCodigo.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CasaDoCodigo.Domain
{
    public class CdcDBContext : DbContext
    {
        public CdcDBContext(DbContextOptions options) : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>()
                .HasIndex(x => x.Email).IsUnique();

            modelBuilder.Entity<Category>()
                .HasIndex(x => x.Name).IsUnique();
            
            modelBuilder.Entity<Book>()
                .HasIndex(x => x.ISBN).IsUnique();

            modelBuilder.Entity<Book>()
                .HasIndex(x => x.Title).IsUnique();

            modelBuilder.Entity<Country>()
                .HasIndex(x => x.Name).IsUnique();

            modelBuilder.Entity<State>()
                .HasIndex(x => x.Name).IsUnique();
        }
    }
}
