using ExpenseTrackerProject.Models;
using Microsoft.CodeAnalysis;

namespace ExpenseTrackerProject.Repositories.Interfaces
{
    public interface IBudgetRepository : IRepositoryBase<Budget>

    {
        void AddBudget(Budget budget);
        void DeleteBudget(int id);
        IEnumerable<Budget> GetAllBudgets();
        Budget GetBudgetById(int id);
        void UpdateBudget(Budget budget);
        void Save();
    }
}
