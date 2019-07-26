using Data.Entities;
using System;
using System.Collections.Generic;

namespace Timesheets.Data.Entities
{
    public class Project : Entity
    {
        public string ProjectName { get; set; }
        public string ClientName { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset DueDate { get; set; }
        public string ProjectStatus { get; set; }

        //Database Relation
        public ICollection<Sprint> Sprints { get; set; }
        public ICollection<EmployeeDetail> EmployeeDetails { get; set; }
    }
}
