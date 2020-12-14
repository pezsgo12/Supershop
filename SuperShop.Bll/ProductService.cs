using Microsoft.EntityFrameworkCore;
using SuperShop.Dal;
using SuperShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperShop.Bll
{
    // POCO
    public class ProductService
    {
        public async Task<IReadOnlyList<Product>> GetAvailableProductsAsync(SuperShopContext ctx)
        {
            var model = await ctx.Products.Where(p => !p.Discontinued).ToListAsync();
            return model;
        }
    }
}
