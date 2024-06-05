using Microsoft.EntityFrameworkCore;
using MyProject.Dtos.Amenities;
using MyProject.Models.RealStates;
using MyProject1.Models;
using MyProject1.Models.RealStates;

namespace MyProject1.Services.AmenitiesCompoundServices
{
    public class AmenitiesCompoundServices : IAmenitiesCompoundServices
    {
        private readonly ApplicationDbContext _context;

        public AmenitiesCompoundServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<CompoundAmenities> AddAmenitiesOfCompound(int compoundId, int amenitiesId)
        {
            var result = new CompoundAmenities()
            {
                AmenitiesId = amenitiesId,
                CompoundId = compoundId

            };

            await _context.AddAsync(result);
            await _context.SaveChangesAsync();
            return result;
        }







        public async Task<IEnumerable<CompoundAmenities>> GetAmenitiesOfCompound(int compoundId)
        {
            var compoundAmenities = await _context.CompoundAmenities
                .Where(x => x.CompoundId == compoundId)
                .Include(x => x.Amenities)
                .Include(x => x.Compound)
                .ToListAsync();
            return compoundAmenities;
        }
    }
}
