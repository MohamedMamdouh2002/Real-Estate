using MyProject.Models.RealStates;

namespace MyProject1.Models.RealStates
{
    public class CompoundAmenities
    {
        public Amenities Amenities { get; set; }

        public int AmenitiesId { get; set; }
        public Compound Compound { get; set; }
        public int CompoundId { get; set; }
    }
}
