using AuthZFlowMVC.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AuthZFlowMVC.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login(string? nereyeGidecek)
        {
            ViewBag.ReturnUrl = nereyeGidecek;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login([Bind("Name", "Password")] UserLoginModel userLoginModel, string? nereyeGidecek)
        {
            if (ModelState.IsValid)
            {
                var user = new UserService().ValidateUser(userLoginModel.Name, userLoginModel.Password);
                if (user != null)
                {
                    var claims = new Claim[]
                    {
                        new Claim(ClaimTypes.Name, user.Name),
                        new Claim(ClaimTypes.Role, user.Role),

                    };
                    ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                    await HttpContext.SignInAsync(claimsPrincipal);
                    if (!string.IsNullOrEmpty(nereyeGidecek) && Url.IsLocalUrl(nereyeGidecek))
                    {
                        return Redirect(nereyeGidecek);
                    }
                    return Redirect("/");
                }
                ModelState.AddModelError("login", "Hatalı kullanıcı adı veya şifre");
            }
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
