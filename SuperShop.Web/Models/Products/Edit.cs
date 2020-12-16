using Microsoft.AspNetCore.Mvc.Rendering;
using SuperShop.Model;
using SuperShop.Web.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SuperShop.Web.Models.Products
{
    public class Edit
    {
        public int ProductId { get; set; }

        [Required, StartsWithUppercase]
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public bool Discontinued { get; set; }
        public int CategoryId { get; set; }
    }
}
