using System;
using System.Threading.Tasks;
using AtkTennisApp.Domains;

namespace AtkTennisApp.Services
{
    public interface IPaymentService
    {
        Task<PaymentTransaction> GetById(int id,
            bool includeBank = false);
        Task<PaymentTransaction> GetByOrderNumber(Guid orderNumber,
            bool includeBank = false);
        Task Insert(PaymentTransaction paymentTransaction);
        Task Update(PaymentTransaction paymentTransaction);
    }
}