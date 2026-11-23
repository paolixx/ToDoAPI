using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Todo.Domain.DomainEntities;
using ToDo.Infrastructure.Persistence.Entities;

namespace ToDo.Infrastructure.Mappers
{
    internal class UserMappingExtension : Profile
    {
        public UserMappingExtension()
        {
            CreateMap<User, UserDomain>().ReverseMap();
        }
    }
}
