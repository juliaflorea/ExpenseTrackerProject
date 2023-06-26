using ExpenseTrackerProject.Models;

namespace ExpenseTrackerProject.Services.Interfaces
{
    public interface IBudgetService
    {
        Budget GetBudgetById(int id);
        IEnumerable<Budget> GetAllBudgets();
        void AddBudget(Budget budget);
        void UpdateBudget(Budget budget);
        void DeleteBudget(int id);
        void Save();
    }
}
