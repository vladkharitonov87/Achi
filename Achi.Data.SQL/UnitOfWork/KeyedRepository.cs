using System;
using Achi.Data.Entities.Base;
using Achi.Data.UnitOfWork;

namespace Achi.Data.SQL.UnitOfWork
{
	public abstract class KeyedRepository<TEntity, TId> : Repository, IKeyedRepository<TEntity, TId> where TEntity : class
	{
		protected KeyedRepository(IQueryableUnitOfWork unitOfWork) : base(unitOfWork)
		{
		}

		/// <summary>
		/// Creates the specified entity
		/// </summary>
		/// <param name="entity">Entity to add</param>
		/// <exception cref="ArgumentNullException"> if <paramref name="entity"/> is null</exception>
		/// <typeparam name="TEntity">A POCO that represents an Entity Framework entity</typeparam>
		public virtual TEntity Create(TEntity entity)
		{
			return _unitOfWork.Create(entity);
		}

		/// <summary>
		/// Deletes the specified entity
		/// </summary>
		/// <param name="entity">Entity to delete</param>
		/// <exception cref="ArgumentNullException"> if <paramref name="entity"/> is null</exception>
		/// <typeparam name="TEntity">A POCO that represents an Entity Framework entity</typeparam>
		public virtual void Delete(TEntity entity)
		{
			if (entity is IDeletableEntity)
			{
				_unitOfWork.Delete((IDeletableEntity)entity);
			}
			else
			{
				_unitOfWork.Remove(entity);
			}
		}

		/// <summary>
		/// Deletes the entity by Id
		/// </summary>
		/// <param name="id"> </param>
		/// <exception cref="ArgumentNullException"> if <paramref name="id"/> is null</exception>
		public virtual bool DeleteById(TId id)
		{
			var entity = _unitOfWork.Find<TEntity, TId>(id);
			if (entity == null)
			{
				return false;
			}

			if (entity is IDeletableEntity)
			{
				_unitOfWork.Delete((IDeletableEntity)entity);
			}
			else
			{
				_unitOfWork.Remove(entity);
			}

			return true;
		}

		/// <summary>
		/// Deletes the entity by composite Id. Be careful with the order of columns (keyValues) when using Find (Object parameters [])
		/// </summary>
		/// <param name="keyValues">Composite Id of entity to delete</param>
		public virtual void DeleteById(params object[] keyValues)
		{
			var entity = _unitOfWork.Find<TEntity, TId>(keyValues);
			if (entity != null)
			{
				if (entity is IDeletableEntity)
				{
					_unitOfWork.Delete((IDeletableEntity)entity);
				}
				else
				{
					_unitOfWork.Remove(entity);
				}
			}
		}

		/// <summary>
		/// Updates the specified entity
		/// </summary>
		/// <param name="entity">Entity to update</param>
		/// <typeparam name="TEntity">A POCO that represents an Entity Framework entity</typeparam>
		public virtual void Update(TEntity entity)
		{
			_unitOfWork.Update(entity);
		}

		/// <summary>
		/// Gets the specified entity by Id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public virtual TEntity GetById(TId id)
		{
			return _unitOfWork.Find<TEntity, TId>(id);
		}
	}
}
