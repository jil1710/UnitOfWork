using UnitOfWork.Data;
using UnitOfWork.Interfaces;
using UnitOfWork.UnitOfWork;

namespace UnitOfWork.Repo
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly DataContext _context;
		private Dictionary<Type, object> _repositories;

		public UnitOfWork(DataContext context)
		{
			_context = context;
			_repositories = new Dictionary<Type, object>();
		}



		public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
		{
			if (_repositories.ContainsKey(typeof(TEntity)))
			{
				return (IRepository<TEntity>)_repositories[typeof(TEntity)];
			}

			var repository = new Repository<TEntity>(_context);
			_repositories.Add(typeof(TEntity), repository);
			return repository;
		}

		public async Task SaveChangesAsync()
		{
			await _context.SaveChangesAsync();
		}

		public void Dispose()
		{
			_context.Dispose();
		}
	}
}
