using Data.Abstractions;
using Timesheets.Data.Entities;

namespace Timesheets.Data.Abstractions
{
    public interface ITimesheetRepository : IRepository<Timesheet>
    {
    }
}
