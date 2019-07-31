using System;
using Employees.Data.Entities;
using Leaves.Data.Entities;


namespace Leaves.ViewModels.Leave
{
    public class LeaveDto
    {
        private Data.Entities.Leave leaveDatum;

        public LeaveDto(Data.Entities.Leave leaveDatum)
        {
            this.leaveDatum = leaveDatum;
        }

        public LeaveDto(Data.Entities.Leave leave, Employee employee)
        {
            EmployeeName = employee.FirstName + employee.LastName;
            EmployeeId = employee.Id;
            LeaveType = leave.LeaveType;
            StartDate = leave.StartDate;
            EndDate = leave.EndDate;
            Purpose = leave.Purpose;
            TotalLeaveTaken = leave.TotalLeaveTaken;
            JobOverTo = leave.JobOverTo;
            Project = leave.Project;




            Id = leave.Id;
           


        }

        public string EmployeeName { get; }
        public int EmployeeId { get; }
        public LeaveType LeaveType { get; }
        public DateTimeOffset StartDate { get; }
        public DateTimeOffset EndDate { get; }
        public string Purpose { get; }
        public double TotalLeaveTaken { get; }
        public string JobOverTo { get; }
        public string Project { get; }
        public int Id { get; }

       

    }
}