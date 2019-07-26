using System;
using System.Collections.Generic;
using System.Text;

namespace Leaves.ViewModels.Role
{
    public class RoleUpdateViewModel
    {
        public RoleUpdateViewModel() { }

        private readonly Data.Entities.Role _entity;
        public string Name { get; set; }

        internal Data.Entities.Role ToEntity(Data.Entities.Role entity)
        {
            entity.Name = this.Name;
            return entity;
        }
    }
}
