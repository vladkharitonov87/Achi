using Achi.Data.Entities;
using Achi.Data.Repositories;

namespace Achi.Data
{
	public interface IRepositoryFactory
	{
		IUserRepository GetUserRepository();

		IUserGroupRepository GetUserGroupRepository();

		IPermissionRepository GetPermissionRepository();

		IPermissionTypeRepository GetPermissionTypeRepository();
	}
}