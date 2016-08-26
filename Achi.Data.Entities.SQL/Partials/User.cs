using System;
using Achi.Data.Entities.Base;
using Achi.Data.Infrastructure.Enums;

namespace Achi.Data.Entities.SQL
{
	public partial class User : ITypedIdEntity<Guid>, IDeletableEntity, IUser
	{
		IUserGroup IUser.UserGroup
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
