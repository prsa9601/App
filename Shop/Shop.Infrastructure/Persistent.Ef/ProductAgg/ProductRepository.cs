using Shop.Infrastructure._Utilities;
using Shop.Domain.ProductAgg;
using Shop.Domain.ProductAgg.Repository;
using Microsoft.EntityFrameworkCore;

namespace Shop.Infrastructure.Persistent.Ef.ProductAgg
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        private ShopContext _shopContext;

        public ProductRepository(ShopContext context, ShopContext shopContext) : base(context)
        {
            _shopContext = shopContext;
        }
        public async Task<int> Delete(long productId)
        {
            try
            {
                var product = await _shopContext.Products.FirstOrDefaultAsync(i => i.id == productId);
                _shopContext.Products.Remove(product);
                return 200;
            }
            catch { return 404; }
        }
    }
}
