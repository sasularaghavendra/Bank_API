using Bank_Models.Models;
using Database_Repository.DatabaseContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database_Repository.Repository
{
    public class AccountDbAccess
    {
        private readonly BankDbContext _bankDbContext;
        private readonly ServiceResponse<Account> serviceResponse = new ServiceResponse<Account>();
        public AccountDbAccess(BankDbContext bankDbContext)
        {
            _bankDbContext = bankDbContext;
        }
        public async Task<ServiceResponse<Account>> AddAccount(Account account)
        {
            try
            {
                account.AccountId = 0; // Identity value no need to pass
                await _bankDbContext.Accounts.AddAsync(account);
                await _bankDbContext.SaveChangesAsync();
                serviceResponse.Data = account;
                serviceResponse.Message = $"Record added successfully...{account.AccountType}";
                return serviceResponse;
            }
            catch(Exception e)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = e.Message;
                return serviceResponse;
            }
        }
        public async Task<ServiceResponse<Account>> EditAccount(Account account)
        {
            try
            {
                var editAccount = await _bankDbContext.Accounts.FirstOrDefaultAsync(x => x.AccountId == account.AccountId);
                if (editAccount != null)
                {
                    editAccount.AccountType = account.AccountType;
                    _bankDbContext.Accounts.Update(editAccount);
                    await _bankDbContext.SaveChangesAsync();
                    serviceResponse.Data = editAccount;
                    serviceResponse.Message = "Record Updated Successfully..";
                    return serviceResponse;
                }
                serviceResponse.Success = false;
                serviceResponse.Message = "Record not found.";
                return serviceResponse;
            }
            catch(Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
                return serviceResponse;
            }
        }
        public async Task<ServiceResponse<Account>> GetAccount(int accountId)
        {
            try
            {
                var account = await _bankDbContext.Accounts.FirstOrDefaultAsync(x => x.AccountId == accountId);
                if(account != null)
                {
                    serviceResponse.Data = account;
                    return serviceResponse;
                }
                serviceResponse.Success = false;
                serviceResponse.Message = "Record not found.";
                return serviceResponse;
            }
            catch(Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
                return serviceResponse;
            }
        }
        public async Task<ServiceResponse<List<Account>>> GetAccounts()
        {
            ServiceResponse<List<Account>> service = new ServiceResponse<List<Account>>();
            try
            {
                var account = await _bankDbContext.Accounts.ToListAsync();
                if (account != null)
                {
                    service.Data = account;
                    return service;
                }
                service.Success = false;
                service.Message = "No records available.";
                return service;
            }
            catch(Exception ex)
            {
                service.Success = false;
                service.Message = ex.Message;
                return service;
            }
        }
        public async Task<ServiceResponse<Account>> DeleteAccount(int id)
        {
            try
            {
                var account = await _bankDbContext.Accounts.FirstOrDefaultAsync(x => x.AccountId == id);
                if (account != null)
                {
                    _bankDbContext.Accounts.Remove(account);
                    await _bankDbContext.SaveChangesAsync();
                    serviceResponse.Data = account;
                    return serviceResponse;
                }
                serviceResponse.Success = false;
                serviceResponse.Message = $"AccountId {id} not found to delete.";
                return serviceResponse;
            }
            catch(Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
                return serviceResponse;
            }
        }
    }
}
