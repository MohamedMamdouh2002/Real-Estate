using MyProject1.Models.RealStates;

namespace MyProject.Services.PaymentPlanServices
{
    public interface IPaymentPlanServices
    {
        Task<PaymentPlanForCompound> AddPaymentPlanForCompound(PaymentPlanForCompound paymentPlan);
        Task<IEnumerable<PaymentPlanForCompound>> GetPaymentPlansOFCompound(int compoundId);
        PaymentPlanForCompound UpdatePaymentPlanForCompound(PaymentPlanForCompound paymentPlan);
        PaymentPlanForCompound DeletePaymentPlanForCompound(PaymentPlanForCompound paymentPlan);
        Task<PaymentPlanForRealEState> AddPaymentPlanForRealEState(PaymentPlanForRealEState paymentPlan);
        Task<IEnumerable<PaymentPlanForRealEState>> GetPaymentPlanForRealEStateId(int RealEStateId);
        PaymentPlanForRealEState Update(PaymentPlanForRealEState paymentPlan);
        PaymentPlanForRealEState Delete(PaymentPlanForRealEState paymentPlan);



    }
}
