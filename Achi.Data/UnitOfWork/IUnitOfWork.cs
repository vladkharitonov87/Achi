using System;

namespace Achi.Data.UnitOfWork
{
	public interface IUnitOfWork : IDisposable
	{
		void SaveChanges();
	}
}
