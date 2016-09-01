using Achi.Data.Repositories;
using Achi.Data.SQL.Repositories;
using Achi.Data.UnitOfWork;

namespace Achi.Data.SQL
{
	public class SqlRepositoryFactory: IRepositoryFactory
	{
		private readonly IQueryableUnitOfWork _unitOfWork;

		private IUserRepository _userRepository;
		private IUserGroupRepository _userGroupRepository;
		private IPermissionRepository _permission;
		private IPermissionTypeRepository _permissionTypeRepository;


		public SqlRepositoryFactory(IQueryableUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public IUserRepository GetUserRepository()
		{
			return _userRepository ?? (_userRepository = new UserRepository(_unitOfWork));
		}

		public IUserGroupRepository GetUserGroupRepository()
		{
			return _userGroupRepository ?? (_userGroupRepository = new UserGroupRepository(_unitOfWork));
		}

		public IPermissionRepository GetPermissionRepository()
		{
			return _permission ?? (_permission = new PermissionRepository(_unitOfWork));
		}

		public IPermissionTypeRepository GetPermissionTypeRepository()
		{
			return _permissionTypeRepository ?? (_permissionTypeRepository = new PermissionTypeRepository(_unitOfWork));
		}
	}
}
