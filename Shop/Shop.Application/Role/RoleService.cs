using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Domain.RoleAgg.Repository;
using Shop.Domain.RoleAgg.Services;
using Shop.Domain.UserAgg.Repository;

namespace Shop.Application.Role
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _repository;

        public RoleService(IRoleRepository repository)
        {
            _repository = repository;
        }
        public bool IsTitleExist(string title)
        {
            return _repository.Exists(r => r.Title == title);
        }
    }
}
