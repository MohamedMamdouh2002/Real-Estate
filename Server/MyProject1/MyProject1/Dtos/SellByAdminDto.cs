

namespace MyProject.Dtos
{
    public class SellByAdminDto
    {
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
    }
}
