using Bank_Models.Models;
using Database_Repository.DatabaseContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Results;
using Xero.Api.Core.Model;

namespace Database_Repository.Repository
{
    public class DataAccess 
    {
        private readonly BankDbContext _bankDbContext;
        private readonly ServiceResponse<Customer> serviceResponse = new ServiceResponse<Customer>();
        public DataAccess(BankDbContext bankDbContext)
        {
            _bankDbContext = bankDbContext;
        }
        public async Task<ServiceResponse<Customer>> AddCustomer(Customer customer)
        {
            customer.CustomerId = 0; //Identity value no need to pass
            await _bankDbContext.Customers.AddAsync(customer);
            await _bankDbContext.SaveChangesAsync();
            serviceResponse.Data = customer;
            serviceResponse.Message = $"Record added successfully...{customer.FullName}";
            return serviceResponse;    
        }
        public async Task<ServiceResponse<Customer>> EditCustomer(Customer customer)
        {
            var editCustomer = await _bankDbContext.Customers.FirstOrDefaultAsync(x => x.CustomerId == customer.CustomerId);
            if (editCustomer != null)
            {
                editCustomer.AccountId = customer.AccountId;
                editCustomer.FirstName = customer.FirstName;
                editCustomer.LastName = customer.LastName;
                editCustomer.Username = customer.Username;
                editCustomer.Password = customer.Password;
                _bankDbContext.Customers.Update(editCustomer);
                await _bankDbContext.SaveChangesAsync();

                serviceResponse.Message = $"Record Updated Successfully..{editCustomer.FullName}";
                serviceResponse.Data = editCustomer;
                return serviceResponse;
            }
            serviceResponse.Success = false;
            serviceResponse.Message = $"Record not found..{customer.FullName}";
            return serviceResponse;
        }
        public async Task<ServiceResponse<Customer>> GetCustomer(int customerId)
        {
            var customer = await _bankDbContext.Customers.Include(x => x.Account).FirstOrDefaultAsync(x => x.CustomerId == customerId);
            if (customer != null)
            {
                serviceResponse.Data = customer;
                return serviceResponse;
            }
            serviceResponse.Success = false;
            serviceResponse.Message = "Record not found.";
            return serviceResponse;
        }
        public async Task<ServiceResponse<List<Customer>>> GetCustomers()
        {
            ServiceResponse<List<Customer>> service = new ServiceResponse<List<Customer>>();
            var customer = await _bankDbContext.Customers.Include(x => x.Account).ToListAsync();
            if (customer != null)
            {
                service.Data = customer;
                return service;
            }
            service.Success = false;
            service.Message = "No records.";
            return service;
        }
        public async Task<ServiceResponse<Customer>> DeleteCustomer(int id)
        {
            var customer = await _bankDbContext.Customers.FirstOrDefaultAsync(x => x.CustomerId == id);
            if (customer != null)
            {
                _bankDbContext.Customers.Remove(customer);
                await _bankDbContext.SaveChangesAsync();
                serviceResponse.Data = customer;
                serviceResponse.Message = $"Record deleted successfully..{customer.FullName}";
                return serviceResponse;
            }
            serviceResponse.Success = false;
            serviceResponse.Message = "Record not found to delete.";
            return serviceResponse;
        }
    }
}
