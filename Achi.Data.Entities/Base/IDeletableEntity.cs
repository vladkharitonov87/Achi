using Achi.Data.Infrastructure.Enums;

namespace Achi.Data.Entities.Base
{
	public interface IDeletableEntity
	{
		Status VersionStatus { get ; set; }
	}
}
