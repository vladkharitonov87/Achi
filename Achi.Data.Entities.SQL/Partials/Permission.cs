using System;
using Achi.Data.Entities.Base;
using Achi.Data.Infrastructure.Enums;

namespace Achi.Data.Entities.SQL
{
	public partial class Permission : ITypedIdEntity<Guid>, IDeletableEntity, IModifiedEntity, IPermission
	{
		IPermissionType IPermission.PermissionType
		{
			get { return PermissionType; }

			set { PermissionType = (PermissionType) value; }
		}

		IUserGroup IPermission.UserGroup
		{
			get { return UserGroup; }

			set { UserGroup = (UserGroup) value; }
		}

		Status IDeletableEntity.VersionStatus
		{
			get { return VersionStatus ? Status.Active : Status.Deleted; }
			set { VersionStatus = value == Status.Active; }
		}
	}
}
