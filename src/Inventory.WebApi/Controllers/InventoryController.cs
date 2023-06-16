using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Threading.Tasks;
using Inventory.Application.ManageInventory.Commands.UpdateInventory;
using Inventory.Application.ManageInventory.Models;
using Inventory.Application.ManageInventory.Queries.GetAllInventory;
using Inventory.Application.ManageInventory.Commands.CreateInventory;

namespace Inventory.WebApi.Controllers
{

	[ApiController]
	[Route("api/[controller]/[action]")]
	public class InventoryController: ControllerBase
	{
		#region ctor

		private readonly IMediator _mediator;
		public InventoryController(IMediator mediator) =>
				_mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

		#endregion

		/// <summary>
		/// Get All Inventory Status Count
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		[SwaggerResponse(200,"Success Operation")]
		[SwaggerResponse(404,"Not Found")]
		public async Task<ActionResult<GetAllProductStatusCountResponse>> GetAllInventory()
		{
			var queryResponses = await _mediator.Send(new GetAllInventoryQuery());
			return Ok(queryResponses);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <param name="UpdateInventoryStatusCommand"></param>
		/// <returns></returns>
		[HttpPut]
		[SwaggerResponse(204,"Success Operation")]
		[SwaggerResponse(404,"Not Found")]
		[SwaggerResponse(400,"Invalid Input")]
		public async Task<IActionResult> UpdateInventoryStatusAsync(Guid id,[FromBody] UpdateInventoryStatusCommand UpdateInventoryStatusCommand)
		{
			if(id != UpdateInventoryStatusCommand.InventoryId)
				return BadRequest();

			await _mediator.Send(UpdateInventoryStatusCommand);
			return NoContent();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpPut]
		[SwaggerResponse(204,"Success Operation")]
		[SwaggerResponse(404,"Not Found")]
		[SwaggerResponse(400,"Invalid Input")]
		public async Task<IActionResult> SellInventoryAsync(Guid id)
		{
			await _mediator.Send(new SellInventoryCommand(){InventoryId = id});
			return NoContent();
		}
	}
}
