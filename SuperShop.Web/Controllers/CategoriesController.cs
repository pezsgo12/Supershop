using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SuperShop.Bll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperShop.Web.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly IProductService productService;
        private readonly IMapper mapper;
        public CategoriesController(ICategoryService categoryService, IMapper mapper, IProductService productService)
        {
            this.categoryService = categoryService;
            this.mapper = mapper;
            this.productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await categoryService.GetCategoriesAsync();
            return View(mapper.Map<List<Models.Shared.IndexCategoryViewModel>>(categories));
        }

        [Route("categories/{categoryId:int}/products", Name = "ProductsByCategoryRoute")]
        public async Task<IActionResult> ProductsForCategory(int categoryId)
        {
            var model = await productService.GetAvailableProductsAsync(categoryId);
            var vms = mapper.Map<List<Models.Shared.ProductIndex>>(model);
            return View("ProductIndex", vms);
        }
    }
}
