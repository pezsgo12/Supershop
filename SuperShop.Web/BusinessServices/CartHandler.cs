using Microsoft.AspNetCore.Http;
using SuperShop.Bll;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperShop.Web.BusinessServices
{
    public class CartHandler : ICartHandler
    {
        private const string cartKey = "cart";
        private readonly IHttpContextAccessor httpContextAccessor;

        public CartHandler(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public List<CartItem> GetCartItemsFromSession()
        {
            var session = httpContextAccessor.HttpContext.Session;
            var cart = session.GetJson<List<CartItem>>(cartKey) ?? new List<CartItem>();
            return cart;
        }

        public void SetCartIntoSession(List<CartItem> cart)
        {
            httpContextAccessor.HttpContext.Session.SetJson(cartKey, cart);
        }
    }
}
