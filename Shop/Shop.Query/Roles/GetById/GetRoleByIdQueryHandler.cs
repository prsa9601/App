using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Products.DTOs;
using Shop.Query.Products.GetById;
using Shop.Query.Roles.DTOs;

namespace Shop.Query.Roles.GetById
{
    public class GetRoleByIdQueryHandler : IQueryHandler<GetRoleByIdQuery, RoleDto?>
    {
        private readonly ShopContext _context;

        public GetRoleByIdQueryHandler(ShopContext context)
        {
            _context = context;
        }
        public async Task<RoleDto?> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
        {
            var role = await _context.Roles.FirstOrDefaultAsync(f => f.id == request.RoleId, cancellationToken: cancellationToken);
            if (role == null)
                return null;

            return new RoleDto()
            {
                Id = role.id,
                CreationDate = role.CreationDate,
                Permissions = role.Permissions.Select(s=>s.Permission).ToList(),
                Title = role.Title,
            };
        }
    }
}
