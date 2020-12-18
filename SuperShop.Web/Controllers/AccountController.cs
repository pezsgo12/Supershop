using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SuperShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperShop.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ShopUser> userManager;
        // RoleManager<ShopRole>

        public AccountController(UserManager<ShopUser> userManager)
        {
            this.userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(Models.Account.Register vm)
        {
            
            // TODO Use automapper
            var user = new ShopUser
            {
                UserName = vm.Email,
                Email = vm.Email,
            };
            var createResult = await userManager.CreateAsync(user, vm.Password);
            if (!createResult.Succeeded)
            {
                // TODO: Handle error
            }

            if (vm.IsAdmin)
            {
                await userManager.AddToRoleAsync(user, "admin");
            }
            else
            {
                await userManager.AddToRoleAsync(user, "user");
            }

            return RedirectToAction("Login");
        }
    }
}
