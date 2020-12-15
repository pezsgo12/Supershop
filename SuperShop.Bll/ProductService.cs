using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using SuperShop.Dal;
using SuperShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


[assembly: InternalsVisibleTo("SuperShop.UnitTest")]

namespace SuperShop.Bll
{
    // POCO
    internal class ProductService : IProductService
    {
        private readonly SuperShopContext context;
        public ProductService(SuperShopContext context)
        {
            this.context = context;
        }

        public async Task<Product> CreateProductAsync(Product p)
        {
            // val;
            p.Discontinued = false;
            p.UnitsInStock = 0;
            context.Products.Add(p);
            await context.SaveChangesAsync();
            return p;
        }

        public async Task<Product> EditProductAsync(Product p)
        {
            // p.ownerid==currentuserID
            context.Update(p);
            await context.SaveChangesAsync();
            return p;
        }

        public async Task<IReadOnlyList<Product>> GetAvailableProductsAsync()
        {
            var model = await context.Products
                                     .Include(p => p.Category)
                                     .Where(p => !p.Discontinued).ToListAsync();
            return model;
        }

        public async Task<Product> GetProduct(int productId)
        {
            return await context.Products.FindAsync(productId);
        }
    }
}
