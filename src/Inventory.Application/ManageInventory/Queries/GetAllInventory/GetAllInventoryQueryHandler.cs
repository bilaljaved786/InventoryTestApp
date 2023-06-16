using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Inventory.Application.Interfaces.Persistence.Repositories;
using Inventory.Application.ManageInventory.Models;

namespace Inventory.Application.ManageInventory.Queries.GetAllInventory
{
	public class GetAllInventoryQueryHandler : IRequestHandler<GetAllInventoryQuery, IEnumerable<GetAllProductStatusCountResponse>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public GetAllInventoryQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
			_mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
		}

		public async Task<IEnumerable<GetAllProductStatusCountResponse>> Handle(GetAllInventoryQuery request,CancellationToken cancellationToken)
		{
			var inventories = await _unitOfWork.InventoryRepository.GetAllCountProductsByStatus();
			return _mapper.Map<IEnumerable<GetAllProductStatusCountResponse>>(inventories);
		}
	}
}