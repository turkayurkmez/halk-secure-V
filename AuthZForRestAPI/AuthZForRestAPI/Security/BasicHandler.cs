using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;

namespace AuthZForRestAPI.Security
{
    public class BasicHandler : AuthenticationHandler<BasicOptions>
    {
        public BasicHandler(IOptionsMonitor<BasicOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) : base(options, logger, encoder, clock)
        {
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            //1. Gelen istekte Authorization bilgisi var mı?
            if (!Request.Headers.ContainsKey("Authorization"))
            {
                return Task.FromResult(AuthenticateResult.NoResult());
            }

            //2. istekteki Authorization formatı doğru mu?
            if (!AuthenticationHeaderValue.TryParse(Request.Headers["Authorization"], out AuthenticationHeaderValue headerValue))
            {
                return Task.FromResult(AuthenticateResult.NoResult());

            }
            //3. Gelen istekteki authorization Basic mi?
            if (!headerValue.Scheme.Equals("Basic", StringComparison.OrdinalIgnoreCase))
            {
                return Task.FromResult(AuthenticateResult.NoResult());

            }

            byte[] value = Convert.FromBase64String(headerValue.Parameter);
            string userNameAndPass = Encoding.UTF8.GetString(value);

            var userName = userNameAndPass.Split(':')[0];
            var pass = userNameAndPass.Split(':')[1];

            if (userName == "turkay" && pass == "123")
            {
                var claims = new Claim[]{
                    new Claim(ClaimTypes.Name, userName)
                };

                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, Scheme.Name);
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                AuthenticationTicket ticket = new AuthenticationTicket(claimsPrincipal, Scheme.Name);

                return Task.FromResult(AuthenticateResult.Success(ticket));
            }

            return Task.FromResult(AuthenticateResult.Fail("Hatalı giriş"));

        }


    }
}
