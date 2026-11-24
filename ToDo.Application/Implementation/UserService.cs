using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Todo.Domain.DomainEntities;
using ToDo.Application.Contracts;
using ToDo.Application.DTOs.Request;
using ToDo.Application.DTOs.Response;
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

        public async Task DetachUserAsync(Guid id)
        {
            await userRepository.DetachAsync(id);
        }

        public async Task DeleteUserAsync(Guid id)
        {
            await userRepository.DeleteAsync(id);
            var response = await userRepository.CommitAsync();
        }

        public async Task<IEnumerable<UserResponseDto>> GetAllUsersAsync()
        {
            var users = await userRepository.GetAllAsync();

            return users.Select(u => mapper.Map<UserResponseDto>(u)).ToList();
        }

        public async Task<UserResponseDto> GetUserByIdAsync(Guid Id)
        {
            var user = await userRepository.GetByIdAsync(Id);

            return mapper.Map<UserResponseDto>(user);
        }
    }
}
