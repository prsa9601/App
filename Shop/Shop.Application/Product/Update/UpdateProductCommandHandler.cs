using Common.Application;
using Shop.Domain.ProductAgg.Repository;
using Shop.Domain.ProductAgg;
using Shop.Domain.ProductAgg.Services;

namespace Shop.Application.Product.Update
{
    internal class UpdateProductCommandHandler : IBaseCommandHandler<UpdateProductCommand>
    {
        private readonly IProductRepository _Repository;
        private readonly IProductService _Service;

        public UpdateProductCommandHandler(IProductRepository repository, IProductService service)
        {
            _Repository = repository;
            _Service = service;
        }
        public async Task<OperationResult> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await  _Repository.GetTracking(request.ProductId);
            if (product == null)
                return OperationResult.NotFound();
             
            product.Edit(request.Title, request.Price);
            await _Repository.Save();
            return OperationResult.Success();
            

        }
    }
}
