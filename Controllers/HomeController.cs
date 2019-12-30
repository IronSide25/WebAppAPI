using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace WebAppAPI.Controllers
{
    [ApiController]
    public class HomeController : Controller
    {
        //[Authorize]
        [Route("")]
        public IActionResult Index()
        {
            return Content("Running...");
        }


        [Route("isAuthenticated")]
        public IActionResult IsAuthenticated()
        {
            return new ObjectResult(User.Identity.IsAuthenticated);
            //return new ObjectResult(User?.Identity.IsAuthenticated ?? false);
        }

        [Route("api/home/fail")]
        public IActionResult Fail()
        {
            return Unauthorized();
        }

        [Route("api/home/name")]
        [Authorize]
        public IActionResult Name()
        {
            var claimsPrincial = (ClaimsPrincipal)User;
            var givenName = claimsPrincial.FindFirst(ClaimTypes.GivenName).Value;
            return Ok(givenName);
        }

        [Route("/home/[action]")]
        public IActionResult Denied()
        {
            return Content("You need to allow this application access in Google order to be able to login");
        }
    }
}
