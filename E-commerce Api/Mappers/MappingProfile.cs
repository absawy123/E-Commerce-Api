using AutoMapper;
using Domain.Entities;
using E_commerce_Api.Dtos.category;
using E_commerce_Api.Dtos.order;
using E_commerce_Api.Dtos.product;

namespace E_commerce_Api.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Add_UpdateCategoryDto, Category>();
            CreateMap<Add_UpdateOrderDto, Order>();
        }
    }
}
