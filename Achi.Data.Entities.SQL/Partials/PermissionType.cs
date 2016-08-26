﻿using System;
using System.Collections.Generic;
using Achi.Data.Entities.Base;
using Achi.Data.Infrastructure.Enums;

namespace Achi.Data.Entities.SQL
{
	public partial class PermissionType : IModifiedEntity<Guid>, IPermissionType
	{
		ICollection<IPermission> IPermissionType.Permissions
		{
			get { return (ICollection<IPermission>) Permissions; }

			set { Permissions = (ICollection<Permission>) value; }
		}

		Status IDeletableEntity<Guid>.VersionStatus
		{
			get { return VersionStatus ? Status.Active : Status.Deleted; }
			set { VersionStatus = value == Status.Active; }
		}
	}
}