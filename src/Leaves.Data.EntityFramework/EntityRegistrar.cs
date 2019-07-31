using Leaves.Data.Entities;
using ExtCore.Data.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Employees.Data.Entities;
namespace Leaves.Data.EntityFramework.SqlServer
{
    public class EntityRegistrar : IEntityRegistrar
    {
        public void RegisterEntities(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Leave>(etb =>
            {
               etb.ToTable("Leaves");
               etb.HasKey(e => e.Id);
               //etb.Property(e =>)
               etb.Property(e => e.LeaveType).IsRequired();
               etb.Property(e => e.Purpose).HasMaxLength(65).IsRequired();
               etb.Property(e => e.JobOverTo).HasMaxLength(60).IsRequired();
               etb.Property(e => e.Project).HasMaxLength(60).IsRequired();
            });
        }
    }
}
