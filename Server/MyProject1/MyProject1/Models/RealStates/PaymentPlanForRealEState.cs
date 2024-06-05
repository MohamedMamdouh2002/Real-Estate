using MyProject.Models.realstates;

namespace MyProject1.Models.RealStates
{
    public class PaymentPlanForRealEState
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public double Percentage { get; set; }
        public int Persenter
        {
            get { return (int)(Price * Percentage); }
            set { }
        }
        public int Years { get; set; }
        public int RestPrice
        {
            get { return Price - Persenter; }
            set { }
        }
        public int Installment
        {
            get { return RestPrice / (Years * 4); }
            set { }
        }
        public int RealEStateId { get; set; }
        public RealEState RealEState { get; set; }

    }
}
