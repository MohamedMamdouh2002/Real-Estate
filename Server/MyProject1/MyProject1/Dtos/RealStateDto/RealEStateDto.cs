namespace MyProject1.Dtos.RealStateDto
{
    public class RealEStateDto
    {
        public int Price { get; set; }
        public double BUA { get; set; }
        public int Bedrooms { get; set; }
        public int Bathtrooms { get; set; }
        public int DeliveryIn { get; set; }
        public string Finish { get; set; }
        public string? CompoundName { get; set; }
        public string? DeveloperName { get; set; }
        public bool WithGardien { get; set; }
        public double? GardienArea { get; set; }
        public bool WithRoof { get; set; }

        public double? RoofPentHouse { get; set; }

    }
}
