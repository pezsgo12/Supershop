using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace SuperShop.Model
{
    public class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; private set; }
        public ShopUser ShopUser { get; set; }
        public string ShopUserId { get; set; }
    }
}
