using System;
using System.ComponentModel.DataAnnotations;
using Employees.Data.Entities;

namespace Employees.ViewModels.Employee
{
    public class CreateViewModel
    {
        [Display(Name = "First Name")]
        [Required()]
        public string FirstName { get; set; }

        public string LastName { get; set; }
        internal Data.Entities.Employee ToEntity()
        {
            return new Data.Entities.Employee
            {
                FirstName = this.FirstName,
                LastName = this.LastName
            };
        }
    }
}
