﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain.Repository;

namespace Shop.Domain.RoleAgg.Repository
{
    public interface IRoleRepository : IBaseRepository<Role>
    {
        Task <int> Delete(long RoleId);
        Task<Role> GetRoleByTitle(string roleTitle);
    }
}
