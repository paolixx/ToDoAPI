using System;
using System.Collections.Generic;
using System.Text;

namespace ToDo.Application.DTOs.Request
{
    public record CreateUserDto(string Email, string FullName, string Password);
}
