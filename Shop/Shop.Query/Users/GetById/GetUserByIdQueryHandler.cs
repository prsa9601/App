﻿using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Products.DTOs;
using Shop.Query.Products.GetById;
using Shop.Query.Users.DTOs;

namespace Shop.Query.Users.GetById
{
    public class GetUserByIdQueryHandler : IQueryHandler<GetUserByIdQuery, UserDto?>
    {
        private readonly ShopContext _context;

        public GetUserByIdQueryHandler(ShopContext context)
        {
            _context = context;
        }
        public async Task<UserDto?> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(f => f.id == request.UserId, cancellationToken: cancellationToken);
            if (user == null)
                return null;

            return new UserDto()
            {
                Id = user.id,
                CreationDate = user.CreationDate,
                UserName = user.UserName,
                PhoneNumber = user.PhoneNumber
            };
        }
    }
}
