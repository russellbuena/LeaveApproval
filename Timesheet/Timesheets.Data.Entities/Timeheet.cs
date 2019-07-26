using Data.Entities;
using System;
using System.Collections.Generic;

namespace Timesheets.Data.Entities
{
    public class Timesheet : Entity, IStartAble, IStopAble
    {
        public DateTimeOffset TimesheetDate { get; set; }
        public DateTimeOffset StartTime { get; set; }
        public DateTimeOffset EndTime { get; set; }
        public int TotalTimeByTask { get; set; }
        public int TotalTimeToday { get; set; }

        //Database Relation
        public int EmployeeId { get; set; }
        //public virtual Employee Employee { get; set; }
        public int ProjectId { get; set; }
        public int SprintId { get; set; }
        public virtual Sprint Sprint { get; set; }
        public int TaskId { get; set; }

        public void Start()
        {
            StartTime = DateTimeOffset.UtcNow;
        }

        public void Stop()
        {
            EndTime = DateTimeOffset.UtcNow;

            TotalTimeToday = (EndTime - StartTime).Minutes;
            TotalTimeByTask = (TotalTimeByTask + TotalTimeToday);
        }
    }
}
