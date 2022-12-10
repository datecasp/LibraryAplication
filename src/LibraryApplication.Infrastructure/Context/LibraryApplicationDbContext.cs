using LibraryApplication.Domain.Models;
using LibraryApplication.Infrastructure.Helpers;
using Microsoft.EntityFrameworkCore;

namespace LibraryApplication.Infrastructure.Context
{
    public class LibraryApplicationDbContext : DbContext
    {
        public LibraryApplicationDbContext
            (DbContextOptions<LibraryApplicationDbContext> options) : base(options) { }

        public DbSet<Book>? Books { get; set; }
        public DbSet<User>? Users { get; set; }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<BookUser>? BookUsers { get; set; }
        public DbSet<BookCategory>? BookCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            DbSeeder.Seed(builder);
        }

        internal void SaveBookCategoryChanges()
        {
            throw new NotImplementedException();
        }
    }
}
