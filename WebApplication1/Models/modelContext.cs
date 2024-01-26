using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class modelContext : DbContext
    {
        public modelContext(DbContextOptions<modelContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
