using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Application;
using FluentValidation;
using Shop.Domain.RoleAgg.Repository;
using Shop.Domain.UserAgg.Services;

namespace Shop.Application.Role.SetUserRole
{
    //internal record SetUserRoleCommand(long RoleId, Domain.UserAgg.User User) : IBaseCommand;
    public record SetUserRoleCommand(long RoleId, string UserName, string PhoneNumber, string Password)
        : IBaseCommand;
    
    internal class SetUserRoleCommandHandler:IBaseCommandHandler<SetUserRoleCommand>
    {
        private readonly IRoleRepository _repository;
        private readonly IUserService _userService;

        public SetUserRoleCommandHandler(IRoleRepository repository, IUserService userService)
        {
            _repository = repository;
            _userService = userService;
        }

        public async Task<OperationResult> Handle(SetUserRoleCommand request, CancellationToken cancellationToken)
        {
            var role = await _repository.GetTracking(request.RoleId);
            if (role == null) 
                return OperationResult.NotFound();
            role.SetUser(request.UserName, request.PhoneNumber, request.Password, _userService);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
    internal class SetUserRoleCommandValidator:AbstractValidator<SetUserRoleCommand>
    {
    }
}
