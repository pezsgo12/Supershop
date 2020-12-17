using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddlwwareTest
{
    public class GreetingMiddleware
    {
        private RequestDelegate next;
        public GreetingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var isGetRequest = context.Request.Method == HttpMethods.Get;
            var hasName = context.Request.Query.TryGetValue("name", out var nameQueryValue);
            if (isGetRequest && hasName)
            {
                await context.Response.WriteAsync("Szia " + nameQueryValue);
            }
            else
            {
                await next(context);
                // await new AnonymMiddleware().Invoke(context);
            }
        }
    }

    public class AnonymMiddleware
    {
        private readonly RequestDelegate next;
        public AnonymMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            await context.Response.WriteAsync("Téged sajnos nem ismerlek!");
        }
    }

    public interface IErrorHandlerService
    {
        Task HandleErrorAsync(HttpContext context, Exception ex);
    }

    public class ErrorHandlerService : IErrorHandlerService
    {
        public async Task HandleErrorAsync(HttpContext context, Exception ex)
        {
            await context.Response.WriteAsync(ex.Message);
        }
    }

    public class ErrorHandlerware
    {
        private readonly RequestDelegate next;
        private readonly IErrorHandlerService errorHandler;
        public ErrorHandlerware(RequestDelegate next, IErrorHandlerService errorHandler)
        {
            this.next = next;
            this.errorHandler = errorHandler;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await errorHandler.HandleErrorAsync(context, ex);
            }
        }
    }

    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IErrorHandlerService, ErrorHandlerService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<ErrorHandlerware>();

            //app.Map("/api", testApp =>
            //{
            //    testApp.Use(async (c, n) => {
            //        await c.Response.WriteAsync("Ez a teszt");
            //        await n();
            //    });
            //});
            
                
           app.UseMiddleware<GreetingMiddleware>();

            //app.Use(async (context,next) =>
            //{
            //    context.Items["PrevMiddleware"] = "Akos";
            //    await next();
            //});


            app.UseMiddleware<AnonymMiddleware>();
            

            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            //app.UseRouting();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World!");
            //    });
            //});
        }
    }
}
