using System.Collections.Generic;
using Leaves.Data.Entities;

namespace Leaves.ViewModels.Leave
{
    public class LeaveIndexViewModel
    {
        public LeaveIndexViewModel(IEnumerable<LeaveDto> data)
        {
            Leaves = data ?? new List<LeaveDto>();
         
        }
        public IEnumerable<LeaveDto> Leaves { get; }
    }
   

}
