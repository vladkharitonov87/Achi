using System;
using Achi.Data.Entities.Base;

namespace Achi.Data.Entities
{
	public interface IAccount : ITypedIdEntity<Guid>, IDeletableEntity, IModifiedEntity
	{
		string UserName { get; set; }
		string Password { get; set; }
		System.Guid UserID { get; set; }
		Guid? UserGroupID { get; set; }

		IUser User { get; set; }
		IUserGroup UserGroup { get; set; }
	}
}