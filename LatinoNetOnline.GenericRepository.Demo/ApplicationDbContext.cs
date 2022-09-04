using LatinoNetOnline.GenericRepository.Demo.Entities;

using Microsoft.EntityFrameworkCore;

namespace LatinoNetOnline.GenericRepository.Demo
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Book> Books => Set<Book>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(
        new Book { Id = 1, Author = "William Shakespeare", Title = "Hamlet" },
            new Book { Id = 2, Author = "William Shakespeare", Title = "King Lear" },
            new Book { Id = 3, Author = "William Shakespeare", Title = "Othello" }
    );
        }
    }
}
