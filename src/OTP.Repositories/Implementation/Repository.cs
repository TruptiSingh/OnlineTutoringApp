using System.Diagnostics;
using System.Linq.Expressions;

using LinqKit;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

using OTP.Domains.Models.BaseClasses;
using OTP.Repositories.Interfaces;

namespace OTP.Repositories.Implementation
{
	public class Repository<TEntity> : IRepository<TEntity> where TEntity : ModelBase
	{
		#region Private Variables

		private readonly OTPDbContext _context;

		#endregion

		#region Constructor

		/// <summary>
		/// Public constructor
		/// </summary>
		/// <param name="context"></param>
		public Repository(OTPDbContext context)
		{
			_context = context;
		}

		#endregion

		#region Public Methods

		/// <summary>
		/// Add new entity to the repository
		/// </summary>
		/// <param name="entity"></param>
		public async Task AddAsync(TEntity entity)
		{
			await _context.Set<TEntity>().AddAsync(entity);
		}

		/// <summary>
		/// Add collection of entities to the repository
		/// </summary>
		/// <param name="entities"></param>
		/// <returns></returns>
		public async Task AddRangeAsync(ICollection<TEntity> entities)
		{
			await _context.Set<TEntity>().AddRangeAsync(entities);
		}

		/// <summary>
		/// Marks TEntity object as 'Updated' so that EF can update it in the database
		/// </summary>
		/// <param name="entity"></param>
		public Task UpdateAsync(TEntity entity)
		{
			_context.Set<TEntity>().Attach(entity);
			_context.Entry(entity).State = EntityState.Modified;

			entity.ModifiedDate = DateTime.UtcNow;

			return Task.CompletedTask;
		}

		/// <summary>
		/// Delete specified entity of type TEntity from the repository
		/// </summary>
		/// <param name="entity"></param>
		public Task DeleteAsync(TEntity entity)
		{
			if (entity == null)
			{
				Debug.Assert(false, "Trying to delete a null entity");
			}

			_context.Set<TEntity>().Remove(entity);

			return Task.CompletedTask;
		}

		/// <summary>
		/// Delete specified entities of type TEntity from the repository
		/// </summary>
		/// <param name="entity"></param>
		public Task DeleteRangeAsync(ICollection<TEntity> entities)
		{
			_context.Set<TEntity>().RemoveRange(entities);

			return Task.CompletedTask;
		}

		/// <summary>
		/// Retrieves TEntity object based on the provided filter (criteria) and includes any dependent entities
		/// if specified
		/// </summary>
		/// <param name="filter"></param>
		/// <param name="includes"></param>
		/// <returns></returns>
		public async Task<TEntity> GetAsync(ExpressionStarter<TEntity> filter, params Expression<Func<TEntity, object>> [] includes)
		{
			IQueryable<TEntity> query = _context.Set<TEntity>();

			if (includes != null && includes.Length > 0)
			{
				foreach (var include in includes)
				{
					query = query.Include(include);
				}
			}

			TEntity entity = await query.FirstOrDefaultAsync(filter);

			return entity;
		}

		/// <summary>
		/// Retrieves collection of TEntity objects based on the provided filter (criteria) and includes any dependent
		/// entities, orders them by the criteria, if specified. This method also supports paging and returns total
		/// number of records retrieved by the specified criteria
		/// </summary>
		/// <param name="filter"></param>
		/// <param name="totalRecordsCount"></param>
		/// <param name="orderBy"></param>
		/// <param name="skipRange"></param>
		/// <param name="requiredRange"></param>
		/// <param name="includes"></param>
		/// <returns></returns>
		public async Task<Tuple<IEnumerable<TEntity>, int>> GetAllAsync(ExpressionStarter<TEntity> filter,
			Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, int? skipRange = null,
			int? requiredRange = null, params Expression<Func<TEntity, object>> [] includes)
		{
			IQueryable<TEntity> query = _context.Set<TEntity>();

			int totalRecordsCount = 0;

			if (filter != null)
			{
				totalRecordsCount = query.Where(filter).Count();

				if (skipRange.HasValue && requiredRange.HasValue)
				{
					query = query.Where(filter).Skip(skipRange.Value).Take(requiredRange.Value);
				}
				else
				{
					query = query.Where(filter);
				}
			}

			if (includes != null && includes.Length > 0)
			{
				foreach (var include in includes)
				{
					query = query.Include(include);
				}
			}

			if (orderBy != null)
			{
				query = orderBy(query);
			}

			var entities = await query.ToListAsync();

			var tuple = new Tuple<IEnumerable<TEntity>, int>(entities, totalRecordsCount);

			return tuple;
		}

		/// <summary>
		/// Retrieves collection of TEntity objects based on the provided filter (criteria)
		/// </summary>
		/// <param name="filter"></param>
		/// <param name="includes"></param>
		/// <returns></returns>
		public async Task<IEnumerable<TEntity>> GetAllAsync(ExpressionStarter<TEntity> filter,
			params Expression<Func<TEntity, object>> [] includes)
		{
			IQueryable<TEntity> query = _context.Set<TEntity>().Where(filter);

			if (includes != null && includes.Length > 0)
			{
				foreach (var include in includes)
				{
					query = query.Include(include);
				}
			}

			return await query.ToListAsync();
		}

		/// <summary>
		/// Commits changes to the repository asynchronously
		/// </summary>
		/// <returns></returns>
		public async Task<int> CommitAsync(CancellationToken cancellationToken = default)
		{
			BeforeSavingChanges();

			return await _context.SaveChangesAsync(cancellationToken);
		}

		/// <summary>
		/// Starts the transaction
		/// </summary>
		/// <returns></returns>
		public async Task<IDbContextTransaction> StartTransactionAsync()
		{
			return await _context.Database.BeginTransactionAsync();
		}

		#endregion

		#region Private Methods

		private void BeforeSavingChanges()
		{
			_context.ChangeTracker.DetectChanges();

			foreach (var entry in _context.ChangeTracker.Entries())
			{
				var entity = entry.Entity as ModelBase;

				if (entry.State == EntityState.Added)
				{
					entity.CreatedDate = DateTime.UtcNow;

					entity.ModifiedDate = DateTime.UtcNow;

					entity.IsDeleted = false;
				}

				if (entry.State == EntityState.Modified)
				{
					entity.ModifiedDate = DateTime.UtcNow;
				}
			}
		}

		#endregion
	}
}
