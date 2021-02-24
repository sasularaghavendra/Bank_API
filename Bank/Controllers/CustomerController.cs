using Bank_Models.Models;
using Bank_Services.Services;
using Database_Repository.DatabaseContext;
using Database_Repository.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerService _customerService;
        public CustomerController(CustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpPost("AddCustomer")]
        public Task<ServiceResponse<Customer>> AddCustomer(Customer customer)
        {
            return _customerService.AddCustomer(customer);
        }
        [HttpPut("EditCustomer")]
        public Task<ServiceResponse<Customer>> EditCustomer(Customer customer)
        {
            return _customerService.EditCustomer(customer);
        }
        [HttpDelete("{customerId}")]
        public Task<ServiceResponse<Customer>> DeleteCustomer(int customerId)
        {
            return _customerService.DeleteCustomer(customerId);
        }
        [HttpGet("GetAllCustomers")]
        public Task<ServiceResponse<List<Customer>>> GetCustomers()
        {
            return _customerService.GetCustomers();
        }
        [HttpGet("{customerId}")]
        public Task<ServiceResponse<Customer>> GetCustomer(int customerId)
        {
            return  _customerService.GetCustomer(customerId);
        }
    }
}
