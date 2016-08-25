using System;

namespace Achi.Data.SQL.UnitOfWork
{
	public interface IUnitOfWork : IDisposable
	{
		void SaveChanges();
	}
}
