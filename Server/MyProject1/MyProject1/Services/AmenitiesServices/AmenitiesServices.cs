using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyProject.Dtos.Amenities;
using MyProject.Models.RealStates;
using MyProject.Services.RealEStatesServices;
using MyProject1.Models;
using MyProject1.Models.RealStates;
using MyProject1.Services.ImageServices;

namespace MyProject.Services.AmenitiesServices
{
    public class AmenitiesServices : IAmentiesServicces
    {
        private readonly ApplicationDbContext _context;
        private readonly IImageServices<Amenities> _imageServices;
        private readonly IMapper _mapper;

        public AmenitiesServices(ApplicationDbContext context, IImageServices<Amenities> imageServices)
        {
            _context = context;
            _imageServices = imageServices;
        }

        public async Task<Amenities> Add(Amenities amenities, IFormFile photo)
        {

            _imageServices.SetImage(amenities, photo);
            await _context.AddAsync(amenities);
            await _context.SaveChangesAsync();
            return amenities;
        }

        public Amenities Delete(Amenities amenities)
        {
            _context.Remove(amenities);
            _context.SaveChanges();
            return amenities;
        }

        public async Task<IEnumerable<Amenities>> GetAll()
        {
            return await _context.Amenities.ToListAsync();
        }

        public async Task<Amenities> GetById(int AmenitiesId)
        {
            return await _context.Amenities.SingleOrDefaultAsync(p => p.Id == AmenitiesId);
        }

        public async Task<IEnumerable<CompoundAmenities>> GetByCompoundId(int CompoundId)
        {

            var amenities = await _context.CompoundAmenities
                .Where(a => a.CompoundId == CompoundId)
                .Include(a => a.Amenities)
                .ToListAsync();
            return (amenities);

        }

        public Amenities update(Amenities amenities)
        {
            _context.Update(amenities);
            _context.SaveChanges();
            return amenities;
        }

        public async Task<Amenities> GetByName(string AmenitiesName)
        {
            var amenities = await _context.Amenities.SingleOrDefaultAsync(p => p.Name == AmenitiesName);
            return amenities;
        }
    }
}
