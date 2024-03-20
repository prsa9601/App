using AppRazorPage.Models.User;
using Eshop.RazorPage.Models;

namespace AppRazorPage.Services.Users
{
    public interface IUserService
    {
        public ApiResult AddUser(AddUserCommand command);
    }
}
