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
    public class AccountBalanceService : IAccountBalance
    {
        private readonly AccountBalanceAccess _accountBalanceAccess;
        public AccountBalanceService(AccountBalanceAccess accountBalanceAccess)
        {
            _accountBalanceAccess = accountBalanceAccess;
        }
        public async Task<ActionResult<AccountBalance>> AddAmount(AccountBalance accountBalance)
        {
            return await _accountBalanceAccess.AddAmount(accountBalance);
        }
        public async Task<ActionResult<AccountBalance>> DepositAccountBalance(AccountBalance accountBalance)
        {
            return await _accountBalanceAccess.DepositAccountBalance(accountBalance);
        }
        public async Task<ActionResult<AccountBalance>> WithdrawAccountBalance(AccountBalance accountBalance)
        {
            return await _accountBalanceAccess.WithdrawAccountBalance(accountBalance);
        }
    }
}
