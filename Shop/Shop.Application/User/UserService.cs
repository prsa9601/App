using Shop.Domain.UserAgg.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Domain.UserAgg.Repository;

namespace Shop.Application.User
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public bool IsUserNameExist(string userName)
        {
            return _repository.Exists(r => r.UserName == userName);
        }

        public bool IsPhoneNumberExist(string phoneNumber)
        {
            return _repository.Exists(r => r.PhoneNumber == phoneNumber);
        }
    }
}
