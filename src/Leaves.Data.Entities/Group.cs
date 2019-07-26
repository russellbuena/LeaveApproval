using System;
using System.Collections.Generic;
using System.Text;
using Data.Entities;

namespace Leaves.Data.Entities
{
    public class Group : Entity

    {
        public string Name { get; set; }
        public ICollection<Role> Roles { get; set; }
    }
}
