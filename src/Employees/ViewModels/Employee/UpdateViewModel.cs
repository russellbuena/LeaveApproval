using System;
using Employees.Data.Entities;

namespace Employees.ViewModels.Employee
{
    public class UpdateViewModel
    {
        public UpdateViewModel() { }

        private readonly Data.Entities.Employee _entity;

        public string FirstName { get; set; }
        public string LastName { get; set; }

        internal Data.Entities.Employee ToEntity(Data.Entities.Employee entity)
        {
            entity.FirstName = this.FirstName;
            entity.LastName = this.LastName;

            return entity;
        }
    }
}