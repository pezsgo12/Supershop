using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SuperShop.Bll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperShop.Web.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService cartService;

        public CartController(ICartService cartService)
        {
            this.cartService = cartService;
        }

        public async Task<IActionResult> Index()
        {
            var cartData = await cartService.GetItemsAsync();
            return View(cartData);
        }

        [Authorize(Roles = "user")]
        public async Task<IActionResult> Order()
        {
            var t = await cartService.CreateOrderAsync();
            // return RedirectToAction("Details","Orders");
            return RedirectToAction("Index", "Products");
        }
    }
}
