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
        public ActionResult<Customer> AddCustomer(Customer customer)
        {
            var customerDetails = _customerService.AddCustomer(customer);

            if(customerDetails != null)
            {
                return customerDetails;
            }
            else
            {
                return Ok("Error Occured..");
            }
        }
        [HttpPut("EditCustomer")]
        public ActionResult<Customer> EditCustomer(Customer customer)
        {
            var customerDetails = _customerService.EditCustomer(customer);

            if(customerDetails != null)
            {
                return customerDetails;
            }
            else
            {
                return Ok("Error occured..");
            }
        }
        [HttpDelete("{customerId}, Name = DeleteCustomer")]
        public ActionResult<Customer> DeleteCustomer(int customerId)
        {
            var customerDetails = _customerService.DeleteCustomer(customerId);

            if(customerDetails != null)
            {
                return customerDetails;
            }
            else
            {
                return Ok("Error Occured..");
            }
        }
        [HttpGet("GetAllCustomers")]
        public ICollection<Customer> GetCustomers()
        {
            var customer = _customerService.GetCustomers();
            if(customer != null)
            {
                return customer.ToList();
            }
            return null;
        }
        [HttpGet("{customerId}, Name = GetCustomer")]
        public Customer GetCustomer(int customerId)
        {
            var customer = _customerService.GetCustomer(customerId);
            if (customer != null)
            {
                return customer;
            }
            return null;
        }

    }
}
