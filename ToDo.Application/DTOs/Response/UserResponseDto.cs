using System;
using System.Collections.Generic;
using System.Text;

namespace ToDo.Application.DTOs.Response
{
    public class UserResponseDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; } 
        public string Email { get; set; }
    }
}
