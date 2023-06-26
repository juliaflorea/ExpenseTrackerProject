using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ExpenseTrackerProject.Models
{
    public class PaymentMethod
    {
        [Key]
        public int PaymentMethodId { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<Expense>? Expenses { get; set; }
    }
}
