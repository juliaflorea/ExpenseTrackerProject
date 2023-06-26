using ExpenseTrackerProject.Models;

namespace ExpenseTrackerProject.Repositories.Interfaces
{
    public interface IIncomeRepository
    {
        IEnumerable<Income> GetAllIncomes();
        Income GetIncomeById(int incomeId);
        void AddIncome(Income income);
        void UpdateIncome(Income income);
        void DeleteIncome(int incomeId);
        void Save();
    }
}
