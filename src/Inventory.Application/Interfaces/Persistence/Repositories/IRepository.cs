using System;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.Application.Interfaces.Persistence.Repositories
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        void Add(TEntity obj);

        Task<TEntity> GetById(Guid id);

        Task<IQueryable<TEntity>> GetAll();

        void Update(TEntity obj);

        void Remove(Guid id);
    }
}
