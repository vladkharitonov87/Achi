using System;
using Achi.Data.Entities.Base;

namespace Achi.Data.Entities
{
	public interface IUser : ITypedIdEntity<Guid>, IDeletableEntity, IModifiedEntity
	{
		string FirstName { get; set; }
		string LastName { get; set; }
	}
}