using Microsoft.AspNetCore.Http;
using SuperShop.Dal;
using SuperShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperShop.Bll
{
    public class CartService : ICartService
    {
        private class CartItem
        {
            public int ProductId { get; set; }
            public int Count { get; set; }
        }


        private readonly IHttpContextAccessor httpContextAccessor;
        private const string cartKey = "cart";
        private readonly SuperShopContext superShopContext;

        public CartService(IHttpContextAccessor httpContextAccessor, SuperShopContext superShopContext)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.superShopContext = superShopContext;
        }

        public async Task AddAsync(int productId, int count)
        {
            // TODO: Business logic validation: if discontinued=>err
            // if unitinstock<count => err
            // if productId invalid
            var session = httpContextAccessor.HttpContext.Session;
            var cart = session.GetJson<List<CartItem>>(cartKey) ?? new List<CartItem>();
            var element = cart.SingleOrDefault(ci => ci.ProductId == productId);
            if (element != null)
            {
                element.Count = element.Count + count;
            }
            else
            {
                cart.Add(new CartItem { ProductId = productId, Count = count });
            }
            session.SetJson(cartKey, cart);
        }


        public async Task<Order> CreateOrderAsync()
        {
            var order = new Order
            {
                OrderDate = DateTime.UtcNow
                // ShopUserId = currentUser??
            };
            var cartItems = await GetItemsAsync();
            var orderDetails = cartItems.Select(kvp => new OrderDetail
            {
                ItemCount = kvp.Value,
                ProductId = kvp.Key.ProductId,
                Price = kvp.Key.UnitPrice,
                Order = order
            });

            foreach (var orderDetail in orderDetails)
            {
                superShopContext.OrderDetails.Add(orderDetail);
            }
            await superShopContext.SaveChangesAsync();
            // TODO: termék darabszám csökkent
            await EmptyCartAsync();
            return order;
        }

        public async Task<IReadOnlyDictionary<Product, int>> GetItemsAsync()
        {
            var cart = httpContextAccessor.HttpContext.Session.GetJson<List<CartItem>>(cartKey);
            var result = new Dictionary<Product, int>();
            foreach (var item in cart)
            {
                result.Add(await superShopContext.Products.FindAsync(item.ProductId), item.Count);
            }
            return result;
        }

        public async Task EmptyCartAsync()
        {
            httpContextAccessor.HttpContext.Session.SetJson(cartKey, new List<CartItem>());
        }

    }
}
