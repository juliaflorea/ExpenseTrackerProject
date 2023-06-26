using ExpenseTrackerProject.Models;

namespace ExpenseTrackerProject.Services.Interfaces
{
    public interface IIncomeService
    {
        Income GetIncomeById(int id);
        IEnumerable<Income> GetAllIncomes();
        void AddIncome(Income income);
        void UpdateIncome(Income income);
        void DeleteIncome(int id);
        void Save();
    }
}
