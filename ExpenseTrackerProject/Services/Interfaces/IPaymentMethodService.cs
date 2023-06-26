using ExpenseTrackerProject.Models;

namespace ExpenseTrackerProject.Services.Interfaces
{

    public interface IPaymentMethodService
    {
        PaymentMethod GetPaymentMethodById(int id);
        IEnumerable<PaymentMethod> GetAllPaymentMethods();
        void AddPaymentMethod(PaymentMethod paymentMethod);
        void UpdatePaymentMethod(PaymentMethod paymentMethod);
        void DeletePaymentMethod(int id);
        void Save();
    }
}
