using ExpenseTrackerProject.Models;
using ExpenseTrackerProject.Repositories.Interfaces;

namespace ExpenseTrackerProject.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly ExpenseTrackerDbContext _context;
        private IBudgetRepository _budget;
        private IPaymentMethodRepository _paymentMethod;
        private IExpenseRepository _expense;
        private IIncomeRepository _income;
        private ICategoryRepository _category;
        private IUserRepository _user;

        public RepositoryWrapper(ExpenseTrackerDbContext context)
        {
            _context = context;
        }

        public IBudgetRepository Budget
        {
            get
            {
                if (_budget != null)
                {
                    return _budget;
                }
                _budget = new BudgetRepository(_context);
                return _budget;
            }
        }

        public IPaymentMethodRepository PaymentMethod
        {
            get
            {
                if (_paymentMethod == null)
                {
                    _paymentMethod = new PaymentMethodRepository(_context);
                }
                return _paymentMethod;
            }
        }

        public IExpenseRepository Expense
        {
            get
            {
                if (_expense == null)
                {
                    _expense = new ExpenseRepository(_context);
                }
                return _expense;
            }
        }

        public IIncomeRepository Income
        {
            get
            {
                if (_income == null)
                {
                    _income = new IncomeRepository(_context);
                }
                return _income;
            }
        }

        public ICategoryRepository Category
        {
            get
            {
                if (_category == null)
                {
                    _category = new CategoryRepository(_context);
                }
                return _category;
            }
        }

        public IUserRepository User
        {
            get
            {
                if (_user == null)
                {
                    _user = new UserRepository(_context);
                }
                return _user;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }


}
