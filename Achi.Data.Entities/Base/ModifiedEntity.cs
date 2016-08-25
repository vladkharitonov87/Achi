using System;

namespace Achi.Data.Entities.Base
{
	public class ModifiedEntity<TId>: DeletableEntity<TId>
	{
		public Guid CreatedBy { get; set; }

		public DateTime CreatedOn { get; set; }

		public Guid LastModifiedBy { get; set; }

		public DateTime LastModifiedOn { get; set; }
	}
}
