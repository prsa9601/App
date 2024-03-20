using Common.Application;
using Shop.Domain.ProductAgg.Repository;

namespace Shop.Application.Product.Delete
{
    public record DeleteProductCommand(long ProductId) : IBaseCommand;
    public class DeleteProductCommandHandler : IBaseCommandHandler<DeleteProductCommand>
    {
        private readonly IProductRepository _productRepository;

        public DeleteProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<OperationResult> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
           var result = await _productRepository.Delete(request.ProductId);
           await _productRepository.Save();
           return OperationResult.Success();
        }
    }
}
