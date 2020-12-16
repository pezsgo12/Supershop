using AutoMapper;
using SuperShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperShop.Web.Models.MapperProfiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, Models.Shared.SelectListCategoryViewModel>();
            CreateMap<Category, Models.Shared.IndexCategoryViewModel>()
                .ForMember(vm => vm.CategoryImage, c => c.MapFrom(model=>Convert.ToBase64String(model.Picture.Skip(78).ToArray())));
        }
    }
}
