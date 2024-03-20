using Common.Application;
using FluentValidation;
using Shop.Domain.ProductAgg.Repository;
using Shop.Domain.UserAgg.Services;

namespace Shop.Application.Product.SetUserProduct
{
    public record SetUserProductCommand(long UserId, long ProductId) : IBaseCommand;
    
    internal class SetUserProductCommandHandler:IBaseCommandHandler<SetUserProductCommand>
    {
        private readonly IProductRepository _repository;
        private readonly IUserService _service;

        public SetUserProductCommandHandler(IProductRepository repository, IUserService service)
        {
            _repository = repository;
            _service = service;
        }

        public async Task<OperationResult> Handle(SetUserProductCommand request, CancellationToken cancellationToken)
        {
            var product= await _repository.GetTracking(request.ProductId);
            if (product == null)
                return OperationResult.NotFound();
            product.SetUser(request.UserId);
            await _repository.Save();
            return OperationResult.Success();   
        }
    }
    internal class SetUserProductCommandValidator:AbstractValidator<SetUserProductCommand>
    {

    }
}
