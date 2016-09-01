using Achi.Data.Entities;
using Achi.Data.Repositories;
using Achi.Data.SQL.UnitOfWork;
using Achi.Data.UnitOfWork;

namespace Achi.Data.SQL.Repositories
{
	public class PermissionTypeRepository : KeyedAsGuidRepository<IPermissionType>, IPermissionTypeRepository
	{
		public PermissionTypeRepository(IQueryableUnitOfWork unitOfWork) : base(unitOfWork)
		{
		}
	}
}
