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
            CreateMap<Product, Models.Products.Index>()
                              .ForMember(vm=>vm.CategoryName, c => c.MapFrom( p=>p.Category.CategoryName ));
        }
    }
}
