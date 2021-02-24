using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Bank_Models.Models
{
    public class AccountBalance
    {
        [Key]
        public int AccountBalanceId { get; set; }     // primary key
        [Required(ErrorMessage = "AccountId is Required")]
        [ForeignKey("Account")]
        public int AccountId { get; set; }
        [Required(ErrorMessage = "AccountNumber is Required")]
        public long AccountNumber { get; set; }      // primary key
        [Required(ErrorMessage ="Balance is Required")]
        public double Balance { get; set; }
        [ForeignKey("Customer")]
        [Required(ErrorMessage ="CustomerId is Required")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public Account Account { get; set; }

    }
}
