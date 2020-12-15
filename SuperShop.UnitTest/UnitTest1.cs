using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using SuperShop.Bll;
using SuperShop.Dal;
using SuperShop.Model;
using System.Threading.Tasks;

namespace SuperShop.UnitTest
{
    [TestFixture]
    public class Tests
    { 
        [Test]
        public async Task Test1()
        {
            var builder = new DbContextOptionsBuilder<SuperShopContext>();
            builder.UseInMemoryDatabase("test");

            using (var context = new SuperShopContext(builder.Options))
            {
                var temp = new Category() { CategoryId = 1 };
                context.Categories.Add(temp);
                context.Products.Add(new Model.Product { ProductId = 1, Discontinued = false, Category = temp });
                context.Products.Add(new Model.Product { ProductId = 2, Discontinued = true, Category = temp });
                context.SaveChanges();

                ProductService productService = new ProductService(context);
                var model = await productService.GetAvailableProductsAsync();
                Assert.That(model, Is.All.Matches<Model.Product>(p => !p.Discontinued));
                Assert.That(model.Count == 1);
                Assert.That(model[0].ProductId == 1);
            }

        }
    }
}