using Common.Domain;
using Common.Domain.Exceptions;
using Common.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Domain.RoleAgg.Enums;
using Shop.Domain.UserAgg.Services;
using Shop.Domain.UserAgg;

namespace Shop.Domain.ProductAgg
{
    public class Product : BaseEntity
    {
        private Product()
        {
           // Permissions = new List<Permission>();
        }
        public Product(string title, string price)
        {
            Title = title;
            Price = price;
        }

        public string Title { get; private set; }
        public string Price { get; private set; }
        public long UserId { get; set; }
       // public List<Domain.PermissionAgg.Permission> Permissions { get; private set; }

        public void Edit(string title, string price)
        {
            Title = title;
            Price = price;
        }
        public void SetUser(long userId)
        {
            UserId = userId;
        }
        //public void SetPermission(bool CanUpdate, bool CanDelete)
        //{
        //    var permission = new PermissionAgg.Permission(CanUpdate, CanDelete);
        //    Permissions.Add(permission);
        //}
        //public void Add(string title, string price)
        //{
        //    Title = title;
        //    Price = price;
        //}

        public void Guard(string title, string price, Domain.ProductAgg.Services.IProductService service)
        {
            NullOrEmptyDomainDataException.CheckString(title, nameof(title));
            NullOrEmptyDomainDataException.CheckString(price, nameof(price));
            if (title != Title)
                    throw new InvalidDomainDataException("نام محصول را وارد کنید.");
            if (price != Price)
                    throw new InvalidDomainDataException("قیمت محصول خود را وارد کنید.");
            if(Convert.ToInt32(price) <= 500 )
                    throw new InvalidDomainDataException("قیمت محصول باید بالای 500 تومان باشد.");
        }

    }
}
