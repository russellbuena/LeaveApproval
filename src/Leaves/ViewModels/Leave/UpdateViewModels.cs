using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Leaves.Data.Entities;

namespace Leaves.Controllers.API
{
   public class UpdateViewModels
    {
        public UpdateViewModels() { }
        private readonly Leave _entity;

        public LeaveType LeaveType { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        public double TotalLeaveTaken { get; set; }
        public string Purpose { get; set; }
        public string JobOverTo { get; set; }
        public string Project { get; set; }
        public string SM { get; set; }

        internal Leave ToEntity(Leave entity)
        {
            entity.LeaveType = this.LeaveType;
            entity.Modified = DateTime.Now;
            entity.StartDate = this.StartDate;
            entity.EndDate = this.EndDate;
            entity.TotalLeaveTaken = this.TotalLeaveTaken;
            entity.Purpose = this.Purpose;
            entity.JobOverTo = this.JobOverTo;
            entity.Project = this.Project;

            return entity;
        }
    }
}
