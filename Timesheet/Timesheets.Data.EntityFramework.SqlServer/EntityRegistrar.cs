using Timesheets.Data.Entities;
using ExtCore.Data.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Timesheets.Data.EntityFramework.SqlServer
{
    public class EntityRegistrar : IEntityRegistrar
    {
        public void RegisterEntities(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Timesheet>(etb => {
                etb.ToTable("Timesheets");
                etb.HasKey(e => e.Id);

                etb.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelbuilder.Entity<EmployeeDetail>(etb => {
                etb.ToTable("EmployeeDetails");
                etb.HasKey(e => e.Id);

                etb.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelbuilder.Entity<Project>(etb => {
                etb.ToTable("Projects");
                etb.HasKey(e => e.Id);

                etb.Property(p => p.ProjectName).HasMaxLength(225).IsRequired();
                etb.Property(p => p.ClientName).HasMaxLength(225).IsRequired();
                etb.Property(p => p.ProjectStatus).HasMaxLength(25).IsRequired();

                //Database Relation
                etb.HasMany(m => m.Sprints).WithOne(w => w.Project).HasForeignKey(f => f.ProjectId);

                etb.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelbuilder.Entity<Sprint>(etb => {
                etb.ToTable("Sprints");
                etb.HasKey(e => e.Id);

                //Database Relation
                etb.HasMany(m => m.Tasks).WithOne(w => w.Sprint).HasForeignKey(f => f.SprintId);
                etb.HasMany(m => m.Timesheets).WithOne(w => w.Sprint).HasForeignKey(f => f.SprintId);

                etb.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelbuilder.Entity<Task>(etb => {
                etb.ToTable("Tasks");
                etb.HasKey(e => e.Id);

                etb.Property(p => p.TaskName).HasMaxLength(225).IsRequired();

                etb.Property(e => e.Id).ValueGeneratedOnAdd();
            });
        }
    }
}
