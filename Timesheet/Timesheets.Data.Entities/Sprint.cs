using Data.Entities;
using System;
using System.Collections.Generic;

namespace Timesheets.Data.Entities
{
    public class Sprint : Entity
    {
        public int SprintNumber { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }

        //Database Relation
        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }
        public ICollection<Task> Tasks { get; set; }
        public ICollection<Timesheet> Timesheets { get; set; }
    }
}
