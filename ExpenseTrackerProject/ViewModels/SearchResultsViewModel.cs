using ExpenseTrackerProject.Models;

namespace ExpenseTrackerProject.ViewModels
{
    public class SearchResultsViewModel
    {
        public string Query { get; set; }
        public List<User> Users { get; set; }
        public List<Expense> Expenses { get; set; }
        public List<Income> Incomes { get; set; }
        public List<Budget> Budgets { get; set; }
        public List<PaymentMethod> PaymentMethods { get; set; }
        public List<Category> Categories { get; set; }
    }
}
