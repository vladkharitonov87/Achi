using System;

namespace Achi.Data.Entities.Base
{
	public interface IModifiedEntity
	{
		Guid LastModifiedBy { get; set; }

		DateTime LastModifiedOn { get; set; }
	}
}
