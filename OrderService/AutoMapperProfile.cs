using Application.Features.OrdersFeatures.Dtos;
using AutoMapper;
using Core.Entities;

namespace OrderService;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<OrderDto, OrderEntity>().ReverseMap();
    }
}
