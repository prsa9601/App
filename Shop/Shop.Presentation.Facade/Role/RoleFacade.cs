using Common.Application;
using MediatR;
using Shop.Application.Role.Create;
using Shop.Application.Role.Delete;
using Shop.Application.Role.Update;
using Shop.Query.Products.DTOs;
using Shop.Query.Products.GetByFilter;
using Shop.Query.Roles.DTOs;
using Shop.Query.Roles.GetByFilter;
using Shop.Query.Roles.GetById;
using Shop.Query.Roles.GetList;

namespace Shop.Presentation.Facade.Role;

internal class RoleFacade : IRoleFacade
{
    private readonly IMediator _mediator;

    public RoleFacade(IMediator mediator)
    {
        _mediator = mediator;
    }
    public async Task<OperationResult> CreateRole(CreateRoleCommand command)
    {
        return await _mediator.Send(command);
    }
    public async Task<OperationResult> EditRole(UpdateRoleCommand command)
    {
        return await _mediator.Send(command);
    }
    public async Task<OperationResult> DeleteRole(long id)
    {
        return await _mediator.Send(new DeleteRoleCommand(id));
    }
    public async Task<RoleDto?> GetRoleById(long roleId)
    {
        return await _mediator.Send(new GetRoleByIdQuery(roleId));
    } 

    public async Task<List<RoleDto>> GetRoles()
    {
        return await _mediator.Send(new GetRoleListQuery());
    }
    public async Task<RoleFilterResult> GetRolesByFilter(RoleFilterParam filterParams)
    {
        return await _mediator.Send(new GetRoleByFilterQuery(filterParams));
    }
}