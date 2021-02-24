using Bank_Models.Models;
using Bank_Services.Interfaces;
using Database_Repository.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Services.Services
{
    public class AuthenticationService : IAuthentication
    {
        private readonly AuthenticationAccess _authenticationAccess;
        public AuthenticationService(AuthenticationAccess authenticationAccess)
        {
            _authenticationAccess = authenticationAccess;
        }
        public async Task<ServiceResponse<Customer>> UserAuthentication(string userName, string password)
        {
            return await _authenticationAccess.UserAuthentication(userName,password);
        }
    }
}
