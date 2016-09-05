using System.Collections.Generic;

namespace Achi.Data.Entities.SQL
{
	public partial class PermissionType : IPermissionType
	{
		ICollection<IPermission> IPermissionType.Permissions
		{
			get { return (ICollection<IPermission>) Permissions; }

			set { Permissions = (ICollection<Permission>) value; }
		}
	}
}
