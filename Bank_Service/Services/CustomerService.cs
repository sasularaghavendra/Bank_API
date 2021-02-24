using Bank_Models.Models;
using Bank_Services.Interfaces;
using Database_Repository.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bank_Services.Services
{
    public class CustomerService : ICustomer
    {
        private readonly DataAccess _dataAccess;
        public CustomerService(DataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        public Customer AddCustomer(Customer customer)
        {
            if(customer != null)
            {
                Customer cust = _dataAccess.AddCustomer(customer);
                return cust;
            }
            return null;
        }
        public ActionResult<Customer> EditCustomer(Customer customer)
        {
            var cust = _dataAccess.EditCustomer(customer);
            if (cust != null)
            {
                return cust;
            }
            return null;
        }
        public ActionResult<Customer> DeleteCustomer(int customerId)
        {
            var customer = _dataAccess.DeleteCustomer(customerId);
            if (customer != null)
            {
                return customer;
            }
            return null;
        }
        public Customer GetCustomer(int customerId)
        {
            var customer = _dataAccess.GetCustomer(customerId);
            if (customer != null)
            {
                return customer;
            }
            return null;
        }
        public ICollection<Customer> GetCustomers()
        {
            var accounts = _dataAccess.GetCustomers();
            if (accounts != null)
            {
                return accounts;
            }
            return null;
        }
    }
}
