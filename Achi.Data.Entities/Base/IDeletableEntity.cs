using Achi.Data.Infrastructure.Enums;

namespace Achi.Data.Entities.Base
{
	public interface IDeletableEntity<TId> : ITypedIdEntity<TId>
	{
		Status VersionStatus { get ; set; }
	}
}
