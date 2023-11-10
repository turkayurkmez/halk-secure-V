using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JWTAuthWithREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly UserService userService;

        public AccountsController(UserService userService)
        {
            this.userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }
        [HttpPost]
        public IActionResult Login(UserLoginInfo userLoginInfo)
        {
            if (ModelState.IsValid)
            {
                var user = userService.ValidateUser(userLoginInfo.Email, userLoginInfo.Password);
                if (user != null)
                {
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("bu-cümle-jwt-için-çok-gizli"));
                    var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Email, user.Email),
                        new Claim(ClaimTypes.Role,user.Role)
                    };
                    var token = new JwtSecurityToken(
                          issuer: "server",
                          audience: "client",
                          claims: claims,
                          notBefore: DateTime.Now,
                          expires: DateTime.Now.AddDays(1),
                          signingCredentials: credential

                          );

                    return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });

                }

                ModelState.AddModelError("login", "Hatalı kullanıcı adı veya şifre");
            }

            return BadRequest(ModelState);
        }
    }
}
