using Achi.Data.Infrastructure.Enums;

namespace Achi.Data.Entities.Base
{
	public class DeletableEntity<TId> : TypedIdEntity<TId>
	{
		public Status VersionStatus { get; set; }
	}
}
