using ExpenseTrackerProject.Models;

namespace ExpenseTrackerProject.Repositories.Interfaces
{
    public interface IExpenseRepository
    {
        Expense GetExpenseById(int id);
        IEnumerable<Expense> GetAllExpenses();
        void AddExpense(Expense expense);
        void UpdateExpense(Expense expense);
        void DeleteExpense(int id);
        void Save();
    }
}
