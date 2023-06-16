using System;
using System.Threading.Tasks;
using Inventory.Application.Interfaces.Persistence.Repositories;
using Inventory.Persistence.Data;

namespace Inventory.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;

        public UnitOfWork(ApplicationDbContext context,
            IInventoryRepository inventoryRepository)
        {
            _dbContext = context;
            InventoryRepository = inventoryRepository;
        }

        public IInventoryRepository InventoryRepository { get; }

        public Task<int> Complete() => _dbContext.SaveChangesAsync();

        private bool _disposed;

        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
