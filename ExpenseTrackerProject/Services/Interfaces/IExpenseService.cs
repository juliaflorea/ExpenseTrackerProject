using ExpenseTrackerProject.Models;

namespace ExpenseTrackerProject.Services.Interfaces
{
    public interface IExpenseService
    {
        Expense GetExpenseById(int id);
        IEnumerable<Expense> GetAllExpenses();
        void AddExpense(Expense expense);
        void UpdateExpense(Expense expense);
        void DeleteExpense(int id);
        void Save();
    }
}
