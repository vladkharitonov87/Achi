using System;

namespace Achi.Data
{
	public interface IKeyedAsGuidRepository<TEntity> : IKeyedRepository<TEntity, Guid>
	{
		 
	}
}