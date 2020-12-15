using AutoMapper;
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
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;
        private readonly IMapper mapper;
        public ProductsController(IProductService productService, IMapper mapper, ICategoryService categoryService)
        {
            this.productService = productService;
            this.mapper = mapper;
            this.categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var models = await productService.GetAvailableProductsAsync();
            return View(mapper.Map<List<Models.Products.Index>>(models));
        }

        // /Products/Create
        public async Task<IActionResult> Create()
        {
            return View();
        }


        // form proc.
        
        [HttpPost]
        public async Task<IActionResult> Create(Models.Products.Create createProductViewModel)
        {
            var savedProduct = 
                await productService.CreateProductAsync(mapper.Map<Product>(createProductViewModel));
            // TODO redirect to EDIT savedProduct.ProductId
            return RedirectToAction(nameof(Index));
        }

        // /Products/Edit/2001
        // /Products/Edit?productId=2001
        public async Task<IActionResult> Edit(int id)
        {
            var categories = await categoryService.GetCategoriesAsync();
            var vm = mapper.Map<Models.Products.Edit>(await productService.GetProductAsync(id));
            vm.Categories = categories;
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Models.Products.Edit editViewModel)
        {
            await productService.EditProductAsync(mapper.Map<Product>(editViewModel));
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            await productService.DeleteProductAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
