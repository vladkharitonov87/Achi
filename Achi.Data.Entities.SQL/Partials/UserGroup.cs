using System;
using System.Collections.Generic;
using Achi.Data.Entities.Base;
using Achi.Data.Infrastructure.Enums;

namespace Achi.Data.Entities.SQL
{
	public partial class UserGroup : IModifiedEntity<Guid>, IUserGroup
	{
		ICollection<IPermission> IUserGroup.Permissions
		{
			get { return (ICollection<IPermission>) Permissions; }

			set { Permissions = (ICollection<Permission>) value; }
		}

		ICollection<IUser> IUserGroup.Users
		{
			get { return (ICollection<IUser>) Users; }

			set { Users = (ICollection<User>) value; }
		}

		Status IDeletableEntity<Guid>.VersionStatus
		{
			get { return VersionStatus ? Status.Active : Status.Deleted; }
			set { VersionStatus = value == Status.Active; }
		}
	}
}
