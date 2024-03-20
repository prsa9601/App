using Microsoft.EntityFrameworkCore;
using Common.Query;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Products.DTOs;

namespace Shop.Query.Products.GetList
{
    public class GetProductListQueryHandler : IQueryHandler<GetProductListQuery, List<ProductDto>>
    {
        private readonly ShopContext _context;

        public GetProductListQueryHandler(ShopContext context)
        {
            _context = context;
        }
        public async Task<List<ProductDto>> Handle(GetProductListQuery request, CancellationToken cancellationToken)
        {
            return await _context.Products.Select(product => new ProductDto()
            {
                Id = product.id,
                CreationDate = product.CreationDate,
                Title = product.Title,
                Price = product.Price
            }).ToListAsync(cancellationToken);
        }
    }
}
