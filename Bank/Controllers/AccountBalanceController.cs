using Bank_Models.Models;
using Bank_Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountBalanceController : ControllerBase
    {
        private readonly IAccountBalance _accontBalance;
        public AccountBalanceController(IAccountBalance accountBalance)
        {
            _accontBalance = accountBalance;
        }
        [HttpPost("AddAmount")]
        public async Task<ServiceResponse<AccountBalance>> AddAmount(AccountBalance accountBalance)
        {
            return await _accontBalance.AddAmount(accountBalance);
        }

        [HttpPut("DepositAmount")]
        public async Task<ServiceResponse<AccountBalance>> DepositAmount(AccountBalance accountBalance)
        {
            return await _accontBalance.DepositAccountBalance(accountBalance);
        }
        [HttpPut("WithdrawAmount")]
        public async Task<ServiceResponse<AccountBalance>> WithdrawAmount(AccountBalance accountBalance)
        {
            return await _accontBalance.WithdrawAccountBalance(accountBalance);
        }
    }
}
