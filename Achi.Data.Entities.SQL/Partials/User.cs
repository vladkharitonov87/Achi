﻿using System;
using Achi.Data.Entities.Base;

namespace Achi.Data.Entities.SQL
{
	public partial class User : DeletableEntity<Guid>, IUser
	{
	}
}
