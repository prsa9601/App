using Common.Application;
using Shop.Domain.UserAgg.Repository;
using Shop.Domain.UserAgg.Services;

namespace Shop.Application.User.Update
{
    internal class UpdateUserCommandHandler : IBaseCommandHandler<UpdateUserCommand>
    {
        private readonly IUserRepository _Repository;
        private readonly IUserService _Service;
        public UpdateUserCommandHandler(IUserRepository repository, IUserService service)
        {
            _Repository = repository;
            _Service = service;
        }
        public async Task<OperationResult> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var User = await _Repository.GetTracking(request.UserId);
            if (User == null) 
                return OperationResult.NotFound();
            User.Edit(request.userName ,request.phoneNumber,request.password,_Service);
            await _Repository.Save();
            return OperationResult.Success();
        }
    }
}
