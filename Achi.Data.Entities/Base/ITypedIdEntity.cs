using System;

namespace Achi.Data.Entities.Base
{
	public interface ITypedIdEntity<TId>
	{
		TId ID { get; set; }

		Guid CreatedBy { get; set; }

		DateTime CreatedOn { get; set; }
	}
}
