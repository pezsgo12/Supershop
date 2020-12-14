using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperShop.Dal;
using SuperShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperShop.Web.Controllers
{
    public class ProductsController : Controller
    {
        // GET; body={}; url: /Products/Index
        public async Task<IActionResult> Index()
        {
            using (var ctx = new SuperShopContext())
            {
                var model = await ctx.Products.Where(p=>!p.Discontinued).ToListAsync();
                return View(model);
            }
        }
    }
}
