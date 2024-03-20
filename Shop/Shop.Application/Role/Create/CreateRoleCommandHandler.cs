using System;
using System.Collections.Generic;
using System.Linq;
using Common.Application;
using Shop.Domain.RoleAgg;
using Shop.Domain.RoleAgg.Repository;
using Shop.Domain.RoleAgg.Services;

namespace Shop.Application.Role.Create
{
    internal class CreateRoleCommandHandler : IBaseCommandHandler<CreateRoleCommand>
    {
        private readonly IRoleRepository _RoleRepository;
        private readonly IRoleService _RoleService;

        public CreateRoleCommandHandler(IRoleRepository roleRepository, IRoleService roleService)
        {
            _RoleRepository = roleRepository;
            _RoleService = roleService;
        }
        public async Task<OperationResult> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            if (!_RoleService.IsTitleExist(request.Title))
            {
                var permissions = new List<RolePermission>();
                request.Permissions.ForEach(f =>
                {
                    permissions.Add(new RolePermission(f));
                });
                var role = new Domain.RoleAgg.Role(request.Title, permissions);
                _RoleRepository.Add(role);
                await _RoleRepository.Save();

                return OperationResult.Success();
            }
            else
            {
                return OperationResult.Error("همچین نقش کاربری وجود دارد.");
            }
        }
    }
}
