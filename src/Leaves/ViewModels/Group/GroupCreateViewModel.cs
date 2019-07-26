using System;
using Leaves.Data.Entities;


namespace Leaves.ViewModels.Role
{
    public class GroupCreateViewModel
    {
        public string Name { get; set; }

        internal Data.Entities.Group ToEntity()
        {
            return new Data.Entities.Group
            {
                Name = this.Name
            };
        }

    }
}
