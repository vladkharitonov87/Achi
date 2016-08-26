using System;

namespace Achi.Data.UnitOfWork
{
	public interface IKeyedAsGuidRepository<TEntity> : IKeyedRepository<TEntity, Guid>
	{
		 
	}
}