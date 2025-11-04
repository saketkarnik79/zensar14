using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using API_DemoBasics.Models.Auth;

namespace API_DemoBasics.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRegistrationApiController: ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;

        public UserRegistrationApiController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser(UserRegistrationModel model)
        {
            if(model == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = new IdentityUser()
            {
                UserName = model.Email,
                Email = model.Email
            };
            var result =await _userManager.CreateAsync(user, model.Password!);
            if (result.Succeeded)
            {
                return Ok(new { Message = "User registered successfully!" });
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return BadRequest(ModelState);
            }
        }
    }
}