﻿using AutoMapper;
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
        private readonly IMapper mapper;
        public ProductsController(IProductService productService, IMapper mapper)
        {
            this.productService = productService;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var models = await productService.GetAvailableProductsAsync();
            var viewModels = mapper.Map<List<Models.Products.Index>>(models);
            //var viewModels = models.Select(m => new Models.Products.Index
            //                                    {
            //                                        CategoryName=m.Category.CategoryName,
            //                                        ProductName = m.ProductName,
            //                                        UnitPrice = m.UnitPrice,
            //                                        UnitsInStock = m.UnitsInStock
            //                                    });
            return View(viewModels);
        }
    }
}
