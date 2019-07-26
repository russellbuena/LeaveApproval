using Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Leaves.Data.Entities
{
    public class LeaveApprovalHistory : Entity
    {

        public int EmployeeId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTimeOffset ApprovalDate { get; set; }
        public ApprovalStatus ApprovalStatus { get; set; }

        public virtual Leave Leave { get; set; }
    }
}
