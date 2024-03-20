using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Query;
using Shop.Query.Users.DTOs;

namespace Shop.Query.Users.GetList
{
    public record GetUserListQuery : IQuery<List<UserDto>>
    {

    }
}
