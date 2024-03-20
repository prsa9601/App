using AppRazorPage.Models.Role;
using Eshop.RazorPage.Models;

namespace AppRazorPage.Services.Roles
{
    public interface IRoleService
    { 
         Task<ApiResult> AddRole(CreateRoleCommand command);
         Task<ApiResult> EditRole(EditRoleCommand command);
         Task<ApiResult> DeleteRole(DeleteRoleCommand command);
         Task<ApiResult> AddUserRole(SetUserRoleCommand command);
         Task<RoleDto> GetRoleById(long roleId);
         Task<List<RoleDto>> GetRoles();
    }
}
