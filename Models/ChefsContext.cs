using Microsoft.EntityFrameworkCore;

namespace Chefs.Models
{
    public class ChefsContext : DbContext
    {
        public ChefsContext(DbContextOptions options) : base(options) { }

        public DbSet<Chef> Chefs { get; set; }
        public DbSet<Dish> Dishes { get; set; }
    }
}