using Bank_Models.Models;
using Bank_Services.Interfaces;
using Bank_Services.Services;
using Database_Repository.DatabaseContext;
using Database_Repository.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bank.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomer _customer;
        public CustomerController(ICustomer customerService)
        {
            _customer = customerService;
        }
        [HttpPost("AddCustomer")]
        public Task<ServiceResponse<Customer>> AddCustomer(Customer customer)
        {
            return _customer.AddCustomer(customer);
        }
        [HttpPut("EditCustomer")]
        public Task<ServiceResponse<Customer>> EditCustomer(Customer customer)
        {
            return _customer.EditCustomer(customer);
        }
        [HttpDelete("{customerId}")]
        public Task<ServiceResponse<Customer>> DeleteCustomer(int customerId)
        {
            return _customer.DeleteCustomer(customerId);
        }
        [HttpGet("GetAllCustomers")]
        public Task<ServiceResponse<List<Customer>>> GetCustomers()
        {
            return _customer.GetCustomers();
        }
        [HttpGet("{customerId}")]
        public Task<ServiceResponse<Customer>> GetCustomer(int customerId)
        {
            return _customer.GetCustomer(customerId);
        }
    }
}
