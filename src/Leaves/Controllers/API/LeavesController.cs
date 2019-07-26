using System.Collections.Generic;
using Barebone.Controllers;
using Leaves.Data.Abstraction;
using Microsoft.AspNetCore.Authorization;
using Leaves.Data.Entities;
using ExtCore.Data.Abstractions;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

using Leaves.ViewModels;
using System;
using Leaves.ViewModels.Leave;

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



        [HttpPost]
        public IActionResult Post(CreateViewModels model)
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
        public IActionResult ApproveByScrumMaster(int id)
        {
            var username = this.GetCurrentUserName();

            var repo = this.Storage.GetRepository<ILeavesRepository>();

            Leave leave = repo.WithKey(id);
            if (leave == null)
                return this.NotFound(new { success = false });

            // TODO : find correct Employee ID from Username
            leave.ScrumMasterApproved(0);

            return Ok(new { success = true});
        }

        [HttpPost("{id:int}/approveby-hr")]
        public IActionResult ApproveByHumanResourceDept(int id)
        {
            var username = this.GetCurrentUserName();

            var repo = this.Storage.GetRepository<ILeavesRepository>();

            Leave leave = repo.WithKey(id);

            if (leave == null)
                return this.NotFound(new { success = false });

            return Ok(new { success = true });
        }


        [HttpPut("{id:int}")]
        public IActionResult Put(int id, UpdateViewModels model)
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
