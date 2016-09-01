using Achi.Data.Entities;
using Achi.Data.Repositories;
using Achi.Data.SQL.UnitOfWork;
using Achi.Data.UnitOfWork;

namespace Achi.Data.SQL.Repositories
{
	public class PermissionRepository : KeyedAsGuidRepository<IPermission>, IPermissionRepository
	{
		public PermissionRepository(IQueryableUnitOfWork unitOfWork) : base(unitOfWork)
		{
		}
	}
}
