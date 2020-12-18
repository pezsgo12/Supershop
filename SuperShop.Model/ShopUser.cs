using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperShop.Model
{
    public class ShopUser : IdentityUser
    {
        public ShopUser()
        {
            Orders = new HashSet<Order>();
        }
        public DateTime? BirthDate { get; set; }
        public ICollection<Order> Orders { get; private set; }
    }
}
