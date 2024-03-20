using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Shop.Application.Product.Create;
using Shop.Application.User.Create;
//using Shop.Application._Utilities;
//using Shop.Application.Categories;
//using Shop.Application.Products;
//using Shop.Application.Roles.Create;
//using Shop.Application.Sellers;
//using Shop.Application.Users;
//using Shop.Domain.CategoryAgg.Services;
using Shop.Domain.ProductAgg.Services;
//using Shop.Domain.SellerAgg.Services;
using Shop.Domain.UserAgg.Services;
using Shop.Infrastructure;
using Shop.Presentation.Facade;
using Shop.Query.Users.GetById;
using System.Reflection;
using Shop.Application.Products;
using Shop.Application.Role;
using Shop.Application.User;
using Shop.Domain.RoleAgg.Services;

//using Shop.Query.Categories.GetById;

namespace Shop.Config
{
    public static class ShopBootstrapper
    {
        public static void RegisterShopDependency(this IServiceCollection services, string connectionString)
        {
            InfrastructureBootstrapper.Init(services, connectionString);

            services.AddMediatR(typeof(Directory).Assembly);
            services.AddMediatR(typeof(CreateUserCommandHandler).Assembly);

            services.AddMediatR(typeof(GetUserByIdQuery).Assembly);

            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IRoleService, RoleService>();
            //services.AddTransient<ICategoryDomainService, CategoryDomainService>();
            //services.AddTransient<ISellerDomainService, SellerDomainService>();


            services.AddValidatorsFromAssembly(typeof(CreateUserCommandValidator).Assembly);

            services.InitFacadeDependency();
        }
    }
}