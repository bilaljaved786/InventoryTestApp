using Inventory.Application.ManageInventory.Models;
using Inventory.Domain.Enum;
using MediatR;
using System;

namespace Inventory.Application.ManageInventory.Commands.UpdateInventory
{
	public class UpdateInventoryStatusCommand: IRequest<UpdateProductResponse>
	{
		public UpdateInventoryStatusCommand()
		{ }

		public Guid InventoryId { get; set; }
		public int ProductStatus { get;  set; }
	}
}
