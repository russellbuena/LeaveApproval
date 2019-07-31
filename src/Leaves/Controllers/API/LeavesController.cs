using System.Collections.Generic;
using Barebone.Controllers;
using Leaves.Data.Abstraction;
using Microsoft.AspNetCore.Authorization;
using Leaves.Data.Entities;
using ExtCore.Data.Abstractions;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System;
using Leaves.ViewModels.Leave;
using Employees.Data.Abstractions;
using Leaves.ViewModels.Leaves;

namespace Leaves.Controllers.API
{
    // [Authorize]
    [Route("api/leaves")]
    public class LeavesController : ControllerBaseApi
    {
        public LeavesController(IStorage storage) : base(storage)
        { }


        [HttpGet]
        public IActionResult Get(int page = 0, int size = 25)
        {
            
            var data = new LeaveModelFactory().LoadAll(Storage, page, size)?.Leaves;
            int count = data.Count();

            return Ok(new
            {
                success = true,
                data,
                count,
                totalPage = ((int)count / size) + 1
            });
        }

        [HttpGet("sample-get-leave-index")]
        public IActionResult GetLeaveIndex([FromQuery] int page = 0, [FromQuery] int size = 25)
        {
            var leaveRepository = Storage.GetRepository<ILeavesRepository>();
            var leaveQuery = leaveRepository.Query;
            var leaveData = leaveRepository.All(leaveQuery, page, size);
            var userIds = leaveData.Select(s => s.EmployeeId).ToList();

            var employeeRepository = Storage.GetRepository<IEmployeeRepository>();
            var users = employeeRepository.All(employeeRepository.Query.Where(w => userIds.Contains(w.Id)), 0, int.MaxValue);

            var result = new List<LeaveDto>();
            foreach (var leaveDatum in leaveData)
            {
                var user = users.FirstOrDefault(f => f.Id.Equals(leaveDatum.EmployeeId));

                result.Add(new LeaveDto(leaveDatum)
                {
                    //EmployeeName = user?.FirstName
                });
            }

            return Ok(result);
        }



        [HttpPost]
        public IActionResult Post(LeaveCreateViewModel model)
        {
            if (this.ModelState.IsValid)
                {
                    Leave leave = model.ToEntity();
                if (leave != null)
                {
                    var repo = this.Storage.GetRepository<ILeavesRepository>();

                    repo.Create(leave, GetCurrentUserName());
                    this.Storage.Save();

                    return Ok(new { success = true });
                }
            }
                return BadRequest(new { success = false });            
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            var repo = this.Storage.GetRepository<ILeavesRepository>();

            Leave leave = repo.WithKey(id);
            if (leave == null)
                return this.NotFound(new { success = false });

            return Ok(new { success = true, data = leave });
        }

        [HttpPost("{id:int}/approveby-sm")]
        public IActionResult ApproveByScrumMaster([FromRoute]int id)
        {
            var username = this.GetCurrentUserName();

            var repo = this.Storage.GetRepository<ILeavesRepository>();

            Leave leave = repo.WithKey(id);
            if (leave == null)
                return this.NotFound(new { success = false });

            // TODO : find correct Employee ID from Username
            leave.ScrumMasterApproved(10, GetCurrentUserName());

            this.Storage.Save();

            return Ok(new { success = true});
        }
        [HttpPost("{id:int}/rejectedby-sm")]
        public IActionResult  RejectedByScrumMaster([FromRoute]int id)
        {
            var username = this.GetCurrentUserName();
            var repo = this.Storage.GetRepository<ILeavesRepository>();
            Leave leave = repo.WithKey(id);
            if (leave == null)
                return this.NotFound(new { success = false });

            leave.ScrumMasterRejected(10, GetCurrentUserName());
            this.Storage.Save();
            return Ok(new { success = true });
        }

        [HttpPost("{id:int}/approveby-hr")]
        public IActionResult ApproveByHumanResourceDept([FromRoute]int id)
        {
            var username = this.GetCurrentUserName();

            var repo = this.Storage.GetRepository<ILeavesRepository>();

            Leave leave = repo.WithKey(id);

            if (leave == null)
                return this.NotFound(new { success = false });

            leave.HumanResourceDeptApproved(20, GetCurrentUserName());
            this.Storage.Save();

            return Ok(new { success = true });
        }
        
        [HttpPost("{id:int}/rejectedby-hr")]
        public IActionResult RejectByHumanResourceDept([FromRoute]int id)
        {
            var username = this.GetCurrentUserName();
            var repo = this.Storage.GetRepository<ILeavesRepository>();
            Leave leave = repo.WithKey(id);
            if (leave == null)
                return this.NotFound(new { success = false });
            leave.HumanResourceDeptRejected(20, GetCurrentUserName());

            this.Storage.Save();
            return Ok(new { success = true });
        }

        [HttpPut("{id:int}")]
        public IActionResult Put(int id, LeaveUpdateViewModels model)
        {
            var repo = this.Storage.GetRepository<ILeavesRepository>();

               Leave leave = repo.WithKey(id);
            if (leave == null)
                return this.NotFound(new { success = false });

            if (this.ModelState.IsValid)
            {
                model.ToEntity(leave);
                repo.Edit(leave, GetCurrentUserName());
                this.Storage.Save();

                return Ok(new { success = true });
            }

            return BadRequest(new { success = false });
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var repo = this.Storage.GetRepository<ILeavesRepository>();

            Leave leave = repo.WithKey(id);
            if (leave == null)
                return this.NotFound(new { success = false });

            repo.Delete(leave, GetCurrentUserName());
            this.Storage.Save();

            return Ok(new { success = true });
        }

        [HttpGet("masterdata")]
        public IActionResult MasterData()
        {
            return Ok(new
            {
                leaveTypes = Enum.GetValues(typeof(LeaveType)).Cast<LeaveType>().Select(o => new { id = o, name = o.ToString() })
            });   
        }
    }
}
