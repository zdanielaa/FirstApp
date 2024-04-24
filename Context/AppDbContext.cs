using FirstApp.Model;
using Microsoft.EntityFrameworkCore;

namespace FirstApp.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<BookCopy> BooksCopy { get; set; }
        public DbSet<Loan> Loans { get; set; }
    }
}
