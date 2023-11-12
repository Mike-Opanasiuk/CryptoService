using Application.Features.AccountFeatures.Commands;
using Application.Features.AccountFeatures.Dtos;
using AutoMapper;
using Core.Entities;

namespace AuthService;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<UserEntity, UserDto>().ReverseMap();
        CreateMap<RegisterUserCommand, UserEntity>();
    }
}
