using System;
using Achi.Data.Entities.Base;
using Achi.Data.Infrastructure.Enums;

namespace Achi.Data.Entities.SQL
{
	public partial class User : IDeletableEntity<Guid>, IUser
	{
		IUserGroup IUser.UserGroup
		{
			get { return UserGroup; }

			set { UserGroup = (UserGroup) value; }
		}

		Status IDeletableEntity<Guid>.VersionStatus
		{
			get { return VersionStatus ? Status.Active : Status.Deleted; }
			set { VersionStatus = value == Status.Active; }
		}
	}
}
