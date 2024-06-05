using System.ComponentModel.DataAnnotations;

namespace MyProject1.Filter
{
    public class RealEStateFilter
    {
        [Range(0, double.MaxValue, ErrorMessage = "Price can not be negative!")]
        public int? Price { get; set; }
        public double? BUA { get; set; }
        public int? Bedrooms { get; set; }
        public int? Bathtrooms { get; set; }
        public int? DeliveryIn { get; set; }
        public string? Government { get; set; }
        public string? Area { get; set; }
        public string? CompoundName { get; set; }
        public string? DeveloperName { get; set; }
        public string? Finish { get; set; }
        public bool? WithGardien { get; set; }
        public double? GardienArea { get; set; }
        public bool? WithRoof { get; set; }
        public double? RoofPentHouse { get; set; }



    }
}
