Bank Assignment: ControlFlow details

Projects:

*Bank project has AuthenticationHandler and controllers.
     *Controllers will pass data to service. 
     *Service will pass data to repository and in repository data will connect with db.
     *After that repository will returns ServiceResponse object to controller.
     *ServiceResponse is an object(check it in models). It return object and status/message.


1.Bank - startup project
  1.1.AuthenticationHandler - It has BasicAuthenticationHandler to implement Basic authentication.
			      After successfull authentication, redirects to AuthenticationController and displays user object.
  1.2.Controllers - 
	1.2.1.CustomerController - To perform add/edit/get/getAll/delete customer object.	
	Dependency Injection:
	control flow => Customercontroller -> CustomerService(Implements ICustomer interface) -> Repository.DataAccess(add/edit/get/getAll/delete) ->BankDbContext
	
	Customer Object- CustomerId(PK),FirstName,LastName,UserName,Password,FullName,AccountId(FK).  	

	1.2.2.AccountController - To perform add/edit/get/getAll/delete Account object(i.e. Savings Account, Current Account, Salary Account etc).
	Dependency Injection:
 	control flow => Customercontroller -> AccountService(Implements IAccount interface) -> Repository.AccountDbAccess(add/edit/get/getAll/delete) ->BankDbContext

	Account Object- AccountId(PK), AccountType(Savings,Current,Salary).

	1.2.3.ActionController - To perform add/edit/get/getAll/delete Action object(Deposit, Withdraw, AddAmount).
	Dependency Injection:
	control flow => Actioncontroller -> ActionService(Implements IAction interface) -> Repository.ActionAccess(add/edit/get/getAll/delete) ->BankDbContext

	ActionData Object- ActionId(PK),ActionName(Deposit, Withdraw,AddAmount).

	1.2.4.AccountBalanceController - To perform AddAmount/Deposit/Withdraw AccountBalance object.
	Dependency Injection:
	control flow => Actioncontroller -> AccountBalanceService(Implements IAccountBalance interface) -> Repository.AccountBalanceAccess(AddAmount/Deposit/Withdraw) ->BankDbContext

	AccountBalance Object -AccountBalanceId(PK),AccountId(FK),AccountNumber,Balance,CustomerId(FK).

2.Bank_Models
  
  2.1.Account  - (i.e. Savings,Current,Salary)
  2.2.Customer - (i.e. Customer details)
  2.3.ActionData (i.e.Deposit,Withdraw,AddAmount)
  *2.4.AccountBalance (i.e. AccountId,CustomerId,AccountNumber,Balance)
  *2.5.TransactionAudit - To store transaction history of addAmount/Deposit/Withdraw details (TransactionAuditId,ActionId(FK),CustomerId(FK),Balance,CreatedDate)
  2.6.ServiceResponse - To store the data and displays the status(true/false) and message (ex: Record added/updated/deleted etc)


3.Bank_Services
  
  3.1.Interfaces: Added interfaces to do add/edit/delete/get/getAll.
  3.2.Services: service implements interface and calls repository to connect with database.

4.Database_Repository

  4.1.DatabaseContext - It has BankDbContext
  4.2.Repository - It has DbAccess classes to connect with BankDbContext and perform operations.
		   Data filter and validations are done in repository.

    

*Please avoid Test(I have not added it)     
