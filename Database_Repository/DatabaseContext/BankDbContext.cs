using Microsoft.EntityFrameworkCore;
using Bank_Models.Models;

namespace Database_Repository.DatabaseContext
{
    public class BankDbContext : DbContext
    {
        public BankDbContext(DbContextOptions<BankDbContext> options) : base(options)
        {
                
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<AccountBalance> AccountBalances { get; set; }
        public DbSet<ActionData> Actions { get; set; }
        public DbSet<TransactionAudit> TransactionAudits { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<AccountBalance>().HasKey(acc => new { acc.AccountBalanceId, acc.AccountNumber });
            modelBuilder.Entity<AccountBalance>().Property(acc => acc.AccountBalanceId).UseIdentityColumn();

        }

    }
}
