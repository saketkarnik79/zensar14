using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API_DemoBasics.Models.Auth;
using API_DemoBasics.Services;
using Microsoft.AspNetCore.Identity;

namespace API_DemoBasics.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginApiController : ControllerBase
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly JwtIssuanceService _jwtIssuanceService;

        public LoginApiController(SignInManager<IdentityUser> signInManager, JwtIssuanceService jwtIssuanceService)
        {
            _signInManager = signInManager;
            _jwtIssuanceService = jwtIssuanceService;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (loginModel == null || string.IsNullOrEmpty(loginModel.Email) || string.IsNullOrEmpty(loginModel.Password))
            {
                return BadRequest("Invalid login request.");
            }
            var result = await _signInManager.PasswordSignInAsync(loginModel.Email, loginModel.Password, false, false);
            if (result.Succeeded)
            {
                //var user = await _signInManager.UserManager.FindByEmailAsync(loginModel.Email);
                List<string> roles = new List<string>()
                {
                    "Power Users"
                };
                var token = _jwtIssuanceService.GenerateToken(loginModel.Email!, roles);
                return Ok(new { Message = "Login successful!", Token = token });
            }
            else
            {
                return Unauthorized("Invalid email or password!");
            }
        }
    }
}
