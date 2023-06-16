using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Inventory.Application.Interfaces.Persistence.Repositories;
using Inventory.Persistence.Data;

namespace Inventory.Persistence.Repositories
{
	public abstract class Repository<TEntity>: IRepository<TEntity> where TEntity : class
	{
		private readonly ApplicationDbContext _dbContext;
		private readonly DbSet<TEntity> DbSet;

		protected Repository(ApplicationDbContext dbContext)
		{
			_dbContext = dbContext;
			DbSet = _dbContext.Set<TEntity>();
		}

		public virtual void Add(TEntity obj) => DbSet.Add(obj);

		public virtual async Task<TEntity> GetById(Guid id) => await DbSet.FindAsync(id);

		public virtual Task<IQueryable<TEntity>> GetAll() => Task.FromResult<IQueryable<TEntity>>(DbSet);

		public virtual void Update(TEntity obj) => DbSet.Update(obj);

		public virtual void Remove(Guid id) => DbSet.Remove(DbSet.Find(id));

		public void Dispose()
		{
			_dbContext.Dispose();
			GC.SuppressFinalize(this);
		}
	}
}
