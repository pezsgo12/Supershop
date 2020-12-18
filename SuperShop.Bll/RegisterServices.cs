using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SuperShop.Dal;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperShop.Bll
{
    public static class RegisterBusinessServices
    {
        public static void Register(IServiceCollection services, IConfiguration configuration)
        {
            RegisterDataServices.Register(services, configuration);
            services.AddTransient<IProductService, ProductService>()
                    .AddTransient<ICategoryService, CategoryService>()
                    .AddTransient<ICartService, CartService>();
        }
    }
}
