using Bank_Models.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Services.Interfaces
{
    public interface IAuthentication
    {
        Task<ServiceResponse<Customer>> UserAuthentication(string userName, string password);
    }
}
