using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ExpenseTrackerProject.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<Expense>? Expenses { get; set; }
       
        public ICollection<Budget>? Budgets { get; set; }
    }
}
