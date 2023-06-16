using System;
using Inventory.Application.ManageInventory.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Inventory.Application.Interfaces.Persistence.Repositories
{
	public interface IInventoryRepository: IRepository<Domain.Entities.Inventory>
	{
		 Task<List<GetAllProductStatusCountResponse>> GetAllCountProductsByStatus();
		 Task<UpdateProductResponse> UpdateProductStatus(Guid id, int newProductStatus);
		 Task<SellProductResponse> SellProduct(Guid id);
	}
}
