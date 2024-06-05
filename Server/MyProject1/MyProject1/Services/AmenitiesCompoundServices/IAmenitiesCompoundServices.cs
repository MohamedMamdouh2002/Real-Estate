using MyProject.Dtos.Amenities;
using MyProject.Models.RealStates;
using MyProject1.Models.RealStates;

namespace MyProject1.Services.AmenitiesCompoundServices
{
    public interface IAmenitiesCompoundServices
    {
        Task<IEnumerable<CompoundAmenities>> GetAmenitiesOfCompound(int compoundId);
        Task<CompoundAmenities> AddAmenitiesOfCompound(int compoundId, int amenitiesId);


    }
}
