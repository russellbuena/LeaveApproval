﻿// <auto-generated />
using System;
using ExtCore.Data.EntityFramework.SqlServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Backend.WebApp.Migrations
{
    [DbContext(typeof(StorageContext))]
    partial class StorageContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Employees.Data.Entities.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("Created");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.Property<string>("DeleteBy");

                    b.Property<DateTimeOffset?>("Deleted");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.Property<DateTimeOffset?>("Modified");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(64);

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Leaves.Data.Entities.Leave", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("Created");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.Property<int>("EmployeeId");

                    b.Property<DateTimeOffset>("EndDate");

                    b.Property<string>("JobOverTo")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<int>("LeaveType");

                    b.Property<DateTimeOffset?>("Modified");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(64);

                    b.Property<string>("Project")
                        .HasMaxLength(60);

                    b.Property<string>("Purpose")
                        .IsRequired()
                        .HasMaxLength(65);

                    b.Property<DateTimeOffset>("StartDate");

                    b.Property<double>("TotalLeaveTaken");

                    b.HasKey("Id");

                    b.ToTable("Leaves");
                });

            modelBuilder.Entity("Leaves.Data.Entities.LeaveApprovalHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("ApprovalDate");

                    b.Property<int>("ApprovalStatus");

                    b.Property<DateTimeOffset>("Created");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.Property<int>("EmployeeId");

                    b.Property<int?>("LeaveId");

                    b.Property<DateTimeOffset?>("Modified");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(64);

                    b.HasKey("Id");

                    b.HasIndex("LeaveId");

                    b.ToTable("LeaveApprovalHistory");
                });

            modelBuilder.Entity("Leaves.Data.Entities.LeaveApprovalHistory", b =>
                {
                    b.HasOne("Leaves.Data.Entities.Leave", "Leave")
                        .WithMany("ApprovalHistory")
                        .HasForeignKey("LeaveId");
                });
#pragma warning restore 612, 618
        }
    }
}
