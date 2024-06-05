using MyProject1.Models.RealStates;
using System.Text.Json.Serialization;

namespace MyProject.Models.RealStates
{
    public class Amenities
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImgURL { get; set; }
        [JsonIgnore]
        public ICollection<CompoundAmenities> CompoundAmenities { get; set; }
    }
}
