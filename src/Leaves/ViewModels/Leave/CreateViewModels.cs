
using System;
using System.ComponentModel.DataAnnotations;
using Leaves.Data.Entities;
using System.Text;

namespace Leaves.ViewModels
{
    public class CreateViewModels
    {

        public LeaveType LeaveType { get; set; }

        //[DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        //[DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        public double TotalLeaveTaken { get; set; }

        public string Purpose { get; set; }

        public string JobOverTo { get; set; }

        public string Project { get; set; }

        public string SM { get; set; }

        public int EmployeeId { get; set; }

        internal Data.Entities.Leave ToEntity()
        {
            if (IsValidLeaveRequestByLeaveType(this))
                if (IsValidLeaveRequestByRequestDateCombination(this.StartDate, this.EndDate))
                    //if(IsValidSickLeave(this))
                    return new Data.Entities.Leave
                    {
                        LeaveType = this.LeaveType,
                        StartDate = this.StartDate,
                        EndDate = this.EndDate,
                        TotalLeaveTaken = this.TotalLeaveTaken,
                        Purpose = this.Purpose,
                        JobOverTo = this.JobOverTo,
                        Project = this.Project,
                        EmployeeId = this.EmployeeId
                    };
            return null;
        }

        /*Valid Requirement:
            - Only sick leave request is allowed to request on the day of leave*/

        internal bool IsValidLeaveRequestByLeaveType(CreateViewModels LeaveData)
        {
            if (LeaveData.LeaveType != LeaveType.Sick_Leave)
            {
                if (LeaveData.StartDate.Date == DateTime.Now.Date)
                {

                    return false;
                }
            }

            return true;
        }
        internal bool IsValidSickLeave(CreateViewModels SickLeave)
        {
            var startDateSick = StartDate.Date;
            return SickLeave.StartDate.Date == DateTime.Now.Date;
        }


        internal bool IsValidLeaveRequestByRequestDateCombination(DateTime startDate, DateTime endDate)
        {
            var dateOnlyStartDate = startDate.Date;
            var dateOnlyEndDate = endDate.Date;
            if (dateOnlyStartDate > dateOnlyEndDate) return false;
            return true;
        }


    }

}

