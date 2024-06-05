using Microsoft.IdentityModel.Tokens;
using MyProject.Models.RealStates;
using MyProject1.Models.RealStates;

namespace MyProject1.Services.ImageServices
{
    public class ImagesOfCompoundServices : IImageServices<CompoundImages>
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ImagesOfCompoundServices(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public void SetImage(CompoundImages compoundImage, IFormFile? imgFile)
        {

            if (imgFile == null)
            {
                compoundImage.ImgURL = "\\images\\No_Image.png";
            }
            else
            {
                DeleteImage(compoundImage);
                string imgExtension = Path.GetExtension(imgFile.FileName);
                Guid imgGuid = Guid.NewGuid();
                string imgName = imgGuid + imgExtension;
                string imgUrl = "\\images\\" + imgName;
                compoundImage.ImgURL = imgUrl;

                string imgPath = _webHostEnvironment.WebRootPath + imgUrl;
                using (var imgStream = new FileStream(imgPath, FileMode.Create))
                {
                    imgFile.CopyTo(imgStream);
                }
            }

        }
        public void DeleteImage(CompoundImages compoundImage)
        {
            if (!string.IsNullOrEmpty(compoundImage.ImgURL))
            {
                var imgOldPath = _webHostEnvironment.WebRootPath + compoundImage.ImgURL;
                if (File.Exists(imgOldPath))
                {
                    File.Delete(imgOldPath);
                }
            }
        }

    }
}
