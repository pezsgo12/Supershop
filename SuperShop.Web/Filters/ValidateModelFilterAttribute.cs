using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperShop.Web.Filters
{
    public sealed class ValidateModelFilterAttribute : Attribute, IAsyncActionFilter
    {
        // public string ViewName { get; set; }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, 
                                           ActionExecutionDelegate next)
        {
            if (context.ModelState.IsValid)
                await next();
            else
            {
                var controller = (Controller)context.Controller;
                var controllerName = controller.HttpContext.Request.RouteValues["controller"];
                var actionName = controller.HttpContext.Request.RouteValues["action"];
                string viewName = $"~/Views/{controllerName}/{actionName}.cshtml";
                var incomingModel = context.ActionArguments.First().Value;
                
                context.Result = controller.View(viewName, incomingModel);
            }
        }
    }
}
