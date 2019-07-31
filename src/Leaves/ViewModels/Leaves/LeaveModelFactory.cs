using System.Collections.Generic;
using Leaves.Data.Abstraction;
using ExtCore.Data.Abstractions;
using Employees.Data.Abstractions;
using System.Linq;
using System;

namespace Leaves.ViewModels.Leave
{
    internal class LeaveModelFactory
    {
        public LeaveModelFactory()
        {
        } 

        internal LeaveIndexViewModel LoadAll(IStorage storage, int page, int size)
        {
            var leaveRepo = storage.GetRepository<ILeavesRepository>();
            var employeeRepo = storage.GetRepository<IEmployeeRepository>();

            var queryLeave = leaveRepo.Query;
            var leaveList = leaveRepo.All(queryLeave, page, size);
            var employeeIds = leaveList.Select(o => o.EmployeeId);
            var employeeList = employeeRepo.Query.Where(o => employeeIds.Contains(o.Id)).ToList();

            var data = (from l in leaveList
                        join e in employeeList on l.EmployeeId equals e.Id
                        select new LeaveDto(l, e)).ToList();

            return new LeaveIndexViewModel(data);

            //throw new NotImplementedException();
        }
    }
}