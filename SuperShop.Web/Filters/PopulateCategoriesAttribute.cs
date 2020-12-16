using AutoMapper;
using SuperShop.Bll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperShop.Web.Filters
{
    public sealed class PopulateCategoriesAttribute : PopulateViewBagAttribute
    {
        private readonly IMapper mapper;
        private readonly ICategoryService categoryService;

        public PopulateCategoriesAttribute(IMapper mapper, ICategoryService categoryService)
        {
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
        }

        protected async override Task PopulateViewBagAsync(dynamic viewBag)
        {
            var categories = await categoryService.GetCategoriesAsync();
            viewBag.Categories = mapper.Map<List<Models.Shared.SelectListCategoryViewModel>>(categories);
        }
    }
}
