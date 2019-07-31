using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Leaves.Data.Entities;

namespace Leaves.ViewModels.Leaves
{
    public class LeaveUpdateViewModels
    {
        public LeaveUpdateViewModels() { }
        //private readonly Leave _entity;

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

        internal Data.Entities.Leave ToEntity(Data.Entities.Leave entity)
        {
            entity.LeaveType = LeaveType;
            entity.Modified = DateTime.Now;
            entity.StartDate = StartDate;
            entity.EndDate = EndDate;
            entity.TotalLeaveTaken = TotalLeaveTaken;
            entity.Purpose = Purpose;
            entity.JobOverTo = JobOverTo;
            entity.Project = Project;

            return entity;
        }
    }
}
