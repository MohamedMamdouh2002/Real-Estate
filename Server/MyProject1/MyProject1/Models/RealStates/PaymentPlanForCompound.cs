
using MyProject.Models.RealStates;

namespace MyProject1.Models.RealStates
{
    public class PaymentPlanForCompound
    {


        public int Id { get; set; }

        public double Percentage { get; set; }

        public int Years { get; set; }

        public int CompoundId { get; set; }
        public Compound Compound { get; set; }
    }
}


