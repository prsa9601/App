using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Application;

namespace Shop.Application.User.Update
{
    public record UpdateUserCommand(long UserId, string userName, string phoneNumber, string password) : IBaseCommand;
}
