using Common.Application;
using Shop.Domain.RoleAgg.Repository;

namespace Shop.Application.Role.Delete
{
    public record DeleteRoleCommand(long RoleId) : IBaseCommand;
    public class DeleteRoleCommandHandler : IBaseCommandHandler<DeleteRoleCommand>
    {
        private readonly IRoleRepository _Repository;

        public DeleteRoleCommandHandler(IRoleRepository repository)
        {
            _Repository = repository;
        }

        public async Task<OperationResult> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
          var result = await _Repository.Delete(request.RoleId);
            if(result == 200)
                return OperationResult.Success();
            else
                return OperationResult.NotFound();  
        }
    }
}
