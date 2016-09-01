using System;
using Achi.Data.Entities.Base;

namespace Achi.Data.Entities
{
	public interface IUser : ITypedIdEntity<Guid>, IDeletableEntity
	{
		string UserName { get; set; }
		string Password { get; set; }
		string FirstName { get; set; }
		string LastName { get; set; }
		Guid? UserGroupID { get; set; }

		IUserGroup UserGroup { get; set; }
	}
}