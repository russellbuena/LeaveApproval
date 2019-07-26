using System;
using System.Collections.Generic;
using System.Text;
using Leaves.Data.Entities;

namespace Leaves.ViewModels.Role
{
    public class GroupUpdateViewModel
    {
        public GroupUpdateViewModel() { }

        private readonly Data.Entities.Group _entity;
        public string Name { get; set;  }

        internal Data.Entities.Group ToEntity(Data.Entities.Group entity)
        {
            entity.Name = this.Name;
            return entity;
        }
    }
}
