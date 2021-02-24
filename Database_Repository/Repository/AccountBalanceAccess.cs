using Bank_Models.Models;
using Database_Repository.DatabaseContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Database_Repository.Repository
{
    public class AccountBalanceAccess
    {
        private readonly BankDbContext _bankDbContext;
        public AccountBalanceAccess(BankDbContext bankDbContext)
        {
            _bankDbContext = bankDbContext;
        }
        public async Task<ActionResult<AccountBalance>> AddAmount(AccountBalance accountBalance)
        {
           
            //Adding data into transaction table to capture transaction history
            TransactionAudit audit = new TransactionAudit();
            audit.ActionId = 5; // FirstTime Add Amount
            audit.CustomerId = accountBalance.CustomerId;
            audit.Balance = accountBalance.Balance;
            audit.CreatedDate = DateTime.Now;
            await _bankDbContext.TransactionAudits.AddAsync(audit);

            await _bankDbContext.AccountBalances.AddAsync(accountBalance);
            await _bankDbContext.SaveChangesAsync();

            return accountBalance;
        }
        public async Task<ActionResult<AccountBalance>> DepositAccountBalance(AccountBalance accountBalance)
        {
            var depositAccountDetails = await _bankDbContext.AccountBalances.Include(x =>x.Customer).ThenInclude(x =>x.Account)
                                                                            .FirstOrDefaultAsync(x => x.AccountNumber == accountBalance.AccountNumber);
            if (depositAccountDetails != null)
            {
                //Adding data into transaction table to capture transaction history
                TransactionAudit audit = new TransactionAudit();
                audit.ActionId = 1; //Deposit
                audit.CustomerId = depositAccountDetails.CustomerId;
                audit.Balance = accountBalance.Balance;
                audit.CreatedDate = DateTime.Now;
                await _bankDbContext.TransactionAudits.AddAsync(audit);

                depositAccountDetails.Balance = (depositAccountDetails.Balance + accountBalance.Balance);
                _bankDbContext.AccountBalances.Update(depositAccountDetails);
                await _bankDbContext.SaveChangesAsync();
                return depositAccountDetails;
            }
            return null;
        }
        public async Task<ActionResult<AccountBalance>> WithdrawAccountBalance(AccountBalance accountBalance)
        {
            var depositAccountDetails = await _bankDbContext.AccountBalances.Include(x => x.Customer)
                                                                            .ThenInclude(x => x.Account)
                                                                            .FirstOrDefaultAsync(x => x.AccountNumber == accountBalance.AccountNumber);
            if (depositAccountDetails != null)
            {
                if (depositAccountDetails.Balance < accountBalance.Balance)
                {
                    return null;
                }
                else
                {
                    //Adding data into transaction table to capture transaction history
                    TransactionAudit audit = new TransactionAudit();
                    audit.ActionId = 2; //Withdraw
                    audit.CustomerId = depositAccountDetails.CustomerId;
                    audit.Balance = accountBalance.Balance;
                    audit.CreatedDate = DateTime.Now;
                    await _bankDbContext.TransactionAudits.AddAsync(audit);
                    depositAccountDetails.Balance = (depositAccountDetails.Balance - accountBalance.Balance);
                    _bankDbContext.AccountBalances.Update(depositAccountDetails);
                    await _bankDbContext.SaveChangesAsync();
                    return depositAccountDetails;
                }
            }
            return null;
        }
    }
}
