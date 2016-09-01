using Achi.Data.Entities;
using Achi.Data.Repositories;
using Achi.Data.SQL.UnitOfWork;
using Achi.Data.UnitOfWork;

namespace Achi.Data.SQL.Repositories
{
	public class UserGroupRepository : KeyedAsGuidRepository<IUserGroup>, IUserGroupRepository
	{
		public UserGroupRepository(IQueryableUnitOfWork unitOfWork) : base(unitOfWork)
		{
		}
	}
}
