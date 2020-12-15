using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperShop.Dal
{
    public static class RegisterDataServices
    {
        public static void Register(IServiceCollection services)
        {
            services.AddDbContext<SuperShopContext>(opt =>
                opt.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=SuperShop;Integrated Security=True"));
        }
    }
}
