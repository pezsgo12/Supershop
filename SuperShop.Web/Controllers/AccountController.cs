using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using SuperShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperShop.Web.Controllers
{
    //public interface IMyUserService
    //{
    //    Task CreateUserAsync(ShopUser user, string password);
    //}
    //public class MyUserService: UserManager<ShopUser>, IMyUserService
    //{
    //    // TODO Ctor
    //    public async Task CreateUserAsync(ShopUser user, string password)
    //    {
    //        var identityResult = await base.CreateAsync(user, password);
    //        await context.SaveChangesAsync();
    //        //if (identityResult.Succeeded == false)
    //        //    throw new Exception("");
    //    }
    //}


    //public class MyUserStore : UserStore<ShopUser>
    //{
    //    public MyUserStore(DbContext context, IdentityErrorDescriber describer = null) : base(context, null)
    //    {
    //        this.AutoSaveChanges = false;
    //    }
    //}
    public class AccountController : Controller
    {
        private readonly UserManager<ShopUser> userManager;
        private readonly SignInManager<ShopUser> signInManager;
        // RoleManager<ShopRole>

        public AccountController(UserManager<ShopUser> userManager, SignInManager<ShopUser> signInManager)
        {
            this.userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            this.signInManager = signInManager;
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

        public IActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string returnUrl, Models.Account.Login vm)
        {
            var result = await signInManager.PasswordSignInAsync(vm.Email, vm.Password, isPersistent: false, lockoutOnFailure: false);
            if (!result.Succeeded)
            {
                // TODO: handle error => Redirect to login
            }

            if (string.IsNullOrWhiteSpace(returnUrl))
                return RedirectToAction("Index", "Products");
            else
                return Redirect(returnUrl);
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }

    }
}
