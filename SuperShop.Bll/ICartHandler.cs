using System.Collections.Generic;

namespace SuperShop.Bll
{
    public interface ICartHandler
    {
        List<CartItem> GetCartItemsFromSession();
        void SetCartIntoSession(List<CartItem> cart);
        
    }
}