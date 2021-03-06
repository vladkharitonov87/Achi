﻿using System;
using System.Collections.Generic;
using Achi.Data.Entities.Base;

namespace Achi.Data.Entities
{
	public interface IUserGroup : ITypedIdEntity<Guid>, IDeletableEntity, IModifiedEntity
	{
		int Order { get; set; }
		string Name { get; set; }
		string DisplayName { get; set; }

		ICollection<IPermission> Permissions { get; set; }
		ICollection<IAccount> Accounts { get; set; }
	}
}