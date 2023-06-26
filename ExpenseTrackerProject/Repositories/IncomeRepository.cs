using ExpenseTrackerProject.Models;
using ExpenseTrackerProject.Repositories.Interfaces;

namespace ExpenseTrackerProject.Repositories
{
   
    public class IncomeRepository : IIncomeRepository
    {
        private readonly ExpenseTrackerDbContext _context;

        public IncomeRepository(ExpenseTrackerDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Income> GetAllIncomes()
        {
            return _context.Incomes.ToList();
        }

        public Income GetIncomeById(int incomeId)
        {
            return _context.Incomes.Find(incomeId);
           
        }

        public void AddIncome(Income income)
        {
            _context.Incomes.Add(income);
        }

        public void UpdateIncome(Income income)
        {
            _context.Incomes.Update(income);
        }

        public void DeleteIncome(int incomeId)
        {
            var income = GetIncomeById(incomeId);
            _context.Incomes.Remove(income);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }

}
