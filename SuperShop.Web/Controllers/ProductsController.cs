using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperShop.Bll;
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
        public async Task<IActionResult> Index()
        {
            var builder = new DbContextOptionsBuilder<SuperShopContext>();
            builder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=SuperShop;Integrated Security=True");


            using (var context = new SuperShopContext(builder.Options))
            {
                ProductService productService = new ProductService();
                var model = await productService.GetAvailableProductsAsync(context);
                return View(model);
            }
        }
    }
}
