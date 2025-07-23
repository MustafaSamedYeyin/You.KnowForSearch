using Core.Entities.Auth;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using UserSpace;

namespace API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IUserService _userService;

        public AuthController(IAuthService authService, IUserService userService)
        {
            _authService = authService;
            _userService = userService;
        }

        [HttpPost()]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            try
            {
                var token = await _authService.GenerateTokenAsync(model.Email, model.Password);
                return Ok(new { Token = token });
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost()]
        public async Task<IActionResult> Register(User model)
        {
            return Ok(await _userService.AddAsync(model));
        }

        [HttpPost()]
        public async Task<IActionResult> ValidateToken(ValidateTokenModel model)
        {
            return Ok(await _authService.ValidateToken(model.Token));
        }
    }
}