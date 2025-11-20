using Microsoft.EntityFrameworkCore;
using LostItems.API.Models;

namespace LostItems.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ReturnedItem> ReturnedItems { get; set; }
    }
}
