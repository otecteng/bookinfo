using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Text.Encodings.Web;
using System.Security.Claims;
using StackExchange.Redis;
namespace productpage
{
    public class BasicAuthenticationOptions : AuthenticationSchemeOptions
    {

    }
    public class CustomAuthenticationHandler : AuthenticationHandler<BasicAuthenticationOptions>
    {
        private readonly ICustomAuthenticationManager customAuthenticationManager;
        private readonly IDatabase database;
        public CustomAuthenticationHandler(IOptionsMonitor<BasicAuthenticationOptions> options,
        ILoggerFactory logger,
        UrlEncoder encoder,
        ISystemClock clock,
        ICustomAuthenticationManager customAuthenticationManager,
        IDatabase database) : base (options,logger,encoder,clock)
        {
            this.customAuthenticationManager = customAuthenticationManager;
            this.database = database;
        }
        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if(!Request.Headers.ContainsKey("Authorization"))
                return AuthenticateResult.Fail("Unauthorized");
            string authorizationHeader = Request.Headers["Authorization"];
            if(string.IsNullOrEmpty(authorizationHeader))
                return AuthenticateResult.Fail("Unauthorize");
            if(!authorizationHeader.StartsWith("bearer",StringComparison.OrdinalIgnoreCase))
                return AuthenticateResult.Fail("Unauthorize");

            string token = authorizationHeader.Substring("bearer".Length).Trim();
            if(string.IsNullOrEmpty(token))
                return AuthenticateResult.Fail("Unauthorize");
            try
            {
                return ValidateToken(token);
            }
            catch(Exception ex)
            {
                return AuthenticateResult.Fail(ex.Message);
            }
        }

        private AuthenticateResult ValidateToken(string token)
        {
            

            // var validatedToken =  customAuthenticationManager.Tokens.FirstOrDefault(t => t.Key == token);
            // if (validatedToken.Key == null)
            // {
            //     return AuthenticateResult.Fail("Unauthorize");
            // }
            string username = database.StringGet(token);
            if(string.IsNullOrEmpty(username))
            {
                return AuthenticateResult.Fail("Unauthorize");
            }

            //鉴权通过
            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, username),
                };
 
            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new System.Security.Principal.GenericPrincipal(identity, null);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);
            return AuthenticateResult.Success(ticket);
        }
    }
}