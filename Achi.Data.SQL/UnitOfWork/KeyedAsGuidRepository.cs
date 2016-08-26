using System;
using Achi.Data.Entities.Base;
using Achi.Data.UnitOfWork;

namespace Achi.Data.SQL.UnitOfWork
{
	public abstract class KeyedAsGuidRepository<TEntity> : KeyedRepository<TEntity, Guid>, IKeyedAsGuidRepository<TEntity> where TEntity : class, ITypedIdEntity<Guid>
	{
		protected KeyedAsGuidRepository(IQueryableUnitOfWork unitOfWork)
			: base(unitOfWork)
		{
		}

		/// <summary>
		/// Creates the specified entity
		/// </summary>
		/// <param name="entity">Entity to add</param>
		/// <exception cref="ArgumentNullException"> if <paramref name="entity"/> is null</exception>
		/// <typeparam name="TEntity">A POCO that represents an Entity Framework entity</typeparam>
		public override TEntity Create(TEntity entity)
		{
			entity.ID = Guid.NewGuid();
			return base.Create(entity);
		}
	}
}
