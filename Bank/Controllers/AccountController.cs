using Bank_Models.Models;
using Bank_Services.Interfaces;
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
        private readonly IAccount _account;
        public AccountController(IAccount account)
        {
            _account = account;
        }

        [HttpPost("AddAccountDetails")]
        public async Task<ServiceResponse<Account>> AddAccount(Account account)
        {
            return await _account.AddAccount(account);
        }
        [HttpPut("EditAccountDetails")]
        public async Task<ServiceResponse<Account>> EditAccount(Account account)
        {
            return await _account.EditAccount(account);
        }
        [HttpGet("GetAllAccountDetails")]
        public async Task<ServiceResponse<List<Account>>> GetAllAccounts()
        {
            return await _account.GetAccounts();
        }
        [HttpGet("{id}")]
        public async Task<ServiceResponse<Account>> GetAllAccount(int id)
        {
            return await _account.GetAccount(id);
        }
        [HttpDelete("{id}")]
        public async Task<ServiceResponse<Account>> DeleteAccount(int id)
        {
            return await _account.DeleteAccount(id);
        }
    }
}
