using Common.Application;
using Common.Application.SecurityUtil;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using Shop.Application.User.AddToken;
using Shop.Application.User.Create;
using Shop.Application.User.RemoveToken;
using Shop.Application.User.Update;
using Shop.Application.User.AddToken;
using Shop.Application.User.RemoveToken;
using Shop.Query.Users.DTOs;
using Shop.Query.Users.GetById;
using Shop.Query.Users.GetList;
using Shop.Query.Users.UserTokens.GetByJwtToken;
using Shop.Query.Users.UserTokens.GetByRefreshToken;
using Shop.Query.Users.GetByPhoneNumber;

namespace Shop.Presentation.Facade.User
{
    internal class UserFacade : IUserFacade
    {
        private readonly IMediator _mediator;
        //private IDistributedCache _cache;, IDistributedCache cache
        public UserFacade(IMediator mediator)
        {
            _mediator = mediator;
           // _cache = cache;
        }
        public async Task<OperationResult> CreateUser(CreateUserCommand command)
        {
            return await _mediator.Send(command);
        }


        public async Task<OperationResult> AddToken(AddUserTokenCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> RemoveToken(RemoveUserTokenCommand command)
        {
            //var result = await _mediator.Send(command);

            //if (result.Status != OperationResultStatus.Success)
            //    return OperationResult.Error();

            //await _cache.RemoveAsync(CacheKeys.UserToken(result.Data));
            return OperationResult.Success();
        }
        public async Task<OperationResult> EditUser(UpdateUserCommand command)
        {
            return await _mediator.Send(command);
        }
        public async Task<UserTokenDto?> GetUserTokenByRefreshToken(string refreshToken)
        {
            var hashRefreshToken = Sha256Hasher.Hash(refreshToken);
            return await _mediator.Send(new GetUserTokenByRefreshTokenQuery(hashRefreshToken));
        }

        public async Task<UserTokenDto?> GetUserTokenByJwtToken(string jwtToken)
        {
            var hashJwtToken = Sha256Hasher.Hash(jwtToken);
            return await _mediator.Send(new GetUserTokenByJwtTokenQuery(hashJwtToken));
        }
        public async Task<UserDto?> GetUserById(long userId)
        {
            return await _mediator.Send(new GetUserByIdQuery(userId));
        }

        public async Task<List<UserDto>> GetUsers()
        {
            return await _mediator.Send(new GetUserListQuery());
        }
        public async Task<UserDto?> GetUserByPhoneNumber(string phoneNumber)
        {
            return await _mediator.Send(new GetUserByPhoneNumberQuery(phoneNumber));
        }
    }
}
