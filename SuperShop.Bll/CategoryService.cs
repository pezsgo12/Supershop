using Microsoft.EntityFrameworkCore;
using SuperShop.Dal;
using SuperShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperShop.Bll
{
    public class CategoryService : ICategoryService
    {
        private readonly SuperShopContext superShopContext;
        public CategoryService(SuperShopContext superShopContext)
        {
            this.superShopContext = superShopContext;
        }

        public async Task<IReadOnlyList<Category>> GetCategoriesAsync()
        {
            return await superShopContext.Categories.ToListAsync();
        }
    }
}
