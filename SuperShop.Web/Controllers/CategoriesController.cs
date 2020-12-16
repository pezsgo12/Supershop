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
        private readonly IMapper mapper;
        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            this.categoryService = categoryService;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await categoryService.GetCategoriesAsync();
            return View(mapper.Map<List<Models.Shared.IndexCategoryViewModel>>(categories));
        }
    }
}
