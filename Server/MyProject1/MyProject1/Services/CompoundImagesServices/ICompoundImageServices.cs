using MyProject.Models.RealStates;
using MyProject1.Models.RealStates;
using MyProject1.Services.ImageServices;

namespace MyProject1.Services.CompoundImagesServices
{
    public interface ICompoundImageServices
    {
        Task<IEnumerable<CompoundImages>> AddCompoundImages(IEnumerable<IFormFile> images, Compound compound);

    }
}
