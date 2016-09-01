using Achi.Data.Entities;
using Achi.Data.Repositories;
using Achi.Data.SQL.UnitOfWork;
using Achi.Data.UnitOfWork;

namespace Achi.Data.SQL.Repositories
{
	public class UserRepository : KeyedAsGuidRepository<IUser>, IUserRepository
	{
		public UserRepository(IQueryableUnitOfWork unitOfWork) : base(unitOfWork)
		{
		}
	}
}
