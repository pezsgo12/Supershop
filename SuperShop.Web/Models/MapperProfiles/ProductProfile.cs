using AutoMapper;
using SuperShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperShop.Web.Models.MapperProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, Models.Shared.ProductIndex>()
                              .ForMember(vm=>vm.CategoryName, c => c.MapFrom( p=>p.Category.CategoryName ));
            CreateMap<Models.Products.Create, Product>();
            CreateMap<Models.Products.Edit, Product>();//.ReverseMap();
            CreateMap<Product, Models.Products.Edit>();
        }
    }
}
