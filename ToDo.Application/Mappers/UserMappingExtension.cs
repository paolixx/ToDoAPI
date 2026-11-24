using AutoMapper;
using Todo.Domain.DomainEntities;
using ToDo.Application.DTOs.Request;
using ToDo.Application.DTOs.Response;

namespace ToDo.Application.Mappers
{
    public class UserMappingExtension : Profile
    {
        public UserMappingExtension()
        {
            CreateMap<CreateUserDto, UserDomain>()
                .ForMember(dest => dest.PasswordHash, opt =>
                    opt.MapFrom(src => src.Password));

            CreateMap<UserDomain, UserResponseDto>();
        }
    }
}
