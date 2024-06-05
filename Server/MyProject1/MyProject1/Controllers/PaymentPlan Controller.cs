using Microsoft.AspNetCore.Mvc;
using MyProject.Dtos.PaymentnPlan;
using MyProject.Services.CompoundServices;
using MyProject.Services.PaymentPlanServices;
using MyProject.Services.RealEStatesServices;
using MyProject1.Models.RealStates;

namespace MyProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentPlan_Controller : ControllerBase
    {
        private readonly IPaymentPlanServices _services;

        private readonly IRealEStateServices _realEStateServices;
        private readonly ICompoundServices _compoundServices;

        public PaymentPlan_Controller
            (IPaymentPlanServices paymentPlanServices,
            ICompoundServices compoundServices,
            IRealEStateServices realEStateServices)
        {
            _services = paymentPlanServices;
            _compoundServices = compoundServices;
            _realEStateServices = realEStateServices;
        }

        [HttpPost("AddPaymentPlanForRealEState/{compoundId}/{realEStateId}")]
        public async Task<IActionResult> AddPaymentPlanForRealEStateAsync(int compoundId, int realEStateId)
        {
            var realEState = await _realEStateServices.GetById(realEStateId);
            var compound = await _compoundServices.GetByIdReturnDto(compoundId);
            var compoundPaymentPlans = compound.paymentPlans.ToList();
            foreach (var compoundPaymentPlan in compoundPaymentPlans)
            {
                PaymentPlanForRealEState payment = new PaymentPlanForRealEState()
                {
                    Price = realEState.Price,
                    Percentage = compoundPaymentPlan.Percentage,
                    Years = compoundPaymentPlan.Years,
                    RealEStateId = realEStateId,

                };
                await _services.AddPaymentPlanForRealEState(payment);
            }
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetPaymentPlanForRealEState(int RealEStateId)
        {
            var paymentPlan = await _services.GetPaymentPlanForRealEStateId(RealEStateId);
            return Ok(paymentPlan);
        }
        [HttpPost("{compoundId}")]
        public async Task<IActionResult> AddPaymentPlanForCompoundAsync(int compoundId, [FromForm] PaymentPlanDto dto)
        {

            PaymentPlanForCompound payment = new PaymentPlanForCompound()
            {
                Years = dto.Years,
                Percentage = dto.Percentage,
                CompoundId = compoundId,

            };
            await _services.AddPaymentPlanForCompound(payment);
            return Ok(payment);
        }

    }
}
