using Microsoft.EntityFrameworkCore;
using MyProject.Dtos.Photo;
using MyProject.Models.RealStates;
using MyProject.Services.Shared;
using MyProject1.Models;
using MyProject1.Services.ImageServices;

namespace MyProject.Services.PhotoServices
{
    public class PhotoServices : IPhotoServices
    {
        private readonly ApplicationDbContext _context;
        private readonly IImageServices<Photo> _imageServices;

        public PhotoServices(ApplicationDbContext context, IImageServices<Photo> imageServices)
        {
            _context = context;
            _imageServices = imageServices;
        }



        public async Task<Photo> Add(Photo photo, IFormFile img)
        {

            _imageServices.SetImage(photo, img);
            await _context.AddAsync(photo);
            await _context.SaveChangesAsync();
            return photo;
        }

        public Photo Delete(Photo photo)
        {
            _context.Remove(photo);
            _context.SaveChanges();
            return photo;
        }

        public async Task<Photo> GetById(int id)
        {
            return await _context.Photos.SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ICollection<Photo>> GetByRealEStateId(int RealEStateId)
        {
            return await _context.Photos.Where(x => x.RealEStateId == RealEStateId).ToListAsync();
        }



        public Photo Update(Photo photo)
        {
            _context.Update(photo);
            _context.SaveChanges();
            return photo;
        }
    }
}
