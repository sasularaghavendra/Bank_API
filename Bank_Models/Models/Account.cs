using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bank_Models.Models
{
    public class Account
    {
        [Key]
        public int AccountId { get; set; }
        [Required]
        [MaxLength(20)]
        public string AccountType { get; set; }
    }
}
