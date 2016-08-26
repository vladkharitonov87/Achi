using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Achi.Data.Entities.Base;

namespace Achi.Data.UnitOfWork
{
	public interface IQueryableUnitOfWork : IUnitOfWork
	{
		int ExecuteSqlCommand(string sql, params SqlParameter[] parameters);

		IEnumerable<TEntity> SelectEntities<TEntity>(string procedure, params SqlParameter[] parameters);

		/// <summary>
		/// Gets the specified entity by Id
		/// </summary>
		/// <typeparam name="TEntity">A POCO that represents an Entity Framework entity</typeparam>
		/// <typeparam name="TId">An entity Id</typeparam>
		TEntity Find<TEntity, TId>(TId id) where TEntity : class;

		/// <summary>
		/// Gets the specified entity by composite Id. Be careful with the order of columns  (keyValues) when using Find (Object parameters [])
		/// </summary>
		/// <typeparam name="TEntity">A POCO that represents an Entity Framework entity</typeparam>
		/// <typeparam name="TId">An entity Id</typeparam>
		TEntity Find<TEntity, TId>(params object[] keyValues) where TEntity : class;

		/// <summary>
		/// Gets queryable dataset
		/// </summary>
		/// <typeparam name="TEntity">A POCO that represents an Entity Framework entity</typeparam>
		IQueryable<TEntity> AsQueryableFor<TEntity>()
			where TEntity : class;

		/// <summary>
		/// Gets queryable dataset
		/// </summary>
		/// <typeparam name="TEntity">A POCO that represents an Entity Framework entity</typeparam>
		IQueryable<TEntity> AsQueryableForWithTracking<TEntity>() where TEntity : class;

		/// <summary>
		/// Creates the specified entity
		/// </summary>
		/// <param name="entity">Entity to add</param>
		/// <exception cref="ArgumentNullException"> if <paramref name="entity"/> is null</exception>
		/// <typeparam name="TEntity">A POCO that represents an Entity Framework entity</typeparam>
		TEntity Create<TEntity>(TEntity entity)
			where TEntity : class;

		/// <summary>
		/// Deletes the specified entity
		/// </summary>
		/// <param name="entity">Entity to delete</param>
		/// <exception cref="ArgumentNullException"> if <paramref name="entity"/> is null</exception>
		/// <typeparam name="TEntity">A POCO that represents an Entity Framework entity</typeparam>
		void Delete<TEntity>(TEntity entity)
			where TEntity : class, IDeletableEntity;

		/// <summary>
		/// Deletes the specified entity
		/// </summary>
		/// <param name="entity">Entity to delete</param>
		/// <exception cref="ArgumentNullException"> if <paramref name="entity"/> is null</exception>
		/// <typeparam name="TEntity">A POCO that represents an Entity Framework entity</typeparam>
		void Remove<TEntity>(TEntity entity)
			where TEntity : class;

		/// <summary>
		/// Updates the specified entity
		/// </summary>
		/// <param name="entity">Entity to update</param>
		/// <typeparam name="TEntity">A POCO that represents an Entity Framework entity</typeparam>
		void Update<TEntity>(TEntity entity)
			where TEntity : class;

		/// <summary>
		/// Commit all changes
		/// </summary>
		void Commit();

		/// <summary>
		/// Detect all changes
		/// </summary>
		void DetectChanges();
	}
}
