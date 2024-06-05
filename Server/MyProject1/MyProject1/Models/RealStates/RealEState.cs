
using MyProject.Models.RealStates;
using MyProject1.Models.Lists;
using MyProject1.Models.RealStates;
using System.Text.Json.Serialization;

namespace MyProject.Models.realstates
{
    public class RealEState
    {

        public int Id { get; set; }
        public int Price { get; set; }
        public double BUA { get; set; }
        public int Bedrooms { get; set; }
        public int Bathtrooms { get; set; }
        public int DeliveryIn { get; set; }
        public string Finish { get; set; }
        public bool WithGardien { get; set; }
        public double GardienArea { get; set; }
        public bool WithRoof { get; set; }
        public double RoofPentHouse { get; set; }

        public int CompoundId { get; set; }
        public int RealStatesTypeId { get; set; }
        [JsonIgnore]
        public ICollection<WishListItem> wishListItems { get; set; }
        //navigation
        public Compound Compound { get; set; }

        public ICollection<PaymentPlanForRealEState> Payment { get; set; }
        public RealEStateType RealStatesType { get; set; }
        [JsonIgnore]
        public ICollection<Photo> Photos { get; set; }

    }
}
