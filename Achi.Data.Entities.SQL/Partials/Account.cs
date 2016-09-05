using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Achi.Data.Entities.Base;
using Achi.Data.Infrastructure.Enums;

namespace Achi.Data.Entities.SQL
{
	public partial class Account : IAccount
	{
		IUser IAccount.User
		{
			get { return User; }

			set { User = (User) value; }
		}

		IUserGroup IAccount.UserGroup
		{
			get { return UserGroup; }

			set { UserGroup = (UserGroup)value; }
		}

		Status IDeletableEntity.VersionStatus
		{
			get { return VersionStatus ? Status.Active : Status.Deleted; }
			set { VersionStatus = value == Status.Active; }
		}
	}
}
