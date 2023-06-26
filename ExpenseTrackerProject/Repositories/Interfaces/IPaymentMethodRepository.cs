using ExpenseTrackerProject.Models;

namespace ExpenseTrackerProject.Repositories.Interfaces
{
    public interface IPaymentMethodRepository
    {
        IEnumerable<PaymentMethod> GetAllPaymentMethods();
        PaymentMethod GetPaymentMethodById(int id);
        void AddPaymentMethod(PaymentMethod paymentMethod);
        void UpdatePaymentMethod(PaymentMethod paymentMethod);
        void DeletePaymentMethod(int id);
        void Save();
    }
}
