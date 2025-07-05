using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using TechnicalTask.Services;
using TechnicalTask.Models;

namespace TechnicalTask.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IAuthService _authService;
       

        public AuthController(IUserService userService, IAuthService authService)
        {
            _userService = userService;
            _authService = authService;
        }

        [HttpPost("initiate-login")]
        public async Task<IActionResult> InitiateLogin(Models.LoginRequest request)
        {
            var isRegistered = await _userService.IsPhoneRegisteredAsync(request.PhoneNumber);
            if (!isRegistered)
                return BadRequest(new { Error = "Phone number not registered." });

            var otp = _authService.GenerateOTP(6);
            _authService.StoreOTP(request.PhoneNumber, otp);

            // Return OTP in response for testing purposes (no SMS)
            return Ok(new { Message = "OTP sent successfully.", OTP = otp });
        }

        [HttpPost("verify-otp")]
        public IActionResult VerifyOtp(VerifyOtpRequest request)
        {
            var valid = _authService.ValidateOTP(request.PhoneNumber, request.Otp);
            if (!valid)
                return BadRequest(new { Error = "Invalid or expired OTP." });

            var token = _authService.GenerateFakeJwtToken(request.PhoneNumber);
            return Ok(new LoginResponse(token));
        }
    }
}
