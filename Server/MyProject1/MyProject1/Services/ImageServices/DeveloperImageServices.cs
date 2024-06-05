using Microsoft.AspNetCore.Hosting;
using MyProject1.Models.RealStates;

namespace MyProject1.Services.ImageServices
{
    public class DeveloperImageServices : IImageServices<Developer>
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public DeveloperImageServices(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public void SetImage(Developer developer, IFormFile? imgFile)
        {

            if (imgFile == null)
            {
                developer.LogoURL = "\\images\\No_Image.png";
            }
            else
            {
                DeleteImage(developer);
                string imgExtension = Path.GetExtension(imgFile.FileName);
                Guid imgGuid = Guid.NewGuid();
                string imgName = imgGuid + imgExtension;
                string imgUrl = "\\images\\" + imgName;
                developer.LogoURL = imgUrl;

                string imgPath = _webHostEnvironment.WebRootPath + imgUrl;
                using (var imgStream = new FileStream(imgPath, FileMode.Create))
                {
                    imgFile.CopyTo(imgStream);
                }
            }

        }
        public void DeleteImage(Developer developer)
        {
            if (!string.IsNullOrEmpty(developer.LogoURL))
            {
                var imgOldPath = _webHostEnvironment.WebRootPath + developer.LogoURL;
                if (File.Exists(imgOldPath))
                {
                    File.Delete(imgOldPath);
                }
            }
        }
    }

}


