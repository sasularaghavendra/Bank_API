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
        public ActionResult<Account> AddAccount(Account account)
        {
            var acc = _accountService.AddAccount(account);
            if(acc != null)
            {
                return acc;
            }
            return Ok("Error Occured");
        }
        [HttpPut("EditAccountDetails")]
        public ActionResult<Account> EditAccount(Account account)
        {
            var acc = _accountService.EditAccount(account);
            if (acc != null)
            {
                return acc;
            }
            return Ok("Error Occured");
        }
        [HttpGet("GetAllAccountDetails")]
        public ICollection<Account> GetAllAccounts()
        {
            var acc = _accountService.GetAccounts();
            if (acc != null)
            {
                return acc.ToList();
            }
            return null;
        }
        [HttpGet("{id},Name= GetAccount")]
        public Account GetAllAccount(int id)
        {
            var acc = _accountService.GetAccount(id);
            if (acc != null)
            {
                return acc;
            }
            return null;
        }
        [HttpDelete("{id}, Name= DeleteAccount")]
        public ActionResult<Account> DeleteAccount(int id)
        {
            var acc = _accountService.DeleteAccount(id);
            if(acc != null)
            {
                return acc;
            }
            return Ok("Error Occured");
        }

    }
}
