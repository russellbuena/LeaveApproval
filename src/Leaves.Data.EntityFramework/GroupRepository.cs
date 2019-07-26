using System;
using Data.EntityFramework.SqlServer;
using Leaves.Data.Entities;
using Leaves.Data.Abstraction;

namespace Leaves.Data.EntityFramework.SqlServer
{
    public class GroupRepository : Repository<Group>, IGroupsRepository
    { }
        
}

