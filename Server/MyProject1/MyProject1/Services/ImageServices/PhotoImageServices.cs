using MyProject.Models.RealStates;

namespace MyProject1.Services.ImageServices
{
    public class PhotoImageServices : IImageServices<Photo>
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public PhotoImageServices(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public void SetImage(Photo photo, IFormFile? imgFile)
        {

            if (imgFile == null)
            {
                photo.ImgURL = "\\images\\No_Image.png";
            }
            else
            {
                DeleteImage(photo);
                string imgExtension = Path.GetExtension(imgFile.FileName);
                Guid imgGuid = Guid.NewGuid();
                string imgName = imgGuid + imgExtension;
                string imgUrl = "\\images\\" + imgName;
                photo.ImgURL = imgUrl;

                string imgPath = _webHostEnvironment.WebRootPath + imgUrl;
                using (var imgStream = new FileStream(imgPath, FileMode.Create))
                {
                    imgFile.CopyTo(imgStream);
                }
            }

        }
        public void DeleteImage(Photo photo)
        {
            if (!string.IsNullOrEmpty(photo.ImgURL))
            {
                var imgOldPath = _webHostEnvironment.WebRootPath + photo.ImgURL;
                if (File.Exists(imgOldPath))
                {
                    File.Delete(imgOldPath);
                }
            }
        }
    }
}
