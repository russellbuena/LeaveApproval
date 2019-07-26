using System;
using System.Collections.Generic;
using System.Text;
using Data.Entities;


namespace Leaves.Data.Entities
{
   public class Role : Entity
    {
        public string Name { get; set;  }
        public int GroupId { get; set; }
        public virtual Group group { get; set; }
    }
}
