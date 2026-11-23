using System;
using System.Collections.Generic;
using System.Text;
using ToDo.Application.DTOs.Request;

namespace ToDo.Application.Contracts
{
    public interface IUserService
    {
        Task<bool> CreateUserAsync(CreateUserDto userDto);
    }
}
