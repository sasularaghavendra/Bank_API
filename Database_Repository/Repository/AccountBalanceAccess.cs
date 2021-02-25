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
        private readonly ServiceResponse<AccountBalance> serviceResponse = new ServiceResponse<AccountBalance>();
        public AccountBalanceAccess(BankDbContext bankDbContext)
        {
            _bankDbContext = bankDbContext;
        }
        public async Task<ServiceResponse<AccountBalance>> AddAmount(AccountBalance accountBalance)
        {
            try
            {
                accountBalance.AccountBalanceId = 0; //Identity column
                //Adding data into transaction table to capture transaction history
                TransactionAudit audit = new TransactionAudit();
                audit.ActionId = 1; // FirstTime Add Amount
                audit.CustomerId = accountBalance.CustomerId;
                audit.Balance = accountBalance.Balance;
                audit.CreatedDate = DateTime.Now;
                await _bankDbContext.TransactionAudits.AddAsync(audit);
                await _bankDbContext.AccountBalances.AddAsync(accountBalance);
                await _bankDbContext.SaveChangesAsync();

                serviceResponse.Data = accountBalance;
                serviceResponse.Message = $"First time amount added successfully...Balance is {accountBalance.Balance}";
                return serviceResponse;
            }
            catch(Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
                return serviceResponse;
            }
        }
        public async Task<ServiceResponse<AccountBalance>> DepositAccountBalance(AccountBalance accountBalance)
        {
            try
            {
                var depositAccountDetails = await _bankDbContext.AccountBalances.Include(x => x.Customer)
                                                                .ThenInclude(x => x.Account)
                                                                .FirstOrDefaultAsync(x => x.AccountNumber == accountBalance.AccountNumber && x.AccountId ==accountBalance.AccountId);
                if (depositAccountDetails != null)
                {
                    accountBalance.AccountBalanceId = 0; //Identity column
                    //Adding data into transaction table to capture transaction history
                    TransactionAudit audit = new TransactionAudit();
                    audit.ActionId = 2; //Deposit
                    audit.CustomerId = depositAccountDetails.CustomerId;
                    audit.Balance = accountBalance.Balance;
                    audit.CreatedDate = DateTime.Now;
                    await _bankDbContext.TransactionAudits.AddAsync(audit);

                    depositAccountDetails.Balance = (depositAccountDetails.Balance + accountBalance.Balance);
                    _bankDbContext.AccountBalances.Update(depositAccountDetails);
                    await _bankDbContext.SaveChangesAsync();
                    serviceResponse.Data = depositAccountDetails;
                    serviceResponse.Message = $"Amount {accountBalance.Balance} deposited successfully..Total available balance is {depositAccountDetails.Balance}";
                    return serviceResponse;
                }
                serviceResponse.Success = false;
                serviceResponse.Message = $"Invalid account number (or) AccountId... Please enter valid account details to deposit.";
                return serviceResponse;
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
                return serviceResponse;
            }
        }
        public async Task<ServiceResponse<AccountBalance>> WithdrawAccountBalance(AccountBalance accountBalance)
        {
            try
            {
                var withdrawAccountDetails = await _bankDbContext.AccountBalances.Include(x => x.Customer)
                                                                            .ThenInclude(x => x.Account)
                                                                            .FirstOrDefaultAsync(x => x.AccountNumber == accountBalance.AccountNumber && x.AccountId == accountBalance.AccountId);
                if (withdrawAccountDetails != null)
                {
                    if (withdrawAccountDetails.Balance < accountBalance.Balance)
                    {
                        serviceResponse.Success = false;
                        serviceResponse.Message = $"Insufficient funds.... Available balance in your account is {withdrawAccountDetails.Balance}";
                        return serviceResponse;
                    }
                    else
                    {
                        accountBalance.AccountBalanceId = 0; //Identity column
                        //Adding data into transaction table to capture transaction history
                        TransactionAudit audit = new TransactionAudit();
                        audit.ActionId = 3; //Withdraw
                        audit.CustomerId = withdrawAccountDetails.CustomerId;
                        audit.Balance = accountBalance.Balance;
                        audit.CreatedDate = DateTime.Now;
                        await _bankDbContext.TransactionAudits.AddAsync(audit);
                        withdrawAccountDetails.Balance = (withdrawAccountDetails.Balance - accountBalance.Balance);
                        _bankDbContext.AccountBalances.Update(withdrawAccountDetails);
                        await _bankDbContext.SaveChangesAsync();
                        serviceResponse.Data = withdrawAccountDetails;
                        serviceResponse.Message = $"Amount {accountBalance.Balance} withdrawn successfull.. Available balance is {withdrawAccountDetails.Balance}";
                        return serviceResponse;
                    }
                }
                serviceResponse.Success = false;
                serviceResponse.Message = $"Invalid account number (or) AccountId... Please enter valid account details to withdraw.";
                return serviceResponse;
            }
            catch(Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
                return serviceResponse;
            }
        }
    }
}
