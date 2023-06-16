using System;
using System.Threading.Tasks;

namespace Inventory.Application.Interfaces.Persistence.Repositories
{
	public interface IUnitOfWork : IDisposable
    {
        IInventoryRepository InventoryRepository { get; }

        Task<int> Complete();
    }
}
