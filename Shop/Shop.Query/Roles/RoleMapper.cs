using Shop.Domain.ProductAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Domain.RoleAgg;
using Shop.Query.Roles.DTOs;
using Shop.Infrastructure.Persistent.Ef;

namespace Shop.Query.Roles
{
    public static class RoleMapper
    {
        public static RoleFilterData MapListData(this Role role)
        {
            return new RoleFilterData()
            {
                Title = role.Title,
                permissions = role.Permissions.Select(s=>s.Permission).ToList(),
                Id = role.id,
                CreationDate = role.CreationDate
            };
        }
        //public static async Task<RoleFilterData> MapListData(this Role role, ShopContext context)
        //{
        //    var rolePermission = context.Roles.Select(s => s.Permissions).ToList();
        //    var permission = rolePermission.Select(roleId)
        //    return new RoleFilterData()
        //    {
        //        Title = role.Title,
        //        permissions = role.Permissions,
        //        Id = role.id,
        //        CreationDate = role.CreationDate
        //    };
        //}
    }
}

     
      
//public static async Task<UserDto> SetUserRoleTitles(this UserDto userDto, ShopContext context)
//{
//    var roleIds = userDto.Roles.Select(r => r.RoleId);
//    var result = await context.Roles.Where(r => roleIds.Contains(r.id)).ToListAsync();
//    var roles = new List<UserRoleDto>();
//    foreach (var role in result)
//    {
//        roles.Add(new UserRoleDto()
//        {
//            RoleId = role.id,
//            RoleTitle = role.Title
//        });
//    }

//    userDto.Roles = roles;
//    return userDto;
//}
