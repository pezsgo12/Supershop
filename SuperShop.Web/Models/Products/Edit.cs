using Microsoft.AspNetCore.Mvc.Rendering;
using SuperShop.Model;
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
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public bool Discontinued { get; set; }
        public int CategoryId { get; set; }
        public IReadOnlyList<Models.Shared.CategoryViewModel> Categories { get; set; }
        // public SelectList Categories { get; set; }
    }
}
