using Common.Application;
using Shop.Application.Role.Create;
using Shop.Application.Role.Delete;
using Shop.Application.Role.Update;
using Shop.Query.Products.DTOs;
using Shop.Query.Roles.DTOs;

namespace Shop.Presentation.Facade.Role;

public interface IRoleFacade
{
    Task<OperationResult> CreateRole(CreateRoleCommand command);
    Task<OperationResult> EditRole(UpdateRoleCommand command);
    Task<OperationResult> DeleteRole(long id);
    Task<RoleFilterResult> GetRolesByFilter(RoleFilterParam filterParams);
    Task<RoleDto?> GetRoleById(long roleId);
    Task<List<RoleDto>> GetRoles();
}