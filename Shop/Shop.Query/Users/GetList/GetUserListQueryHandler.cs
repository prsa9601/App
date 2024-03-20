using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Query;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Roles.DTOs;
using Shop.Query.Users.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Shop.Query.Users.GetList
{
    public class GetUserListQueryHandler : IQueryHandler<GetUserListQuery, List<UserDto>>
    {
        private readonly ShopContext _context;

        public GetUserListQueryHandler(ShopContext context)
        {
            _context = context;
        }
               // Permissions = role.Permissions.Select(s => s.Permission).ToList(),
        public async Task<List<UserDto>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        {
            return await _context.Users.Select(user => new UserDto()
            {
                Id = user.id,
                CreationDate = user.CreationDate,
                PhoneNumber = user.PhoneNumber,
                UserName = user.UserName
                
            }).ToListAsync(cancellationToken);
        }
    }
}
