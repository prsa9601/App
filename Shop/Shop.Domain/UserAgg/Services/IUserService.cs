using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.UserAgg.Services
{
    public interface IUserService
    {
        bool IsUserNameExist(string phoneNumber);
        bool IsPhoneNumberExist(string phoneNumber);

    }
}
