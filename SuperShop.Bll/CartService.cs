using SuperShop.Dal;
using SuperShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperShop.Bll
{
    //public interface ICart
    //{
    //    void Add(int productId, int count);
    //    void ClearCart();
    //    IReadOnlyList<CartItem> GetItems();
    //    CartItem GetItem();
    //}

    //public class SessionCart : ICart
    //{

    //}

    public class CartService : ICartService
    {
        private readonly SuperShopContext superShopContext;
        private readonly ICartHandler cartHandler;
        public CartService(SuperShopContext superShopContext, ICartHandler cartHandler)
        {
            this.superShopContext = superShopContext;
            this.cartHandler = cartHandler;
        }

        public async Task AddAsync(int productId, int count)
        {
            var cart = cartHandler.GetCartItemsFromSession();
            var element = cart.SingleOrDefault(ci => ci.ProductId == productId);
            if (element != null)
            {
                element.Count = element.Count + count;
            }
            else
            {
                cart.Add(new CartItem { ProductId = productId, Count = count });
            }
            cartHandler.SetCartIntoSession(cart);
        }

    

        public async Task<Order> CreateOrderAsync()
        {
            var order = new Order
            {
                OrderDate = DateTime.UtcNow
                // ShopUserId = httpContextAccessor.HttpContext.User;
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
            var cart = cartHandler.GetCartItemsFromSession();
            var result = new Dictionary<Product, int>();
            foreach (var item in cart)
            {
                result.Add(await superShopContext.Products.FindAsync(item.ProductId), item.Count);
            }
            return result;
        }

        public async Task EmptyCartAsync()
        {
            cartHandler.SetCartIntoSession(new List<CartItem>());
        }

    }
}
