using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventory.Application.Interfaces.Persistence.Repositories;
using Inventory.Persistence.Data;
using Inventory.Application.ManageInventory.Models;
using Inventory.Domain.Enum;

namespace Inventory.Persistence.Repositories
{
	public class InventoryRepository: Repository<Domain.Entities.Inventory>, IInventoryRepository
	{
		private readonly DbSet<Domain.Entities.Inventory> DbSetInventory;

		public InventoryRepository(ApplicationDbContext dbContext) : base(dbContext)
		{
			DbSetInventory = dbContext.Set<Domain.Entities.Inventory>();
		}

		public async Task<List<GetAllProductStatusCountResponse>> GetAllCountProductsByStatus()
		{
			return await DbSetInventory
				.GroupBy(p => p.ProductStatus)
							.Select(g => new GetAllProductStatusCountResponse() 
								{ ProductStatus = g.Key,Count = g.Count() }).ToListAsync();
		}

		public async Task<SellProductResponse> SellProduct(Guid id)
		{
			var product = await DbSetInventory.FindAsync(id);

			if(product is { } && product.ProductStatus != (int)ProductStatus.Sold)
			{
				product.SellProduct((int)ProductStatus.Sold);
				return new SellProductResponse
				{
					InventoryId = product.Id,
					ProductStatus = (int)ProductStatus.Sold,
				};
			}
			return default!;
		}

		public async Task<UpdateProductResponse> UpdateProductStatus(Guid id,int newProductStatus)
		{
			var product = await DbSetInventory.FindAsync(id);

			if(product is { })
			{
				product.UpdateProduct(newProductStatus);
				return new UpdateProductResponse
				{
					InventoryId = product.Id,
					ProductStatus = newProductStatus,
				};
			}
			return default!;
		}
	}
}
