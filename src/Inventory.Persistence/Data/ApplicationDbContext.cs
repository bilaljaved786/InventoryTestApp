using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Inventory.Persistence.Data
{
	public class ApplicationDbContext: DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{ }

		public DbSet<Domain.Entities.Inventory> Inventory => Set<Domain.Entities.Inventory>();

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
			DbSeed.SeedDatabase(modelBuilder);
		}
	}
}
