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
    public class AccountService : IAccount
    {
        private readonly AccountDbAccess _dataAccess;
        public AccountService(AccountDbAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        public async Task<ServiceResponse<Account>> AddAccount(Account account)
        {
            return await _dataAccess.AddAccount(account);
        }
        public async Task<ServiceResponse<Account>> EditAccount(Account account)
        {
            return await _dataAccess.EditAccount(account);
        }
        public async Task<ServiceResponse<Account>> DeleteAccount(int accountId)
        {
            return await _dataAccess.DeleteAccount(accountId);
        }
        public async Task<ServiceResponse<Account>> GetAccount(int accountId)
        {
            return await _dataAccess.GetAccount(accountId);
        }
        public async Task<ServiceResponse<List<Account>>> GetAccounts()
        {
            return await _dataAccess.GetAccounts();
        }
    }
}
