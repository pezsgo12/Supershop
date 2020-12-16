using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperShop.Web.Filters
{
    public abstract class PopulateViewBagAttribute : Attribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var controller = (Controller)context.Controller;
            await PopulateViewBagAsync(controller.ViewBag);
            await next();
        }

        protected abstract Task PopulateViewBagAsync(dynamic viewBag);
    }
}
