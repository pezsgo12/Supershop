﻿using System.Runtime.CompilerServices;
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

        public async Task<IReadOnlyList<Product>> GetAvailableProductsAsync()
        {
            var model = await context.Products
                                     .Include(p => p.Category)
                                     .Where(p => !p.Discontinued).ToListAsync();
            return model;
        }
    }
}
