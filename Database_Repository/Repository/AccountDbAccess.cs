using Bank_Models.Models;
using Database_Repository.DatabaseContext;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Database_Repository.Repository
{
    public class AccountDbAccess
    {
        private readonly BankDbContext _bankDbContext;
        public AccountDbAccess(BankDbContext bankDbContext)
        {
            _bankDbContext = bankDbContext;
        }

        public Account AddAccount(Account account)
        {
            _bankDbContext.Accounts.Add(account);
            _bankDbContext.SaveChanges();
            return account;
        }
        public Account EditAccount(Account account)
        {
            var validate = _bankDbContext.Accounts.FirstOrDefault(x => x.AccountId == account.AccountId);
            if(validate != null)
            {
                validate.AccountId = account.AccountId;
                validate.AccountType = account.AccountType;

                _bankDbContext.Accounts.Update(validate);
                _bankDbContext.SaveChanges();
                return validate;
            }
            return null;
        }
        public Account GetAccount(int accountId)
        {
            var account = _bankDbContext.Accounts.FirstOrDefault(x => x.AccountId == accountId);
            if(account != null)
            {
                return account;
            }
            return null;
        }

        public ICollection<Account> GetAccounts()
        {
            var account = _bankDbContext.Accounts;
            if (account != null)
            {
                return account.ToList();
            }
            return null;
        }

        public Account DeleteAccount(int id)
        {
            var account = _bankDbContext.Accounts.FirstOrDefault(x => x.AccountId == id);
            if(account != null)
            {
                _bankDbContext.Accounts.Remove(account);
                _bankDbContext.SaveChanges();
                return account;
            }
            return null;
        }

    }
}
