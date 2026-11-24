using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDo.Application.Contracts;
using ToDo.Application.DTOs.Request;
using ToDo.Application.DTOs.Response;

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

        [HttpGet]
        public async Task<IEnumerable<UserResponseDto>> GetAll()
        {
            return await userService.GetAllUsersAsync();
        }


        [HttpGet("UserId")]
        public async Task<ActionResult<UserResponseDto>> GetById(Guid Id)
        {
            var user = await userService.GetUserByIdAsync(Id);
            return user is null ? NotFound() : user;
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid Id)
        {
            await userService.DeleteUserAsync(Id);

            return NoContent();
        }
    }
}
