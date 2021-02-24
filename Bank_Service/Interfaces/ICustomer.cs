using Bank_Models.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Services.Interfaces
{
    public interface ICustomer
    {    
        Task<ServiceResponse<Customer>> AddCustomer(Customer customer);
        Task<ServiceResponse<Customer>> EditCustomer(Customer customer);
        Task<ServiceResponse<Customer>> DeleteCustomer(int customerId);
        Task<ServiceResponse<List<Customer>>> GetCustomers();
        Task<ServiceResponse<Customer>> GetCustomer(int customerId);
    }
}
