namespace Achi.Data.Entities.SQL
{
	public partial class Permission : IPermission
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
	}
}
