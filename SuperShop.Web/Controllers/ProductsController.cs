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
        private readonly ProductService productService;
        public ProductsController(ProductService productService)
        {
            this.productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await productService.GetAvailableProductsAsync());
        }
    }
}
