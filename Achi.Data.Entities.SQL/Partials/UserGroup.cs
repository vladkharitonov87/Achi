using System;
using System.Collections.Generic;
using Achi.Data.Entities.Base;
using Achi.Data.Infrastructure.Enums;

namespace Achi.Data.Entities.SQL
{
	public partial class UserGroup : IUserGroup
	{
		ICollection<IPermission> IUserGroup.Permissions
		{
			get { return (ICollection<IPermission>) Permissions; }

			set { Permissions = (ICollection<Permission>) value; }
		}

		ICollection<IAccount> IUserGroup.Accounts
		{
			get { return (ICollection<IAccount>)Accounts; }

			set { Accounts = (ICollection<Account>) value; }
		}

		Status IDeletableEntity.VersionStatus
		{
			get { return VersionStatus ? Status.Active : Status.Deleted; }
			set { VersionStatus = value == Status.Active; }
		}
	}
}
