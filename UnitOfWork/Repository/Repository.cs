using Microsoft.EntityFrameworkCore;
using UnitOfWork.Data;
using UnitOfWork.Interfaces;

namespace UnitOfWork.UnitOfWork
{
	public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
	{
		private DbSet<TEntity> _dbSet;

		public Repository(DataContext context)
		{
			this._dbSet = context.Set<TEntity>();
		}

		public void Delete(TEntity entity)
		{
			_dbSet.Remove(entity);
		}

		public IEnumerable<TEntity> GetAll()
		{
            return _dbSet;
		}

		public async Task<TEntity?> GetById(int? id)
		{
			return await _dbSet.FindAsync(id);
		}

		public void Insert(TEntity entity)
		{
			_dbSet.Add(entity);
		}


		public void Update(TEntity entity)
		{
			_dbSet.Update(entity);
		}
	}
}