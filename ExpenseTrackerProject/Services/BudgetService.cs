using ExpenseTrackerProject.Models;
using ExpenseTrackerProject.Repositories.Interfaces;
using ExpenseTrackerProject.Services.Interfaces;
using ExpenseTrackerProject.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTrackerProject.Services
{
    public class BudgetService : IBudgetService
    {
        private readonly IRepositoryWrapper _repository;
        public BudgetService(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        public BudgetService()
        {
        }

        public Budget GetBudgetById(int id)
        {
            return _repository.Budget.GetBudgetById(id);
        }

        public IEnumerable<Budget> GetAllBudgets()
        {
            return _repository.Budget.GetAllBudgets();
        }

        public void AddBudget(Budget budget)
        {
            _repository.Budget.AddBudget(budget);
            _repository.Save();

        }

        public void UpdateBudget(Budget budget)
        {
            _repository.Budget.UpdateBudget(budget);
            _repository.Save();
        }

        public void DeleteBudget(int id)
        {
            var budget = _repository.Budget.GetBudgetById(id);
            _repository.Budget.DeleteBudget(id);
            _repository.Save();
        }

        public void Save()
        {
            _repository.Save();
        }
    }

}
