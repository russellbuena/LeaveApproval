﻿using System;
using Data.EntityFramework.SqlServer;
using Leaves.Data.Entities;
using Leaves.Data.Abstraction;


namespace Leaves.Data.EntityFramework.SqlServer
{
    public class RoleRepository : Repository<Role>, IRolesRepository
    {
    }
}
