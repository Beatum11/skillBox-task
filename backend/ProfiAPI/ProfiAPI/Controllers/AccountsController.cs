using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProfiAPI.Data.Models;

namespace ProfiAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        #region Basic Set-Up

        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountsController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        #endregion

        #region SignUp Method

        [HttpPost("signup")]
        public async Task<IActionResult> SigningUp(SignUpUser signUpUser)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser()
                {
                    UserName = signUpUser.UserName,
                    Email = signUpUser.Email,
                };

                var result = await _userManager.CreateAsync(user, signUpUser.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return Ok(new { id = user.Id, email = user.Email, name = user.UserName });
                }
                else
                {
                    //This retrieves a collection of errors that occurred
                    //during the user creation process.
                    //It is provided by the CreateAsync method of the UserManager class.
                    var error = result.Errors.Select(e => e.Description).FirstOrDefault();
                    return BadRequest(error);
                }
            }

            return BadRequest(ModelState);
        }

        #endregion

        #region SignIn Method

        [HttpPost("signin")]
        public async Task<IActionResult> SigningIn(SignInUser signInUser)
        {
            var user = await _userManager.FindByEmailAsync(signInUser.Email);

            if (user != null)
            {
                var res = await _signInManager.PasswordSignInAsync(user, signInUser.Password, signInUser.RememberMe, false);

                if (res.Succeeded)
                {
                    return Ok(new { id = user.Id, email = user.Email, name = user.UserName });
                }

            }

           return BadRequest();
           
        }

        #endregion

        #region SignOut Method

        [HttpPost("signout")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SigningOut()
        {
            await _signInManager.SignOutAsync();
            return Ok();
        }

        #endregion

    }
}
