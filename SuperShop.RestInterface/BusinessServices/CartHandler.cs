using SuperShop.Bll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperShop.RestInterface.BusinessServices
{
    public class UserIdProvider : IUserIdProvider
    {
        public string GetCurrentUserId()
        {
            throw new NotImplementedException();
        }
    }
    public class CartHandler : ICartHandler
    {
        public List<CartItem> GetCartItemsFromSession()
        {
            throw new NotImplementedException();
        }

        public void SetCartIntoSession(List<CartItem> cart)
        {
            throw new NotImplementedException();
        }
    }
}
