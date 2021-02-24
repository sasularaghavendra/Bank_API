using Bank_Models.Models;
using Bank_Services.Interfaces;
using Database_Repository.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Services.Services
{
    public class CustomerService : ICustomer
    {
        private readonly DataAccess _dataAccess;
        public CustomerService(DataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        public async Task<ServiceResponse<Customer>> AddCustomer(Customer customer)
        {
            return await _dataAccess.AddCustomer(customer);
        }
        public async Task<ServiceResponse<Customer>> EditCustomer(Customer customer)
        {
            return await _dataAccess.EditCustomer(customer);
        }
        public async Task<ServiceResponse<Customer>> DeleteCustomer(int customerId)
        {
            return await _dataAccess.DeleteCustomer(customerId);
        }
        public async Task<ServiceResponse<Customer>> GetCustomer(int customerId)
        {
            return await _dataAccess.GetCustomer(customerId);
        }
        public async  Task<ServiceResponse<List<Customer>>> GetCustomers()
        {
            return await _dataAccess.GetCustomers();
        }
    }
}
