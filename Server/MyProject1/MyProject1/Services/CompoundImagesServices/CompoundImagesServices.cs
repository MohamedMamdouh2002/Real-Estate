using MyProject.Models.RealStates;
using MyProject1.Dtos.CompoundDtos;
using MyProject1.Models;
using MyProject1.Models.RealStates;
using MyProject1.Services.ImageServices;
using Newtonsoft.Json.Linq;

namespace MyProject1.Services.CompoundImagesServices
{
    public class CompoundImagesServices : ICompoundImageServices
    {
        private readonly ApplicationDbContext _context;
        private readonly IImageServices<CompoundImages> _imageServices;

        public CompoundImagesServices(ApplicationDbContext context, IImageServices<CompoundImages> imageServices)
        {
            _context = context;
            _imageServices = imageServices;
        }
        public async Task<IEnumerable<CompoundImages>> AddCompoundImages(IEnumerable<IFormFile> images, Compound compound)
        {
            IEnumerable<CompoundImages> compoundImages = new List<CompoundImages>();
            if (images != null)
            {
                foreach (var img in images)
                {
                    CompoundImages compoundImage = new CompoundImages()
                    {
                        CompoundId = compound.Id,
                        compound = compound,
                    };
                    _imageServices.SetImage(compoundImage, img);
                    await _context.AddAsync(compoundImage);
                    await _context.SaveChangesAsync();
                    compoundImages.Append(compoundImage);
                }

            }
            return compoundImages;
        }

    }
}
