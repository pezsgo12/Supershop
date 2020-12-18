using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SuperShop.Bll;
using SuperShop.Dal;
using SuperShop.Model;
using SuperShop.Web.BusinessServices;
using SuperShop.Web.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;



namespace SuperShop.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));
            services.AddHttpContextAccessor();
            services.AddSession();
            services.AddControllersWithViews()
                .AddMvcOptions(opts => opts.Filters.Add(new ValidateModelFilterAttribute()));

            //.AddViewOptions(o=>o.HtmlHelperOptions.ClientValidationEnabled=false);
            services.AddScoped<PopulateCategoriesAttribute>();
            services.Configure<MyBusinessConfigOptions>(
                Configuration.GetSection(MyBusinessConfigOptions.MyBusinessConfigSection));

            services.AddTransient<ICartHandler, CartHandler>()
                    .AddTransient<IUserIdProvider, UserIdProvider>();
            RegisterBusinessServices.Register(services, Configuration);

            // services.AddScoped<MyUserStore, IUserStore<ShopUser>>();
            services.AddIdentity<ShopUser, IdentityRole>().AddEntityFrameworkStores<SuperShopContext>();
            services.Configure<IdentityOptions>(opts =>
            {
                opts.Password.RequireDigit = false;
                opts.Password.RequiredLength = 1;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireUppercase = false;
                opts.Password.RequireNonAlphanumeric = false;
            });
            services.ConfigureApplicationCookie(opts =>
            {
                opts.LoginPath = "/Account/Login";
                opts.AccessDeniedPath = "/Account/Login";
                //opts.ReturnUrlParameter = "ReturnUrl";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(errorApp => errorApp.UseMiddleware<ErrorHandlerware>());
                //app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();


            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                // endpoints.MapDefaultControllerRoute();
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");


                endpoints.MapControllerRoute(
                    name: "catRoute",
                    pattern: "kategoriak/{action=Index}/{id?}",
                    defaults: new { controller="Categories" }
                  );

                endpoints.MapControllerRoute(
                    name: "prodRoute",
                    pattern: "termekek/{action=Index}/{id?}",
                    defaults: new { controller="Products" }
                  );
            });
        }
    }
}
