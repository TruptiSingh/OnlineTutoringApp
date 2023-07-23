using System.Linq.Expressions;

using LinqKit;

using Microsoft.EntityFrameworkCore.Storage;

using OTP.Domains.Models.BaseClasses;

namespace OTP.Repositories.Interfaces
{
	public interface IRepository<TEntity> where TEntity : ModelBase
	{
		/// <summary>
		/// Add new entity to the repository
		/// </summary>
		/// <param name="entity"></param>
		Task AddAsync(TEntity entity);

		/// <summary>
		/// Marks TEntity object as 'Updated' so that EF can update it in the database
		/// </summary>
		/// <param name="entity"></param>
		Task UpdateAsync(TEntity entity);

		/// <summary>
		/// Delete specified entity of type T from the repository
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="entity"></param>
		Task DeleteAsync(TEntity entity);

		/// <summary>
		/// Retrieves TEntity object based on the provided filter (criteria) and includes any dependent entities
		/// if specified
		/// </summary>
		/// <param name="filter"></param>
		/// <param name="includes"></param>
		/// <returns></returns>
		Task<TEntity> GetAsync(ExpressionStarter<TEntity> filter, params Expression<Func<TEntity, object>> [] includes);

		/// <summary>
		/// Retrieves collection of TEntity objects based on the provided filter (criteria)
		/// </summary>
		/// <param name="filter"></param>
		/// <param name="includes"></param>
		/// <returns></returns>
		Task<IEnumerable<TEntity>> GetAllAsync(ExpressionStarter<TEntity> filter, params Expression<Func<TEntity, object>> [] includes);

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
		Task<Tuple<IEnumerable<TEntity>, int>> GetAllAsync(ExpressionStarter<TEntity> filter,
			Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, int? skipRange = null,
			int? requiredRange = null, params Expression<Func<TEntity, object>> [] includes);

		/// <summary>
		/// Commits changes to the repository asynchronously
		/// </summary>
		/// <returns></returns>
		Task<int> CommitAsync(CancellationToken cancellationToken = default);

		/// <summary>
		/// Starts the transaction
		/// </summary>
		/// <returns></returns>
		Task<IDbContextTransaction> StartTransactionAsync();
	}
}
