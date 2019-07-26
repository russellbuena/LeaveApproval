using Data.Entities;
using System;
using System.Collections.Generic;

namespace Timesheets.Data.Entities
{
    public class Task : Entity
    {
        public string TaskName { get; set; }

        //Database Relation
        public int SprintId { get; set; }
        public virtual Sprint Sprint { get; set; }
    }
}
