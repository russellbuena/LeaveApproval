
using System;
using System.ComponentModel.DataAnnotations;
using Leaves.Data.Entities;
using System.Text;

namespace Leaves.ViewModels
{
    public class CreateViewModels
    {

        //[Display(Name = "Leave Type")]
        // [Required()]
        public LeaveType LeaveType { get; set; }

        //[Display(Name = "Start Date")]
        // [Required()]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        //[Display(Name ="End Date")]
        // [Required()]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        //[Display(Name = "TotalLeaveTaken")]
        // [Required()]
        public double TotalLeaveTaken { get; set; }

        //[Display(Name = "Purpose")]
       // [Required()]
        public string Purpose { get; set; }

        //[Display(Name = "JobOverTo")]
       // [Required()]
        public string JobOverTo { get; set; }

        //[Display(Name = "Project")]
       // [Required()]
        public string Project { get; set; }

        //[Display(Name = "Scrum Master")]
       // [Required()]
        public string SM { get; set; }


        internal Data.Entities.Leave ToEntity()
        {
            if(IsValidLeaveRequestByLeaveType(this))
               if(IsValidLeaveRequestByRequestDateCombination(this.StartDate,this.EndDate))
                    return new Data.Entities.Leave
                    {
                        LeaveType = this.LeaveType,
                        StartDate = this.StartDate,
                        EndDate = this.EndDate,
                        TotalLeaveTaken = this.TotalLeaveTaken,
                        Purpose = this.Purpose,
                        JobOverTo = this.JobOverTo,
                        Project = this.Project,
                    };
            return null;
        }

        /*Valid Requirement:
            - Only sick leave request is allowed to request on the day of leave*/
        
        internal bool IsValidLeaveRequestByLeaveType(CreateViewModels LeaveData)
        {
            if(LeaveData.LeaveType != LeaveType.Sick_Leave)
            {
                if (LeaveData.StartDate.Date == DateTime.Now.Date)
                {

                    return false;
                }
            }

            return true;
        }


        internal bool IsValidLeaveRequestByRequestDateCombination(DateTime startDate,DateTime endDate)
        {
            var dateOnlyStartDate = startDate.Date;
            var dateOnlyEndDate = endDate.Date;
            if (dateOnlyStartDate > dateOnlyEndDate) return false;
            return true;
        }

        
    }

   }

