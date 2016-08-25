using System;

namespace Achi.Data.Entities
{
	public interface IPermission
	{
		Guid ID { get; set; }
		Guid UserGroupID { get; set; }
		Guid PermissionID { get; set; }
		bool VersionStatus { get; set; }
		Guid CreatedBy { get; set; }
		DateTime CreatedOn { get; set; }
		Guid LastModifiedBy { get; set; }
		DateTime LastModifiedOn { get; set; }
	}
}