using ExpenseTrackerProject.Models;
using ExpenseTrackerProject.Repositories.Interfaces;
using ExpenseTrackerProject.Services.Interfaces;

namespace ExpenseTrackerProject.Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly IRepositoryWrapper _repository;
        public ExpenseService(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        public ExpenseService()
        {
        }

        public Expense GetExpenseById(int id)
        {
            return _repository.Expense.GetExpenseById(id);
        }

        public IEnumerable<Expense> GetAllExpenses()
        {
            return _repository.Expense.GetAllExpenses();
        }

        public void AddExpense(Expense expense)
        {
            _repository.Expense.AddExpense(expense);
            _repository.Save();
        }

        public void UpdateExpense(Expense expense)
        {
            _repository.Expense.UpdateExpense(expense);
            _repository.Save();
        }

        public void DeleteExpense(int id)
        {
            var expense = _repository.Expense.GetExpenseById(id);
            _repository.Expense.DeleteExpense(id);
            _repository.Save();
        }

        public void Save()
        {
            _repository.Save();
        }
    }

   

}
