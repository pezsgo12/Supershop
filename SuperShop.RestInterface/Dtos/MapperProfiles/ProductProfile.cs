using AutoMapper;
using SuperShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperShop.RestInterface.Dtos.MapperProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>()
                              .ForMember(vm=>vm.CategoryName, c => c.MapFrom( p=>p.Category.CategoryName ));
            CreateMap<CreateProductDto, Product>();
        }
    }
}
