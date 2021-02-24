using Bank_Models.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Services.Interfaces
{
    public interface IAccount
    {
        Task<ServiceResponse<Account>> AddAccount(Account account);
        Task<ServiceResponse<Account>> EditAccount(Account account);
        Task<ServiceResponse<Account>> DeleteAccount(int accountId);
        Task<ServiceResponse<List<Account>>> GetAccounts();
        Task<ServiceResponse<Account>> GetAccount(int accountId);
    }
}
