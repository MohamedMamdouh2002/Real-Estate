using Microsoft.AspNetCore.Mvc;
using MyProject.Dtos.Amenities;
using MyProject.Models.RealStates;
using MyProject1.Models.RealStates;

namespace MyProject.Services.AmenitiesServices
{
    public interface IAmentiesServicces
    {
        Task<IEnumerable<CompoundAmenities>> GetByCompoundId(int compoundId);
        Task<Amenities> GetById(int AmenitiesId);
        Task<Amenities> GetByName(string AmenitiesName);
        Task<IEnumerable<Amenities>> GetAll();
        Task<Amenities> Add(Amenities amenities, IFormFile photo);
        Amenities Delete(Amenities amenities);
        Amenities update(Amenities amenities);


    }
}
