using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Application;
using Shop.Domain.RoleAgg.Enums;

namespace Shop.Application.Role.Update
{
    public record UpdateRoleCommand(long RoleId, string Title, List<Permission>Permissions) : IBaseCommand;
}
