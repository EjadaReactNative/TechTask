using Microsoft.AspNetCore.Mvc;
using TechnicalTask.Services;
using TechnicalTask.Models;
namespace TechnicalTask.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
      

        public UserController(IUserService userService) => _userService = userService;

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserRequest request)
        {
            if (await _userService.IsPhoneRegisteredAsync(request.PhoneNumber))
            {
                return BadRequest(new { Error = "Phone number already registered." });
            }
            var user = await _userService.RegisterUserAsync(request.FullName, request.PhoneNumber, request.Email);
            return Ok(user);
        }
    }
}
