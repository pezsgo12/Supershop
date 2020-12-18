using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SuperShop.RestInterface.Dtos
{
    public class CreateProductDto 
    {
        [Required, StringLength(100)]
        public string ProductName { get; set; }
        
        public decimal UnitPrice { get; set; }
        
        [Range(1,8)]
        public int CategoryId { get; set; }
    }
}
