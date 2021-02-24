using Bank_Models.Models;
using Database_Repository.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Database_Repository.Repository
{
    public class AuthenticationAccess
    {
        private readonly BankDbContext _bankDbContext;
        private readonly ServiceResponse<Customer> serviceResponse = new ServiceResponse<Customer>();
        public AuthenticationAccess(BankDbContext bankDbContext)
        {
            _bankDbContext = bankDbContext;
        }
        public async Task<ServiceResponse<Customer>> UserAuthentication(string userName, string password)
        {
            try
            {
                var authentication = await _bankDbContext.Customers.Include(x => x.Account)
                                                                   .FirstOrDefaultAsync(x => x.Username == userName && x.Password == password);
                if (authentication != null)
                {
                    serviceResponse.Data = authentication;
                    serviceResponse.Message = $"Welcome {authentication.FullName}.";
                    return serviceResponse;
                }
                else
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Please enter valid credentials.";
                    return serviceResponse;
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
                return serviceResponse;
            }
        }
    }
}
