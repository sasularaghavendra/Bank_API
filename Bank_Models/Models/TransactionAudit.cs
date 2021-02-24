using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Bank_Models.Models
{
    public class TransactionAudit
    {
        [Key]
        public int TransactionAuditId { get; set; }
        [ForeignKey("Action")]
        public int ActionId { get; set; }
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        [Required]
        public double Balance { get; set; }
        public DateTime? CreatedDate { get; set; }
        public ActionData Action { get; set; }
        public Customer Customer { get; set; }
    }
}
