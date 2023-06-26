using ExpenseTrackerProject.Models;
using ExpenseTrackerProject.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTrackerProject.Repositories
{
    public class BudgetRepository : RepositoryBase<Budget>, IBudgetRepository
    {

        public BudgetRepository(ExpenseTrackerDbContext dbContext) : base(dbContext)
        {
        }

        public Budget GetBudgetById(int id)
        {
            return _dbContext.Budgets.Include(b => b.Category).FirstOrDefault(b => b.BudgetId == id);
        }

        public IEnumerable<Budget> GetAllBudgets()
        {
            return _dbContext.Budgets.Include(b => b.Category);
        }


        public void AddBudget(Budget budget)
        {
           
            if (budget == null)
            {
                throw new ArgumentNullException(nameof(budget));
            }

            _dbContext.Budgets.Add(budget);
            _dbContext.SaveChanges();
        }

        public void UpdateBudget(Budget budget)
        {
            Update(budget);
        }

        public void DeleteBudget(int id)
        {
            var budget = GetById(id);
            Delete(budget);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }


    }

}
