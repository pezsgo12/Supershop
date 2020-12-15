using Microsoft.Extensions.DependencyInjection;
using SuperShop.Dal;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperShop.Bll
{
    public static class RegisterBusinessServices
    {
        public static void Register(IServiceCollection services)
        {
            RegisterDataServices.Register(services);
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<ICategoryService, CategoryService>();
        }
    }
}
