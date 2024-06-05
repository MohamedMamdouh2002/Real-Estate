
using MyProject.Dtos.Photo;
using MyProject.Models.RealStates;

namespace MyProject.Services.PhotoServices
{
    public interface IPhotoServices
    {

        Task<ICollection<Photo>> GetByRealEStateId(int RealEStateId);
        Task<Photo> GetById(int id);
        Task<Photo> Add(Photo photo, IFormFile? img);
        Photo Update(Photo photo);
        Photo Delete(Photo photo);
    }
}
