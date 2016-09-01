using System;

namespace Achi.Data.UnitOfWork
{
	public interface IKeyedRepository<TEntity, in TId>
	{
		/// <summary>
		/// Creates the specified entity
		/// </summary>
		/// <param name="entity">Entity to add</param>
		/// <exception cref="ArgumentNullException"> if <paramref name="entity"/> is null</exception>
		/// <typeparam name="TEntity">A POCO that represents an Entity Framework entity</typeparam>
		TEntity Create(TEntity entity);

		/// <summary>
		/// Deletes the specified entity
		/// </summary>
		/// <param name="entity">Entity to delete</param>
		/// <exception cref="ArgumentNullException"> if <paramref name="entity"/> is null</exception>
		/// <typeparam name="TEntity">A POCO that represents an Entity Framework entity</typeparam>
		void Delete(TEntity entity);

		/// <summary>
		/// Deletes the entity by Id
		/// </summary>
		/// <param name="id"> </param>
		/// <exception cref="ArgumentNullException"> if <paramref name="id"/> is null</exception>
		/// <typeparam name="TId">A type of entity Id</typeparam>
		bool DeleteById(TId id);

		/// <summary>
		/// Deletes the entity by composite Id. Be careful with the order of columns (keyValues) when using Find (Object parameters [])
		/// </summary>
		/// <param name="keyValues">Composite Id of entity to delete</param>
		/// <exception cref="ArgumentNullException"> if <paramref name="id"/> is null</exception>        
		void DeleteById(params object[] keyValues);

		/// <summary>
		/// Updates the specified entity
		/// </summary>
		/// <param name="entity">Entity to update</param>
		/// <typeparam name="TEntity">A POCO that represents an Entity Framework entity</typeparam>
		void Update(TEntity entity);

		/// <summary>
		/// Gets the specified entity by Id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		TEntity GetById(TId id);
	}
}