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
        private readonly SuperShopContext context;
        public ProductsController()
        {
            var builder = new DbContextOptionsBuilder<SuperShopContext>();
            builder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=SuperShop;Integrated Security=True");
            context = new SuperShopContext(builder.Options);
        }

        public async Task<IActionResult> Index()
        {
            ProductService productService = new ProductService();
            var model = await productService.GetAvailableProductsAsync(context);
            return View(model);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            context?.Dispose();
        }

        //public async Task<IActionResult> Index2()
        //{
        //    var builder = new DbContextOptionsBuilder<SuperShopContext>();
        //    builder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=SuperShop;Integrated Security=True");


        //    using (var context = new SuperShopContext(builder.Options))
        //    {
        //        ProductService productService = new ProductService();
        //        var model = await productService.GetAvailableProductsAsync2(context);
        //        return View(model);
        //    }
        //}
    }
}
