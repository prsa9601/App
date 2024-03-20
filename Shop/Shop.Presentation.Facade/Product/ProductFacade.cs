using MediatR;
using Common.Application;
using Shop.Application.Product.Create;
using Shop.Application.Product.Update;
using Shop.Query.Products.DTOs;
using Shop.Query.Products.GetById;
using Shop.Query.Products.GetList;
using Shop.Query.Products.GetByFilter;
using Shop.Application.Product.Delete;

namespace Shop.Presentation.Facade.Product
{
    internal class ProductFacade : IProductFacade
    {
        private readonly IMediator _mediator;

        public ProductFacade(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<OperationResult> CreateProduct(CreateProductCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> EditProduct(UpdateProductCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> DeleteProduct(long productId)
        {
            return await _mediator.Send(new DeleteProductCommand(productId));
        }

        public async Task<ProductDto?> GetProductById(long ProductId)
        {
            return await _mediator.Send(new GetProductByIdQuery(ProductId));
        }

        public async Task<List<ProductDto>> GetProducts()
        {
            return await _mediator.Send(new GetProductListQuery());
        }
        public async Task<ProductFilterResult> GetProductsByFilter(ProductFilterParam filterParams)
        {
            return await _mediator.Send(new GetProductByFilterQuery(filterParams));
        }

        //public async Task<ProductShopResult> GetProductsForShop(ProductShopFilterParam filterParams)
        //{
        //    return await _mediator.Send(new GetProductsForShopQuery(filterParams));
        //}
    }
}
