using MyProject.Models.RealStates;

namespace MyProject1.Services.ImageServices
{
    public class AmenitiesImageServices : IImageServices<Amenities>
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AmenitiesImageServices(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public void SetImage(Amenities amenities, IFormFile? imgFile)
        {

            if (imgFile == null)
            {
                amenities.ImgURL = "\\images\\No_Image.png";
            }
            else
            {
                DeleteImage(amenities);
                string imgExtension = Path.GetExtension(imgFile.FileName);
                Guid imgGuid = Guid.NewGuid();
                string imgName = imgGuid + imgExtension;
                string imgUrl = "\\images\\" + imgName;
                amenities.ImgURL = imgUrl;

                string imgPath = _webHostEnvironment.WebRootPath + imgUrl;
                using (var imgStream = new FileStream(imgPath, FileMode.Create))
                {
                    imgFile.CopyTo(imgStream);
                }
            }

        }
        public void DeleteImage(Amenities amenities)
        {
            if (!string.IsNullOrEmpty(amenities.ImgURL))
            {
                var imgOldPath = _webHostEnvironment.WebRootPath + amenities.ImgURL;
                if (File.Exists(imgOldPath))
                {
                    File.Delete(imgOldPath);
                }
            }
        }
    }
}
