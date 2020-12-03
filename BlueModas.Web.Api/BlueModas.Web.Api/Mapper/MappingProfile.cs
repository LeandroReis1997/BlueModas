using AutoMapper;
using BlueModas.Web.Api.DTO;
using BlueModas.Web.Info.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueModas.Web.Api.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductDTO, ProductInfo>();

            CreateMap<ProductListDTO, ProductInfo>().ReverseMap();

            CreateMap<SaleDTO, SaleInfo>();
        }
    }
}
