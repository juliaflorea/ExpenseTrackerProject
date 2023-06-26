using ExpenseTrackerProject.Models;
using ExpenseTrackerProject.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTrackerProject.Repositories
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly ExpenseTrackerDbContext _context;

        public ExpenseRepository(ExpenseTrackerDbContext context)
        {
            _context = context;
        }

        public Expense GetExpenseById(int id)
        {
            return _context.Expenses.Find(id);
        }

        public IEnumerable<Expense> GetAllExpenses()
        {
            return _context.Expenses.ToList();
        }

        public void AddExpense(Expense expense)
        {
            _context.Expenses.Add(expense);
            _context.SaveChanges();
        }

        public void UpdateExpense(Expense expense)
        {
            _context.Expenses.Update(expense);
            _context.SaveChanges();
        }

        public void DeleteExpense(int id)
        {
            var expense = _context.Expenses.Find(id);
            _context.Expenses.Remove(expense);
            _context.SaveChanges();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }


}
