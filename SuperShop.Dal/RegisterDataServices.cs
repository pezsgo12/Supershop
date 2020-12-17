using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperShop.Dal
{
    public static class RegisterDataServices
    {
        public static void Register(IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<SuperShopContext>(opt =>
            {
                opt.UseSqlServer(connectionString);
            });
        }
    }
}
