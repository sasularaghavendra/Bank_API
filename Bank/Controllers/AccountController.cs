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
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly AccountService _accountService;
        public AccountController(AccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("AddAccountDetails")]
        public async Task<ServiceResponse<Account>> AddAccount(Account account)
        {
            return await _accountService.AddAccount(account);
        }
        [HttpPut("EditAccountDetails")]
        public async Task<ServiceResponse<Account>> EditAccount(Account account)
        {
            return await _accountService.EditAccount(account);
        }
        [HttpGet("GetAllAccountDetails")]
        public async Task<ServiceResponse<List<Account>>> GetAllAccounts()
        {
            return await _accountService.GetAccounts();
        }
        [HttpGet("{id}")]
        public async Task<ServiceResponse<Account>> GetAllAccount(int id)
        {
            return await _accountService.GetAccount(id);
        }
        [HttpDelete("{id}")]
        public async Task<ServiceResponse<Account>> DeleteAccount(int id)
        {
            return await _accountService.DeleteAccount(id);
        }
    }
}
