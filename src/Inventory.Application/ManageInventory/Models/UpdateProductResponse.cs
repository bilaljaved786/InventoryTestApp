using System;

namespace Inventory.Application.ManageInventory.Models
{
	public class UpdateProductResponse
	{
		public Guid InventoryId { get; set; }
		public int ProductStatus { get; set; }
	}
}
