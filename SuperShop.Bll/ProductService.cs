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

        public async Task DeleteProductAsync(int productId)
        {
            var product = await context.Products.FindAsync(productId);
            context.Products.Remove(product);
            await context.SaveChangesAsync();
        }

        public async Task<Product> EditProductAsync(Product p)
        {
            if (p.CategoryId == 1 && p.UnitPrice < 40)
                throw new Exception("Ez nem stimmel így!");
            context.Update(p); // Upsert
            await context.SaveChangesAsync();
            return p;
        }

        public async Task<IReadOnlyList<Product>> GetAvailableProductsAsync(int? categoryId=default)
        {
            var allProducts = context.Products.Include(p => p.Category).Where(p => !p.Discontinued);
            
            if (categoryId.HasValue)
                allProducts = allProducts.Where(p => p.CategoryId == categoryId);

            return await allProducts.ToListAsync();
        }

        public async Task<Product> GetProductAsync(int productId)
        {
            return await context.Products.FindAsync(productId);
        }
    }
}
