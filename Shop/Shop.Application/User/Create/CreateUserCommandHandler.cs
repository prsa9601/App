 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Application;
using Shop.Domain.UserAgg.Repository;
using Shop.Domain.UserAgg.Services;

namespace Shop.Application.User.Create
{
    public class CreateUserCommandHandler : IBaseCommandHandler<CreateUserCommand>
    {
        private readonly IUserRepository _repository;
        private readonly IUserService _service;

        public CreateUserCommandHandler(IUserRepository repository, IUserService service)
        {
            _repository = repository;
            _service = service ;
        }
        public async Task<OperationResult> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            if (!_service.IsPhoneNumberExist(request.PhoneNumber) || !_service.IsUserNameExist(request.UserName))
            {
                var User = new Domain.UserAgg.User(request.UserName, request.PhoneNumber, request.Password,
                    _service);
                await _repository.AddAsync(User);
                await _repository.Save();
                return OperationResult.Success();
            }
            return OperationResult.Error();
        }
    }
}
