using Employees.Data.Entities;
using Leaves.Data.Entities;


namespace Leaves.ViewModels.Leave
{
    public class LeaveDto
    {
        public LeaveDto(Data.Entities.Leave leave, Employee employee )
        {
            EmployeeName = employee.FirstName;
            Id = leave.Id;

            
        }

        public string EmployeeName { get; }
        public int Id { get; }
        
        
    }
}