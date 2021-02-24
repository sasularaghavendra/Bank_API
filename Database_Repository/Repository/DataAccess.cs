using Bank_Models.Models;
using Database_Repository.DatabaseContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Database_Repository.Repository
{
    public class DataAccess 
    {
        private readonly BankDbContext _bankDbContext;
        public DataAccess(BankDbContext bankDbContext)
        {
            _bankDbContext = bankDbContext;
        }

        public Customer AddCustomer(Customer customer)
        {
            _bankDbContext.Customers.Add(customer);
            _bankDbContext.SaveChanges();
            return customer;
        }
        public ActionResult<Customer> EditCustomer(Customer customer)
        {
            var validate = _bankDbContext.Customers.FirstOrDefault(x => x.CustomerId == customer.CustomerId);
            if (validate != null)
            {
                validate.AccountId = customer.AccountId;
                validate.FirstName = customer.FirstName;
                validate.LastName = customer.LastName;
                validate.Username = customer.Username;
                validate.Password = customer.Password;
                _bankDbContext.Customers.Update(validate);
                _bankDbContext.SaveChanges();
                return validate;
            }
            return null;
        }
        public Customer GetCustomer(int customerId)
        {
            var customer = _bankDbContext.Customers.Include(x => x.Account).FirstOrDefault(x => x.CustomerId == customerId);
            if (customer != null)
            {
                return customer;
            }
            return null;
        }

        public ICollection<Customer> GetCustomers()
        {
            var customer = _bankDbContext.Customers.Include(x => x.Account);
            if (customer != null)
            {
                return customer.ToList();
            }
            return null;
        }
        public ActionResult<Customer> DeleteCustomer(int id)
        {
            var customer = _bankDbContext.Customers.FirstOrDefault(x => x.CustomerId == id);
            if (customer != null)
            {
                _bankDbContext.Customers.Remove(customer);
                _bankDbContext.SaveChanges();
                return customer;
            }
            return null;
        }
    }
}
