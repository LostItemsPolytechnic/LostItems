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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Fluent api configurations
            modelBuilder.Entity<Item>()
                .HasOne(i => i.Founder)
                .WithMany()
                .HasForeignKey(i => i.FounderId)
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<ReturnedItem>()
                .HasOne(r => r.Loster)
                .WithMany()
                .HasForeignKey(r => r.LosterId)
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<ReturnedItem>()
                .HasOne(r => r.Item)
                .WithMany()
                .HasForeignKey(r => r.ItemId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
