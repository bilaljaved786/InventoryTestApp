using System;

namespace Inventory.Application.ManageInventory.Models
{
    public class SellProductResponse
{
        public Guid InventoryId { get; set; }

        public int ProductStatus { get; set; }
    }
}
