using Achi.Data.Entities;
using Achi.Data.Repositories;
using Achi.Data.SQL.UnitOfWork;
using Achi.Data.UnitOfWork;

namespace Achi.Data.SQL.Repositories
{
	public class AccountRepository : KeyedAsGuidRepository<IAccount>, IAccountRepository
	{
		public AccountRepository(IQueryableUnitOfWork unitOfWork) : base(unitOfWork)
		{
		}
	}
}
