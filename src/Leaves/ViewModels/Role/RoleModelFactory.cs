using System;
using System.Collections.Generic;
using System.Text;
using ExtCore.Data.Abstractions;
using Leaves.Data.Abstraction;

namespace Leaves.ViewModels.Role
{
    internal class RoleModelFactory
    {
        public RoleModelFactory()
        {

        }

        internal RoleIndexViewModel LoadAll(IStorage storage, int page, int size)
        {
            var roleRepo = storage.GetRepository<IRolesRepository>();
            return new RoleIndexViewModel(roleRepo.All(roleRepo.Query, page, size));
        }
    }
}
