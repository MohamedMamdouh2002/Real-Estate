using Microsoft.AspNetCore.Http.HttpResults;
using MyProject.Models.realstates;
using MyProject.Services.CompoundServices;
using MyProject.Services.PaymentPlanServices;
using MyProject.Services.RealEStatesServices;
using MyProject1.Models;
using MyProject1.Models.RealStates;

namespace MyProject.Services.PaymentPlan
{
    public class PaymentPlanServices : IPaymentPlanServices
    {
        private readonly ApplicationDbContext _context;
        private readonly IRealEStateServices _realEStateServices;
        private readonly ICompoundServices _compoundServices;

        public PaymentPlanServices(ICompoundServices compoundServices, IRealEStateServices realEStateServices, ApplicationDbContext context)
        {
            _compoundServices = compoundServices;
            _realEStateServices = realEStateServices;
            _context = context;
        }

        public async Task<PaymentPlanForCompound> AddPaymentPlanForCompound(PaymentPlanForCompound paymentPlan)
        {
            await _context.AddAsync(paymentPlan);
            await _context.SaveChangesAsync();
            return paymentPlan;
        }

        public async Task<PaymentPlanForRealEState> AddPaymentPlanForRealEState(PaymentPlanForRealEState paymentPlan)
        {
            await _context.SaveChangesAsync();
            await _context.AddAsync(paymentPlan);
            await _context.SaveChangesAsync();
            return paymentPlan;

        }

        public PaymentPlanForRealEState Delete(PaymentPlanForRealEState paymentPlan)
        {
            _context.Remove(paymentPlan);
            _context.SaveChanges();
            return paymentPlan;
        }

        public PaymentPlanForCompound DeletePaymentPlanForCompound(PaymentPlanForCompound paymentPlan)
        {
            _context.Remove(paymentPlan);
            _context.SaveChanges();
            return paymentPlan;
        }

        public async Task<IEnumerable<PaymentPlanForRealEState>> GetPaymentPlanForRealEStateId(int RealEStateId)
        {
            var RealEState = await _realEStateServices.GetById(RealEStateId);
            if (RealEState.Payment != null)
            {
                return RealEState.Payment.ToList();
            }
            return RealEState.Payment.ToList();
        }


        public async Task<IEnumerable<PaymentPlanForCompound>> GetPaymentPlansOFCompound(int compoundId)
        {
            var compound = _compoundServices.GetById(compoundId);
            return compound.paymentPlans.ToList();
        }

        public PaymentPlanForRealEState Update(PaymentPlanForRealEState paymentPlan)
        {
            _context.Update(paymentPlan);
            _context.SaveChanges();
            return paymentPlan;
        }

        public PaymentPlanForCompound UpdatePaymentPlanForCompound(PaymentPlanForCompound paymentPlan)
        {
            _context.Update(paymentPlan);
            _context.SaveChanges();
            return paymentPlan;
        }
    }
}
