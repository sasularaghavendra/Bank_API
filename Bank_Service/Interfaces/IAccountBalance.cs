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
        Task<ServiceResponse<AccountBalance>> AddAmount(AccountBalance accountBalance);
        Task<ServiceResponse<AccountBalance>> DepositAccountBalance(AccountBalance accountBalance);
        Task<ServiceResponse<AccountBalance>> WithdrawAccountBalance(AccountBalance accountBalance);
    }
}
