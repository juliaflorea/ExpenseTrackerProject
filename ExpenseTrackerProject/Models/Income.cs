using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ExpenseTrackerProject.Models
{
    public class Income
    {
        [Key]
        public int IncomeId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreatedAt { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? Description { get; set; }
    }
}
