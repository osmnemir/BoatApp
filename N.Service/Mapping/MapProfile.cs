using AutoMapper;
using N.Core.DTOs;
using N.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N.Service.Mapping;

public class MapProfile:Profile
{

    public MapProfile()     
    {
        CreateMap<Product, ProductDto>().ReverseMap();
        CreateMap<Category, CategoryDto>().ReverseMap();
        CreateMap<ProductFeature, ProductFeatureDto>().ReverseMap();
        CreateMap<ProductUpdateDto, Product>();
        //CreateMap<Product, ProductWithCategoryDto>();
        //CreateMap<Category, CategoryWithProductsDto>();
    }
}
