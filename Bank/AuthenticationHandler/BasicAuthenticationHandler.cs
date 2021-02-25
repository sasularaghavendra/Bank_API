using Bank_Models.Models;
using Bank_Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace Bank.AuthenticationHandler
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        //private readonly Bank_Services.Services.AuthenticationService _authenticationService;
        private readonly IAuthentication _authentication;
        public static ServiceResponse<Customer> captureUserData = new ServiceResponse<Customer>();
        public BasicAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            //Bank_Services.Services.AuthenticationService authenticationService
            IAuthentication authentication
            ) : base(options, logger, encoder, clock)
        {
            _authentication = authentication;
        }
        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
                return AuthenticateResult.Fail("Authorization Header was not found");

            try
            {
                var authenticationHeaderValue = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                var bytes = Convert.FromBase64String(authenticationHeaderValue.Parameter);
                string[] credentials = Encoding.UTF8.GetString(bytes).Split(":");
                string userName = credentials[0];
                string password = credentials[1];

                ServiceResponse<Customer> serviceResponse = await _authentication.UserAuthentication(userName, password);
                captureUserData = serviceResponse;
                if (serviceResponse.Data == null)
                    AuthenticateResult.Fail("Invalid Username or Password");
                else
                {
                    var claims = new[] { new Claim(ClaimTypes.Name, serviceResponse.Data.Username,serviceResponse.Data.Password)};
                    var identity = new ClaimsIdentity(claims,Scheme.Name);
                    var principal = new ClaimsPrincipal(identity);
                    var ticket = new AuthenticationTicket(principal, Scheme.Name);
                    return AuthenticateResult.Success(ticket);
                }
            }
            catch (Exception ex)
            {
                return AuthenticateResult.Fail(ex.Message);
            }
            return AuthenticateResult.Fail("Authentication failed");

        }
    }
}
