using MediatR;
using System.Collections.Generic;
using Inventory.Application.ManageInventory.Models;

namespace Inventory.Application.ManageInventory.Queries.GetAllInventory
{
	public class GetAllInventoryQuery: IRequest<IEnumerable<GetAllProductStatusCountResponse>>
	{ }
}
