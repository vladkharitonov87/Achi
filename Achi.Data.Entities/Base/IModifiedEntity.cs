using System;

namespace Achi.Data.Entities.Base
{
	public interface IModifiedEntity
	{
		Guid CreatedBy { get; set; }

		DateTime CreatedOn { get; set; }

		Guid LastModifiedBy { get; set; }

		DateTime LastModifiedOn { get; set; }
	}
}
