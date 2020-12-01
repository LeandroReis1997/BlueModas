using AutoMapper;
using BlueModas.Web.Core.DTO.Product;
using BlueModas.Web.Core.ViewModels;

namespace BlueModas.Web.Core.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductDTO, ProductViewModel>();

            CreateMap<ProductListDTO, ProductViewModel>();
        }
    }
}
