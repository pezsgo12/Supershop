using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperShop.Bll;
using SuperShop.Model;
using SuperShop.RestInterface.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperShop.RestInterface.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService productService;
        private readonly IMapper mapper;

        public ProductsController(IProductService productService, IMapper mapper)
        {
            this.productService = productService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await productService.GetAvailableProductsAsync();
            var dtos = mapper.Map<List<ProductDto>>(products);
            return Ok(dtos);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto dto)
        {
            var product = mapper.Map<Product>(dto);
            product = await productService.CreateProductAsync(product);
            // return Ok();
            return Created("/api/Products/", product);
        }
    }
}
