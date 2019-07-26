using System;
using System.Collections.Generic;
using System.Text;

namespace Leaves.ViewModels.Role
{
    public class RoleIndexViewModel
    {
        public RoleIndexViewModel(IEnumerable<Data.Entities.Role> data)
        {
            Roles = data ?? new List<Data.Entities.Role>();
        }

        public IEnumerable<Data.Entities.Role> Roles { get; set; }
    }
}
