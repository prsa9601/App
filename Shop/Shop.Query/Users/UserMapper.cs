using Shop.Domain.UserAgg;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Users.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Shop.Domain.RoleAgg;

namespace Shop.Query.Users
{
    public static class UserMapper
    {
        public static UserDto Map(this User user)
        {
            //var userDto = new UserDto();
            //userDto.PhoneNumber = user.PhoneNumber;
            //userDto.UserName = user.UserName;
            //userDto.Password = user.Password;
            //userDto.IsActive = user.IsActive;
            //userDto.Id = user.id;

           
            //    userDto.Roles = user.Roles.Select(s => new UserRoleDto()
            //    {
            //        RoleId = s.RoleId,
            //        RoleTitle = ""
            //    }).ToList();
            //return userDto;




            return new UserDto()
            {
                PhoneNumber = user.PhoneNumber,
                UserName = user.UserName,
                Password = user.Password,
                Id = user.id,
                IsActive = user.IsActive,
                Roles = user.Roles.Select(s => new UserRoleDto()
                {
                    RoleId = s.RoleId,
                    RoleTitle = ""
                }).ToList()
            };
        }
     
      
        public static async Task<UserDto> SetUserRoleTitles(this UserDto userDto, ShopContext context)
        {
            var roleIds = userDto.Roles.Select(r => r.RoleId);
            var result = await context.Roles.Where(r => roleIds.Contains(r.id)).ToListAsync();
            var roles = new List<UserRoleDto>();
            foreach (var role in result)
            {
                roles.Add(new UserRoleDto()
                {
                    RoleId = role.id,
                    RoleTitle = role.Title
                });
            }

            userDto.Roles = roles;
            return userDto;
        }
    }
}
