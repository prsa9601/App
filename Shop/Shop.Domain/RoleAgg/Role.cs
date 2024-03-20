using Common.Domain;
using Common.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Domain.RoleAgg.Services;
using Shop.Domain.UserAgg.Services;

namespace Shop.Domain.RoleAgg
{
    public class Role : AggregateRoot
    {
         public string Title { get; private set; }
         public List<RolePermission> Permissions { get; private set; }
   
         private Role()
         {
         }
   
         public Role(string title, List<RolePermission> permissions)
         {
             NullOrEmptyDomainDataException.CheckString(title, nameof(title));
   
             Title = title;
             Permissions = permissions;
         }
         public List<Domain.UserAgg.User> Users { get; set; }
         public Role(string title, IRoleService service)
         {
             Guard(title, service);
             Title = title;
         }
   
         public void Edit(string title, IRoleService service)
         {
             Guard(title, service);
             Title = title;
         }
   
         public void SetUser(string UserName, string PhoneNumber, string Password, IUserService userService)
         {
             var user = new UserAgg.User(UserName, PhoneNumber, Password, userService);
             Users.Add(user);
         }
   
       
         //public Role(string title)
         //{
         //    NullOrEmptyDomainDataException.CheckString(title, nameof(title));
   
         //    Title = title;
         //    Permissions = new List<RolePermission>();
         //}
   
         public void Edit(string title)
         {
             NullOrEmptyDomainDataException.CheckString(title, nameof(title));
             Title = title;
         }
   
         public void SetPermissions(List<RolePermission> permissions)
         {
             Permissions = permissions;
         }
         public void Guard(string title, IRoleService roleService)
         {
             NullOrEmptyDomainDataException.CheckString(title, nameof(title));
             if (title != Title)
                 if (roleService.IsTitleExist(title))
                     throw new InvalidDomainDataException("role title is duplicate");
         }
   
    }
}