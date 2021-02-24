using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bank_Models.Models
{
    public class ActionData
    {
        [Key]
        public int ActionId { get; set; }
        [Required]
        public string ActionName { get; set; }   // Deposit and Withdraw
    }
}
