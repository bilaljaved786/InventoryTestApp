using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Inventory.Application.Exceptions.EntityExceptions;
using Inventory.Application.Interfaces.Persistence.Repositories;
using Inventory.Application.ManageInventory.Models;

namespace Inventory.Application.ManageInventory.Commands.CreateInventory
{
	public class SellInventoryCommandHandler: IRequestHandler<SellInventoryCommand,SellProductResponse>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public SellInventoryCommandHandler(IUnitOfWork unitOfWork,IMapper mapper)
		{
			_unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
			_mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
		}

		public async Task<SellProductResponse> Handle(SellInventoryCommand request,CancellationToken cancellationToken)
		{
			var inventory = await _unitOfWork.InventoryRepository.SellProduct(request.InventoryId)
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