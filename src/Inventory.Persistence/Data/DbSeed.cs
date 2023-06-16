using Inventory.Domain.Enum;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Persistence.Data
{
	public static class DbSeed
	{
		public static void SeedDatabase(ModelBuilder modelBuilder)
			=> SeedInventoryDate(modelBuilder);

		private static void SeedInventoryDate(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Domain.Entities.Inventory>().HasData(
				Domain.Entities.Inventory.Create("laptop", "147258", "samsung laptop","Samsung", true, (int)ProductStatus.inStock),
				Domain.Entities.Inventory.Create("laptop", "147256", "lenovo laptop","Lenovo", true,(int)ProductStatus.inStock),
				Domain.Entities.Inventory.Create("laptop", "147257", "acer laptop","Acer", true,(int)ProductStatus.inStock),
				Domain.Entities.Inventory.Create("laptop", "147255", "apple laptop","Apple", true,(int)ProductStatus.inStock),
				Domain.Entities.Inventory.Create("laptop", "147259", "dell laptop","Dell", true,(int)ProductStatus.inStock),
				Domain.Entities.Inventory.Create("laptop", "147239", "dell laptop","Dell", true,(int)ProductStatus.Damaged),
				Domain.Entities.Inventory.Create("laptop", "147229", "dell laptop","Dell", true,(int)ProductStatus.Sold));
		}
	}
}
