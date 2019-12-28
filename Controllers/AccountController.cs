using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using System;
using System.Linq;
using WebAppAPI.Models;

namespace WebAppAPI.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ProjectContext _context;
        public AccountController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, ProjectContext context)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _context = context;
        }
        [Route("log-microsoft")]
        public IActionResult SignInWithMicrosoft()
        {
            var authenticationProperties = _signInManager.ConfigureExternalAuthenticationProperties("MicrosoftAccount", Url.Action(nameof(HandleExternalLogin)));
            return Challenge(authenticationProperties, "MicrosoftAccount");
        }

        [Route("log-google")]
        public IActionResult SignInWithGoogle()
        {
            var authenticationProperties = _signInManager.ConfigureExternalAuthenticationProperties("Google", Url.Action(nameof(HandleExternalLogin)));
            return Challenge(authenticationProperties, "Google");
        }

        public async Task<IActionResult> HandleExternalLogin()
        {
            var info = await _signInManager.GetExternalLoginInfoAsync();
            var result = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false);

            if (!result.Succeeded) //user does not exist yet
            {
                //if(_context.Users.Where(u => u.UserName == reg.UserName).Any())

                var email = info.Principal.FindFirstValue(ClaimTypes.Email);


                var newUser = new IdentityUser
                {
                    UserName = email,
                    Email = email,
                    EmailConfirmed = true
                };
                var createResult = await _userManager.CreateAsync(newUser);

                if (!createResult.Succeeded)
                    throw new Exception(createResult.Errors.Select(e => e.Description).Aggregate((errors, error) => $"{errors}, {error}"));

                await _userManager.AddLoginAsync(newUser, info);
                var newUserClaims = info.Principal.Claims.Append(new Claim("userId", newUser.Id));
                await _userManager.AddClaimsAsync(newUser, newUserClaims);
                await _signInManager.SignInAsync(newUser, isPersistent: false);

                if(newUser.Email == "iron.side.w3@gmail.com" || newUser.Email == "242433@student.pwr.edu.pl")
                {
                    await _userManager.AddToRolesAsync(newUser, new string[] { "Admin"});
                }

                await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);
            }
            return Redirect("http://localhost:4200");
        }
        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Redirect("http://localhost:4200");
        }

        [Route("logout-google")]
        public async Task<IActionResult> LogoutGoogle()
        {
            await _signInManager.SignOutAsync();
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);
            return Redirect("https://www.google.com/accounts/Logout?continue=https://appengine.google.com/_ah/logout?continue=http://localhost:4200");
            //return Redirect("https://webappapi20191226093851.azurewebsites.net/");
        }

        /*[Route("isAuthenticated")]
        public IActionResult IsAuthenticated()
        {
            return new ObjectResult(User.Identity.IsAuthenticated);
        }*/

        /*[Route("")]
        public IActionResult Index()
        {
            return Content("Running...");
        }*/

        /*public static async Task<IdentityResult> AssignRoles(IServiceProvider services, string email, string[] roles)
        {
            UserManager<IdentityUser> _userManager = services.GetService<UserManager<IdentityUser>>();
            IdentityUser user = await _userManager.FindByEmailAsync(email);
            var result = await _userManager.AddToRolesAsync(user, roles);
            return result;
        }*/
    }
}
