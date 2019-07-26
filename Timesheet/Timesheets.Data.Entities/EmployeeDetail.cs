using Data.Entities;

namespace Timesheets.Data.Entities
{
    public class EmployeeDetail : Entity
    {
        //Database Relation
        public int EmployeeId { get; set; }
        //public virtual Employee Employee { get; set; }
        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }
    }
}
