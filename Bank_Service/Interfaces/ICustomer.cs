using Bank_Models.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bank_Services.Interfaces
{
    public interface ICustomer
    {
        Customer AddCustomer(Customer customer);
        ActionResult<Customer> EditCustomer(Customer customer);
        ActionResult<Customer> DeleteCustomer(int customerId);
        ICollection<Customer> GetCustomers();
        Customer GetCustomer(int customerId);
    }
}
