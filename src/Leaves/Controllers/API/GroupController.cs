using System;
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
using Leaves.ViewModels.Role;

namespace Leaves.Controllers.API
{
    [Route("api/groups")]
   public class GroupController : ControllerBaseApi
    {
        public GroupController (IStorage storage ) : base(storage)
        { }

        [HttpGet]
        public IActionResult Get(int page = 0, int size = 25)
        {
            IEnumerable<Group> data = new GroupModelFactory().LoadAll(Storage, page, size)?.Groups;
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
        public IActionResult Post(GroupCreateViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                Group group = model.ToEntity();
                var repo = this.Storage.GetRepository<IGroupsRepository>();

                repo.Create(group, GetCurrentUserName());
                this.Storage.Save();

                return Ok(new { success = true });
            }

            return BadRequest(new { success = false });
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            var repo = this.Storage.GetRepository<IGroupsRepository>();

            Group group = repo.WithKey(id);
            if (group == null)
                return this.NotFound(new { success = false });

            return Ok(new { success = true, data = group });
        }


        [HttpPut("{id:int}")]
        public IActionResult Put(int id, GroupUpdateViewModel model)
        {
            var repo = this.Storage.GetRepository<IGroupsRepository>();

            Group group = repo.WithKey(id);
            if (group == null)
                return this.NotFound(new { success = false });

            if (this.ModelState.IsValid)
            {
                model.ToEntity(group);
                repo.Edit(group, GetCurrentUserName());
                this.Storage.Save();

                return Ok(new { success = true });
            }

            return BadRequest(new { success = false });
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var repo = this.Storage.GetRepository<IGroupsRepository>();

            Group group = repo.WithKey(id);
            if (group == null)
                return this.NotFound(new { success = false });

            repo.Delete(group, GetCurrentUserName());
            this.Storage.Save();

            return Ok(new { success = true });
        }

    }
}
