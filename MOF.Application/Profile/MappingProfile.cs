using AutoMapper;
using MOF.Application.DOTs.Products;
using MOF.Domain.Entities;

namespace MOF.Application.Profiles
{
    public  class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();


        }
    }
}
