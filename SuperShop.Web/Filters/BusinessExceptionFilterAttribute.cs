using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperShop.Web.Filters
{
    public sealed class BusinessExceptionFilterAttribute : Attribute, IAsyncExceptionFilter
    {
        public async Task OnExceptionAsync(ExceptionContext context)
        {
            // context.Exception
            context.Result = 
                new ViewResult 
                { 
                    ViewName = "~/Views/Shared/Error.cshtml", 
                    //ViewData = new Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary { Model= mv } 
                };
        }
    }
}
