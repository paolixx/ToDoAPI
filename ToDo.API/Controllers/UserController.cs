using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDo.Application.Contracts;
using ToDo.Application.DTOs.Request;

namespace ToDo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserService userService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateUserDto request)
        {
            var response = await userService.CreateUserAsync(request);

            return Created(); // 201
        }
    }
}
