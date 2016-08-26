using System;
using Achi.Data.Entities.Base;

namespace Achi.Data.Entities
{
	public interface IPermission : ITypedIdEntity<Guid>, IDeletableEntity, IModifiedEntity
	{
		Guid UserGroupID { get; set; }
		Guid PermissionID { get; set; }

		IPermissionType PermissionType { get; set; }
		IUserGroup UserGroup { get; set; }
	}
}