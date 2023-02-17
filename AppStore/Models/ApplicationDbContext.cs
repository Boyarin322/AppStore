using Microsoft.EntityFrameworkCore;

namespace AppStore.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
            Database.EnsureCreated();
        }
        public DbSet<Product> Products { get; set; }

        public DbSet<User> Users { get; set; }
    }
}
