using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tfmpj.Model.Entities
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string? Description { get; set; } 
        public Guid UserId { get; set; }
        public virtual User? User { get; set; } 
        public int CategoryId { get; set; }
        public virtual Category? Category { get; set; } 
    }
}
