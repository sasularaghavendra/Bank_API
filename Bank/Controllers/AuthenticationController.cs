using Bank_Models.Models;
using Bank_Services.Services;
using Database_Repository.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class AuthenticationController : ControllerBase
    {
        private readonly ServiceResponse<Customer> serviceResponse = new ServiceResponse<Customer>();
        private readonly Bank_Services.Services.AuthenticationService _authenticationService;
        public AuthenticationController(Bank_Services.Services.AuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        [HttpGet]
        public async Task<ServiceResponse<Customer>> UserAuthentication()
        {
            var pwd = HttpContext.User.Claims.ToList();
            var userName = pwd[0].Value;
            var password = pwd[0].ValueType;
            var userData = await _authenticationService.UserAuthentication(userName, password);
            return userData; 
        }
    }
}
