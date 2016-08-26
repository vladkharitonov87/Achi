using System;

namespace Achi.Data.Entities
{
	public interface IUser
	{
		Guid ID { get; set; }
		string UserName { get; set; }
		string Password { get; set; }
		string FirstName { get; set; }
		string LastName { get; set; }
		Guid? UserGroupID { get; set; }
		bool VersionStatus { get; set; }

		IUserGroup UserGroup { get; set; }
	}
}