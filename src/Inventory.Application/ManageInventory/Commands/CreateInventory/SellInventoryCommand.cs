using MediatR;
using System;
using Inventory.Application.ManageInventory.Models;

namespace Inventory.Application.ManageInventory.Commands.CreateInventory
{
	public class SellInventoryCommand: IRequest<SellProductResponse>
	{
		public SellInventoryCommand()
		{}
	
		public Guid InventoryId { get; set; }
	}
}
