using System;
using System.Collections.Generic;

namespace Achi.Data.Entities
{
	public interface IPermissionType
	{
		Guid ID { get; set; }
		int Order { get; set; }
		string Name { get; set; }
		string DisplayName { get; set; }
		bool VersionStatus { get; set; }
		Guid CreatedBy { get; set; }
		DateTime CreatedOn { get; set; }
		Guid LastModifiedBy { get; set; }
		DateTime LastModifiedOn { get; set; }

		ICollection<IPermission> Permissions { get; set; }
	}
}