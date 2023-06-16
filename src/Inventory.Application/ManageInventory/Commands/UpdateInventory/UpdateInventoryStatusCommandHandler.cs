using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Inventory.Application.Exceptions.EntityExceptions;
using Inventory.Application.Interfaces.Persistence.Repositories;
using Inventory.Application.ManageInventory.Models;

namespace Inventory.Application.ManageInventory.Commands.UpdateInventory
{
	public class UpdateInventoryStatusCommandHandler: IRequestHandler<UpdateInventoryStatusCommand,UpdateProductResponse>
	{
		private readonly IUnitOfWork _unitOfWork;

		public UpdateInventoryStatusCommandHandler(IUnitOfWork unitOfWork) 
				=> _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));

		public async Task<UpdateProductResponse> Handle(UpdateInventoryStatusCommand request,CancellationToken cancellationToken)
		{
			var inventory = await _unitOfWork.InventoryRepository.UpdateProductStatus(request.InventoryId,request.ProductStatus)
							?? throw new InventoryNotFoundException(request.InventoryId);
			
			if(inventory is { })
			{
				await _unitOfWork.Complete();
				return inventory;
			}
			return default!;
		}
	}
}
