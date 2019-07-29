using Employees.Data.Entities;
using Leaves.Data.Entities;


namespace Leaves.ViewModels.Leave
{
    public class LeaveDto
    {
        public LeaveDto(Data.Entities.Leave leave)
        {
            //EmployeeName = employee.FirstName;
            Id = leave.Id;

        }

        public string EmployeeName { get; set; }
        public int Id { get; }



    }
}