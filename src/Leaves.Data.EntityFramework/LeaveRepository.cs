using System;
using Data.EntityFramework.SqlServer;
using Leaves.Data.Entities;
using Leaves.Data.Abstraction;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Leaves.Data.EntityFramework.SqlServer
{
    public class LeaveRepository : Repository<Leave>, ILeavesRepository
    {
        public override Leave WithKey(int id)
        {
            return dbSet.Include(o => o.ApprovalHistory).FirstOrDefault(o => o.Id == id);
        }
    }
}
