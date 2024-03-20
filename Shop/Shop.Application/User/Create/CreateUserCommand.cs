using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Application;

namespace Shop.Application.User.Create
{
    public record CreateUserCommand(string UserName, string PhoneNumber, string Password) : IBaseCommand;
}
