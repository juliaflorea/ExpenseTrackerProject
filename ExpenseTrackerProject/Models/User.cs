using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ExpenseTrackerProject.Models
{



    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string Email { get; set; }

        [Column(TypeName = "nvarchar(10)")]
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; }

        public ICollection<Expense>? Expenses { get; set; }
        public ICollection<Income>? Incomes { get; set; }
        public ICollection<Budget>? Budgets { get; set; }


    }
}