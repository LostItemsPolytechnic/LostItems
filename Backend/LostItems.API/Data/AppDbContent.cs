using LostItems.API.Models;

namespace LostItems.API.Data
{
	public class AppDbContext : DbContext
	{
		public DbSet<User> Users { get; set; }
		public DbSet<Book> Books { get; set; }
		public DbSet<Issue> Issues { get; set; }

		public AppDbContext(DbContextOptions<AppDbContext> options)
			: base(options) { }
	}
}
