using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SuperShop.Web
{
    public class ErrorHandlerware
    {
        private RequestDelegate next;

        public ErrorHandlerware(RequestDelegate next)
        {
            this.next = next ?? throw new ArgumentNullException(nameof(next));
        }

        public async Task Invoke(HttpContext context)
        {
            //context.Response.StatusCode = (int)HttpStatusCode.Redirect;
            //context.Response.Headers["Location"] = 

            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "text/html";
            var ex = context.Features.Get<IExceptionHandlerPathFeature>()?.Error;
            await context.Response.WriteAsync($"<html><body>ERROR!<br>{ex.Message}</body></html>");
        }
    }
}
