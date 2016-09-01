using System.Collections.Generic;
using System.Text;
using Achi.Data.UnitOfWork;

namespace Achi.Data.SQL.UnitOfWork
{
	public abstract class Repository
	{
		protected readonly IQueryableUnitOfWork _unitOfWork;

		protected Repository(IQueryableUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		protected static string GetListAsString(IList<string> list)
		{
			if (list == null)
				return null;
			if (list.Count == 0)
				return null;

			var stringBuilder = new StringBuilder();
			foreach (string item in list)
				stringBuilder.Append(item + ',');

			return stringBuilder.ToString().TrimEnd(',');
		}
	}
}
