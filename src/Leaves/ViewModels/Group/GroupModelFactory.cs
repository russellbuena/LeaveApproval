using System;
using Leaves.Data.Abstraction;
using ExtCore.Data.Abstractions;

namespace Leaves.ViewModels.Role
{
   internal class GroupModelFactory
    {
        public GroupModelFactory()
        {

        }

        internal GroupIndexViewModel LoadAll(IStorage storage, int page, int size)
        {
            var groupRepo = storage.GetRepository<IGroupsRepository>();
            return new GroupIndexViewModel(groupRepo.All(groupRepo.Query, page, size));
        }
    }
}
