using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Todo.Domain.DomainEntities;
using ToDo.Application.Contracts;
using ToDo.Application.DTOs.Request;
using ToDo.Domain.RepositoryInterface;

namespace ToDo.Application.Implementation
{
    public class UserService(
        IUserRepository userRepository,
        IMapper mapper) : IUserService
    {
        public async Task<bool> CreateUserAsync(CreateUserDto userDto)
        {
            var userDomain = mapper.Map<UserDomain>(userDto);
            userDomain.PasswordHash = BCrypt.Net.BCrypt.HashPassword(userDomain.PasswordHash);

            await userRepository.AddAsync(userDomain);

            var response = await userRepository.CommitAsync();

            return response > 0;
        }
    }
}
