using Common.Application;
using Shop.Application.Product.Create;
using Shop.Application.Product.Delete;
using Shop.Application.Product.Update;
using Shop.Query.Products.DTOs;

namespace Shop.Presentation.Facade.Product
{
    public interface IProductFacade
    {
        Task<OperationResult> CreateProduct(CreateProductCommand command);
        Task<OperationResult> EditProduct(UpdateProductCommand command);
        Task<OperationResult> DeleteProduct(long productId);


        Task<ProductDto?> GetProductById(long ProductId);
        Task<List<ProductDto?>> GetProducts();
        Task<ProductFilterResult> GetProductsByFilter(ProductFilterParam filterParams);
       // Task<ProductShopResult> GetProductsForShop(ProductShopFilterParam filterParams);
    }
}
