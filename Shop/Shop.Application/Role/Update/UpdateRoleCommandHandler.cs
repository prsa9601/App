using Common.Application;
using Shop.Domain.ProductAgg.Repository;
using Shop.Domain.ProductAgg.Services;
using Shop.Domain.RoleAgg;
using Shop.Domain.RoleAgg.Repository;
using Shop.Domain.RoleAgg.Services;

namespace Shop.Application.Role.Update
{
    internal class UpdateRoleCommandHandler : IBaseCommandHandler<UpdateRoleCommand>
    {
        private readonly IRoleRepository _repository;
        private readonly IRoleService _Service;
        public UpdateRoleCommandHandler(IRoleRepository repository, IRoleService service)
        { 
            _repository = repository;
            _Service = service;
        }
        public async Task<OperationResult> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
        {
            var role = await _repository.GetTracking(request.RoleId);
            if (role == null)
                return OperationResult.NotFound();

            role.Edit(request.Title);

            var permissions = new List<RolePermission>();
            request.Permissions.ForEach(f =>
            {
                permissions.Add(new RolePermission(f));
            });
            role.SetPermissions(permissions);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}
