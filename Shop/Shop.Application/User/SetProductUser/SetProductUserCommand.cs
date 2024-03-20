using Common.Application;
using FluentValidation;
using Shop.Domain.ProductAgg.Services;
using Shop.Domain.RoleAgg.Services;
using Shop.Domain.UserAgg;
using Shop.Domain.UserAgg.Repository;

namespace Shop.Application.User.SetProductUser
{
    public record SetProductUserCommand(long UserId, long ProductId) : IBaseCommand;
    internal class SetProductUserCommandHandler:IBaseCommandHandler<SetProductUserCommand>
    {
        private readonly IUserRepository _repository;
        private readonly IProductService _service;
        public SetProductUserCommandHandler(IUserRepository repository, IProductService service)
        {
            _repository = repository;
            _service = service;
        }

        public async Task<OperationResult> Handle(SetProductUserCommand request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetTracking(request.UserId);
            if (product == null) 
                return OperationResult.NotFound();
            product.AddProducts(new UserProduct(request.ProductId));
            await _repository.Save();
            return OperationResult.Success();
        }
    }
    internal class SetProductUserCommandValidator:AbstractValidator<SetProductUserCommand>
    {
    }
}
