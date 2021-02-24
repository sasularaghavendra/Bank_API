using Bank_Models.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bank_Services.Interfaces
{
    public interface IAccount
    {
        ActionResult<Account> AddAccount(Account account);
        ActionResult<Account> EditAccount(Account account);
        ActionResult<Account> DeleteAccount(int accountId);
        ICollection<Account> GetAccounts();
        Account GetAccount(int accountId);
    }
}
