using Common.Domain;
using Common.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Domain.ProductAgg;
using Shop.Domain.ProductAgg.Services;
using Shop.Domain.RoleAgg;
using Shop.Domain.RoleAgg.Services;

namespace Shop.Domain.UserAgg
{
    public class User : BaseEntity
    {
        public string UserName { get; private set; }
        public string PhoneNumber { get; private set; }
        public bool IsActive { get; private set; }
        public string Password { get; private set; }

        public List<UserRole> Roles { get; }
        public List<UserProduct> Products { get;  }
        public List<UserToken> Tokens { get; }
        private User()
        {
            //Products = new List<Domain.ProductAgg.Product>();
        }
        //, List<ProductAgg.Product> product 
        public User(string userName, string phoneNumber, string password, Domain.UserAgg.Services.IUserService service)
        {
            Guard(userName, phoneNumber, service);
            UserName = userName;
            PhoneNumber = phoneNumber;
            Password = password;
            Products = new();
            IsActive = true;
            Roles = new();
            Tokens = new();
            // Products = new List<ProductAgg.Product>();
        }
        public void Edit(string userName, string phoneNumber, string password, Domain.UserAgg.Services.IUserService service)
        {
            Guard(userName, phoneNumber, service);
            UserName = userName;
            PhoneNumber = phoneNumber;
            Password = password;
        }
      
        //public void SetRoleForUser(RoleAgg.Role role)
        //{
        //    Role = role;
        //}
        public void SetRoles(List<UserRole> roles)
        {
            roles.ForEach(f => f.UserId = id);
            Roles.Clear();
            Roles.AddRange(roles);
        }
      
        public void AddProducts(UserProduct products)
        {
            Products.Add(products);
        }
        public void AddToken(string hashJwtToken, string hashRefreshToken, DateTime tokenExpireDate, DateTime refreshTokenExpireDate, string device)
        {
            var activeTokenCount = Tokens.Count(c => c.RefreshTokenExpireDate > DateTime.Now);
            if (activeTokenCount == 3)
                throw new InvalidDomainDataException("امکان استفاده از 4 دستگاه همزمان وجود ندارد");

            var token = new UserToken(hashJwtToken, hashRefreshToken, tokenExpireDate, refreshTokenExpireDate, device);
            token.UserId = id;
            Tokens.Add(token);
        }

        public string RemoveToken(long tokenId)
        {
            var token = Tokens.FirstOrDefault(f => f.id == tokenId);
            if (token == null)
                throw new InvalidDomainDataException("invalid TokenId");

            Tokens.Remove(token);
            return token.HashJwtToken;
        }
        public void Guard(string userName, string phoneNumber, Domain.UserAgg.Services.IUserService service)
        {
            NullOrEmptyDomainDataException.CheckString(userName, nameof(userName));
            NullOrEmptyDomainDataException.CheckString(phoneNumber, nameof(phoneNumber));
            if (userName != UserName)
                if (service.IsUserNameExist(userName))
                    throw new InvalidDomainDataException(".نام کاربری خود را وارد کنید");
            if (phoneNumber != PhoneNumber)
                if (service.IsPhoneNumberExist(PhoneNumber))
                    throw new InvalidDomainDataException("فیلد شماره تماس نمیتواند خالی باشد.");
        }
    }
}
