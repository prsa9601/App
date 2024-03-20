using Common.Application;
using Shop.Application.User.AddToken;
using Shop.Application.User.Create;
using Shop.Application.User.RemoveToken;
using Shop.Application.User.Update;
using Shop.Query.Users.DTOs;

namespace Shop.Presentation.Facade.User
{
    public interface IUserFacade
    {
        Task<OperationResult> CreateUser(CreateUserCommand command);
        Task<OperationResult> EditUser(UpdateUserCommand command);
        Task<OperationResult> AddToken(AddUserTokenCommand command);
        Task<OperationResult> RemoveToken(RemoveUserTokenCommand command);

        Task<UserDto?> GetUserById(long userId);
        Task<List<UserDto>> GetUsers();
        Task<UserDto?> GetUserByPhoneNumber(string phoneNumber);
        Task<UserTokenDto?> GetUserTokenByRefreshToken(string refreshToken);
        Task<UserTokenDto?> GetUserTokenByJwtToken(string jwtToken);
    }
}
