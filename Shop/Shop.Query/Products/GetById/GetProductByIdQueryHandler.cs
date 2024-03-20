using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Products.DTOs;
using Shop.Query.Roles.DTOs;

namespace Shop.Query.Products.GetById
{
    public class GetProductByIdQueryHandler : IQueryHandler<GetProductByIdQuery, ProductDto?>
    {
        private readonly ShopContext _context;

        public GetProductByIdQueryHandler(ShopContext context)
        {
            _context = context;
        }
        public async Task<ProductDto?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _context.Products.FirstOrDefaultAsync(f => f.id == request.ProductId, cancellationToken: cancellationToken);
            if (product == null)
                return null;

            return new ProductDto()
            {
                Id = product.id,
                CreationDate = product.CreationDate,
                Title = product.Title,
                Price = product.Price
            };
        }
    }
}
