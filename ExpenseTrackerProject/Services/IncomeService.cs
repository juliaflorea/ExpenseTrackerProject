using ExpenseTrackerProject.Models;
using ExpenseTrackerProject.Repositories.Interfaces;
using ExpenseTrackerProject.Services.Interfaces;

namespace ExpenseTrackerProject.Services
{
    public class IncomeService : IIncomeService
    {
        private readonly IRepositoryWrapper _repository;
        public IncomeService(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        public IncomeService()
        {
        }

        public Income GetIncomeById(int id)
        {
            return _repository.Income.GetIncomeById(id);
        }

        public IEnumerable<Income> GetAllIncomes()
        {
            return _repository.Income.GetAllIncomes();
        }

        public void AddIncome(Income income)
        {
            _repository.Income.AddIncome(income);
            _repository.Save();
        }

        public void UpdateIncome(Income income)
        {
            _repository.Income.UpdateIncome(income);
            _repository.Save();
        }

        public void DeleteIncome(int id)
        {
            var income = _repository.Income.GetIncomeById(id);
            _repository.Income.DeleteIncome(id);
            _repository.Save();
        }

        public void Save()
        {
            _repository.Save();
        }
    }

   

}
