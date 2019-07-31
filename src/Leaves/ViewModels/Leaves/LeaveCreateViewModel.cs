
using System;
using System.ComponentModel.DataAnnotations;
using Leaves.Data.Entities;
using System.Text;

namespace Leaves.ViewModels.Leaves
{
    public class LeaveCreateViewModel
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
                if (IsValidLeaveRequestByRequestDateCombination(StartDate, EndDate))
                    //if(IsValidSickLeave(this))
                    return new Data.Entities.Leave
                    {
                        LeaveType = LeaveType,
                        StartDate = StartDate,
                        EndDate = EndDate,
                        TotalLeaveTaken = TotalLeaveTaken,
                        Purpose = Purpose,
                        JobOverTo = JobOverTo,
                        Project = Project,
                        EmployeeId = EmployeeId
                    };
            return null;
        }

        /*Valid Requirement:
            - Only sick leave request is allowed to request on the day of leave*/

        internal bool IsValidLeaveRequestByLeaveType(LeaveCreateViewModel LeaveData)
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
        internal bool IsValidSickLeave(LeaveCreateViewModel SickLeave)
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

