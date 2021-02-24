using Bank_Models.Models;
using Bank_Services.Interfaces;
using Database_Repository.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bank_Services.Services
{
    public class AccountService : IAccount
    {
        private readonly AccountDbAccess _dataAccess;
        public AccountService(AccountDbAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        public ActionResult<Account> AddAccount(Account account)
        {
            var acc = _dataAccess.AddAccount(account);
            if(acc != null)
            {
                return acc;
            }
            return null;
        }
        public ActionResult<Account> EditAccount(Account account)
        {
            var acc = _dataAccess.EditAccount(account);
            if(acc != null)
            {
                return acc;
            }
            return null;
        }
        public ActionResult<Account> DeleteAccount(int accountId)
        {
            var accounts = _dataAccess.DeleteAccount(accountId);
            if(accounts != null)
            {
                return accounts;
            }
            return null;
        }
        public Account GetAccount(int accountId)
        {
            var accounts = _dataAccess.GetAccount(accountId);
            if (accounts != null)
            {
                return accounts;
            }
            return null;
        }

        public ICollection<Account> GetAccounts()
        {
            var accounts = _dataAccess.GetAccounts();
            if(accounts != null)
            {
                return accounts;
            }
            return null;
        }


    }
}
