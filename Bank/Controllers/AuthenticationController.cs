using Bank.AuthenticationHandler;
using Bank_Models.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Bank.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class AuthenticationController : ControllerBase
    {
        [HttpGet]
        public ServiceResponse<Customer> UserAuthentication()
        {
            return BasicAuthenticationHandler.captureUserData;   
        }
    }
}
