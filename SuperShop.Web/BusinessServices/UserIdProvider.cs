using Microsoft.AspNetCore.Http;
using SuperShop.Bll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SuperShop.Web.BusinessServices
{
    public class UserIdProvider : IUserIdProvider
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public UserIdProvider(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        }

        public string GetCurrentUserId()
        {
            return httpContextAccessor.HttpContext.User?.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
