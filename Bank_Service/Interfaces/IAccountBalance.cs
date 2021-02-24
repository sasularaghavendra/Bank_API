using Bank_Models.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Services.Interfaces
{
    public interface IAccountBalance
    {
        Task<ActionResult<AccountBalance>> DepositAccountBalance(AccountBalance accountBalance);
        Task<ActionResult<AccountBalance>> WithdrawAccountBalance(AccountBalance accountBalance);
    }
}
