using Microsoft.Extensions.DependencyInjection;
//using Shop.Presentation.Facade.Permission;
using Shop.Presentation.Facade.Product;
using Shop.Presentation.Facade.Role;
using Shop.Presentation.Facade.User;

namespace Shop.Presentation.Facade;

public static class FacadeBootstrapper
{
    public static void InitFacadeDependency(this IServiceCollection services)
    {

        services.AddScoped<IProductFacade, ProductFacade>();
        services.AddScoped<IRoleFacade, RoleFacade>();
        //services.AddScoped<IPermissionFacade, PermissionFacade>();
        services.AddScoped<IUserFacade, UserFacade>();

    }
}