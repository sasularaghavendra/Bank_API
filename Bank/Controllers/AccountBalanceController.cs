using Bank_Models.Models;
using Bank_Services.Services;
using Microsoft.AspNetCore.Http;
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
        private readonly AccountBalanceService _accontBalanceService;
        public AccountBalanceController(AccountBalanceService accountBalanceService)
        {
            _accontBalanceService = accountBalanceService;
        }
        [HttpPost("AddAmount")]
        public async Task<ActionResult<AccountBalance>> AddAmount(AccountBalance accountBalance)
        {
            return await _accontBalanceService.AddAmount(accountBalance);
        }

        [HttpPut("DepositAmount")]
        public async Task<ActionResult<AccountBalance>> DepositAmount(AccountBalance accountBalance)
        {
            var accountDetails = await _accontBalanceService.DepositAccountBalance(accountBalance);

            if (accountDetails != null)
            {
                return accountDetails;
            }
            else
            {
                return Ok("Error Occured..");
            }
        }
        [HttpPut("WithdrawAmount")]
        public async Task<ActionResult<AccountBalance>> WithdrawAmount(AccountBalance accountBalance)
        {
            var accountDetails = await _accontBalanceService.WithdrawAccountBalance(accountBalance);

            if (accountDetails != null)
            {
                return accountDetails;
            }
            else
            {
                return Ok("Error Occured..");
            }
        }
    }
}
