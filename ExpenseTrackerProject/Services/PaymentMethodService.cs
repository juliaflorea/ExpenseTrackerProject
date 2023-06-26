using ExpenseTrackerProject.Models;
using ExpenseTrackerProject.Repositories.Interfaces;
using ExpenseTrackerProject.Services.Interfaces;

namespace ExpenseTrackerProject.Services
{

    public class PaymentMethodService : IPaymentMethodService
    {
        private readonly IRepositoryWrapper _repository;

        public PaymentMethodService(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        public PaymentMethodService()
        {
        }

        public PaymentMethod GetPaymentMethodById(int id)
        {
            return _repository.PaymentMethod.GetPaymentMethodById(id);
        }

        public IEnumerable<PaymentMethod> GetAllPaymentMethods()
        {
            return _repository.PaymentMethod.GetAllPaymentMethods();
        }

        public void AddPaymentMethod(PaymentMethod paymentMethod)
        {
            _repository.PaymentMethod.AddPaymentMethod(paymentMethod);
            _repository.Save();
        }

        public void UpdatePaymentMethod(PaymentMethod paymentMethod)
        {
            _repository.PaymentMethod.UpdatePaymentMethod(paymentMethod);
            _repository.Save();
        }

        public void DeletePaymentMethod(int id)
        {
            var paymentMethod = _repository.PaymentMethod.GetPaymentMethodById(id);
            _repository.PaymentMethod.DeletePaymentMethod(id);
            _repository.Save();
        }

        public void Save()
        {
            _repository.Save();
        }
    }

}


