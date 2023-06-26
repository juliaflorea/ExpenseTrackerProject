using ExpenseTrackerProject.Models;

namespace ExpenseTrackerProject.Repositories.Interfaces
{
    public interface IRepositoryWrapper
    {
        IBudgetRepository Budget { get; }
        IPaymentMethodRepository PaymentMethod { get; }
        IExpenseRepository Expense { get; }
        IIncomeRepository Income { get; }
        ICategoryRepository Category { get; }
        IUserRepository User { get; }
        void Save();

        
    }
}
