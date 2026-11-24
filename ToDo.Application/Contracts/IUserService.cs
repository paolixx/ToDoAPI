using System;
using System.Collections.Generic;
using System.Text;
using ToDo.Application.DTOs.Request;
using ToDo.Application.DTOs.Response;

namespace ToDo.Application.Contracts
{
    public interface IUserService
    {
        Task<bool> CreateUserAsync(CreateUserDto userDto);

        Task DetachUserAsync(Guid id);

        Task DeleteUserAsync(Guid id);

        Task<IEnumerable<UserResponseDto>> GetAllUsersAsync();

        Task<UserResponseDto> GetUserByIdAsync(Guid Id);
    }
}
