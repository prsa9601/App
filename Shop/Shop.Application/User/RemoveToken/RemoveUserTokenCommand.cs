using Common.Application;

namespace Shop.Application.User.RemoveToken;

public record RemoveUserTokenCommand(long UserId,long TokenId) : IBaseCommand<string>;