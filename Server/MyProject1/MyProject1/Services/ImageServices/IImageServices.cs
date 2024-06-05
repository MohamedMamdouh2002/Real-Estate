namespace MyProject1.Services.ImageServices
{
    public interface IImageServices<T> where T : class
    {
        public void SetImage(T model, IFormFile? imgFile);
        public void DeleteImage(T model);
    }
}
