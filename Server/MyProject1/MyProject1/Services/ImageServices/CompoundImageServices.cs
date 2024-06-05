using MyProject.Models.RealStates;

namespace MyProject1.Services.ImageServices
{
    public class CompoundImageServices : IImageServices<Compound>
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CompoundImageServices(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public void SetImage(Compound compound, IFormFile? imgFile)
        {

            if (imgFile == null)
            {
                compound.MasterPlanURL = "\\images\\No_Image.png";
            }
            else
            {
                DeleteImage(compound);
                string imgExtension = Path.GetExtension(imgFile.FileName);
                Guid imgGuid = Guid.NewGuid();
                string imgName = imgGuid + imgExtension;
                string imgUrl = "\\images\\" + imgName;
                compound.MasterPlanURL = imgUrl;

                string imgPath = _webHostEnvironment.WebRootPath + imgUrl;
                using (var imgStream = new FileStream(imgPath, FileMode.Create))
                {
                    imgFile.CopyTo(imgStream);
                }
            }

        }
        public void DeleteImage(Compound compound)
        {
            if (!string.IsNullOrEmpty(compound.MasterPlanURL))
            {
                var imgOldPath = _webHostEnvironment.WebRootPath + compound.MasterPlanURL;
                if (File.Exists(imgOldPath))
                {
                    File.Delete(imgOldPath);
                }
            }
        }

    }
}
