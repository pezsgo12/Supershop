using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Index()
        {
            Product model = new Product
            {
                ProductName = "Labda",
                UnitPrice = 10,
                UnitsInStock = 1
            };

            return View(model);
        }
    }
}
