using System;
using System.Collections.Generic;
using System.Text;

namespace Leaves.ViewModels.Role
{
   public class RoleCreateViewModel
    {
        public string Name { get; set; }

        internal Data.Entities.Role ToEntity()
        {
            return new Data.Entities.Role
            {
                Name = this.Name
            };
        }
    }
}
