using ExpenseTrackerProject.Models;
using ExpenseTrackerProject.Repositories.Interfaces;

namespace ExpenseTrackerProject.Repositories
{
    public class PaymentMethodRepository : IPaymentMethodRepository
    {
        private readonly ExpenseTrackerDbContext _context;

        public PaymentMethodRepository(ExpenseTrackerDbContext context)
        {
            _context = context;
        }

        public IEnumerable<PaymentMethod> GetAllPaymentMethods()
        {
            return _context.PaymentMethods.ToList();
        }

        public PaymentMethod GetPaymentMethodById(int id)
        {
            return _context.PaymentMethods.Find(id);
        }

        public void AddPaymentMethod(PaymentMethod paymentMethod)
        {
            _context.PaymentMethods.Add(paymentMethod);
        }

        public void UpdatePaymentMethod(PaymentMethod paymentMethod)
        {
            _context.PaymentMethods.Update(paymentMethod);
        }

        public void DeletePaymentMethod(int id)
        {
            PaymentMethod paymentMethod = GetPaymentMethodById(id);
            _context.PaymentMethods.Remove(paymentMethod);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
