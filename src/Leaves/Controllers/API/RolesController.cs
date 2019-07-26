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
using Leaves.ViewModels.Role;

namespace Leaves.Controllers.API
{
    [Route("api/roles")]
    public class RoleController : ControllerBaseApi
    {
        public RoleController(IStorage storage) : base(storage)
        { }

        [HttpGet]
        public IActionResult Get(int page = 0, int size = 25)
        {
            IEnumerable<Role> data = new RoleModelFactory().LoadAll(Storage, page, size)?.Roles;
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
        public IActionResult Post(RoleCreateViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                Role role = model.ToEntity();
                var repo = this.Storage.GetRepository<IRolesRepository>();

                repo.Create(role, GetCurrentUserName());
                this.Storage.Save();

                return Ok(new { success = true });
            }

            return BadRequest(new { success = false });
        }


        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            var repo = this.Storage.GetRepository<IRolesRepository>();

            Role role = repo.WithKey(id);
            if (role == null)
                return this.NotFound(new { success = false });

            return Ok(new { success = true, data = role });
        }

        [HttpPut("{id:int}")]
        public IActionResult Put(int id, RoleUpdateViewModel model)
        {
            var repo = this.Storage.GetRepository<IRolesRepository>();

            Role role = repo.WithKey(id);
            if (role == null)
                return this.NotFound(new { success = false });

            if (this.ModelState.IsValid)
            {
                model.ToEntity(role);
                repo.Edit(role, GetCurrentUserName());
                this.Storage.Save();

                return Ok(new { success = true });
            }

            return BadRequest(new { success = false });
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var repo = this.Storage.GetRepository<IRolesRepository>();

            Role role = repo.WithKey(id);
            if (role == null)
                return this.NotFound(new { success = false });

            repo.Delete(role, GetCurrentUserName());
            this.Storage.Save();

            return Ok(new { success = true });
        }

    }
    
}
