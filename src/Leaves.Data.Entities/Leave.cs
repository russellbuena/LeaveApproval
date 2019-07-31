using System;
using Data.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Employees.Data.Entities;
using System.Collections;
using System.Collections.Generic;

namespace Leaves.Data.Entities
{
    public class Leave : Entity, IApprovalLeaveForm
    {
        public LeaveType LeaveType { get; set; }

        [DataType(DataType.Date)]
        public DateTimeOffset StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTimeOffset EndDate { get; set; }

        public double TotalLeaveTaken { get; set; }
        public string Purpose { get; set; }
        public string JobOverTo { get; set; }
        public string Project { get; set; }

        public int EmployeeId { get; set; }

        public virtual ICollection<LeaveApprovalHistory> ApprovalHistory { get; set; }

        public bool HumanResourceDeptApproved(int hrStaffEmployeeId, string currentUsername)
        {
            this.ApprovalHistory.Add(new LeaveApprovalHistory
            {
                ApprovalDate = DateTime.Now,
                ApprovalStatus = ApprovalStatus.ApprovedByHR,
                Leave = this,
                EmployeeId = hrStaffEmployeeId,
                CreatedBy = currentUsername,
                Created = DateTime.Now
            });

            return true;
        }

        public bool HumanResourceDeptRejected(int hrStaffEmployeeId, string currentUsername)
        {
            this.ApprovalHistory.Add(new LeaveApprovalHistory
            {
                ApprovalDate = DateTime.Now,
                ApprovalStatus = ApprovalStatus.RejectedbyHR,
                Leave = this,
                EmployeeId = hrStaffEmployeeId,
                CreatedBy = currentUsername,
                Created = DateTime.Now
            });

            return true;
        }

        public bool ScrumMasterApproved(int scrumMasterEmployeeId, string currentUsername)
        {
            this.ApprovalHistory.Add(new LeaveApprovalHistory
            {
                ApprovalDate = DateTime.Now,
                ApprovalStatus = ApprovalStatus.ApprovedBySM,
                Leave = this,
                EmployeeId = scrumMasterEmployeeId,
                Created = DateTime.Now,
                CreatedBy = currentUsername
            });

            return true;
        }

        public bool ScrumMasterRejected(int scrumMasterEmployeeId, string currentUsername)
        {
            this.ApprovalHistory.Add(new LeaveApprovalHistory
            {
                ApprovalDate = DateTime.Now,
                ApprovalStatus = ApprovalStatus.RejectedBySM,
                Leave = this,
                EmployeeId = scrumMasterEmployeeId,
                CreatedBy = currentUsername,
                Created = DateTime.Now
            });

            return true;
        }
    }

    public enum ApprovalStatus
    {
        Draft = 10,

        ApprovedBySM = 20,
        ApprovedByHR = 25,

        RejectedBySM = 30,
        RejectedbyHR = 35,
    }
}
