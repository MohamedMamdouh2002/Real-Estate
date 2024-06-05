namespace MyProject.Services.Shared
{
    public static class PictureValidation
    {
        private static readonly List<string> _allowedPictureExtensions = new List<string> { ".jepg", ".png" };
        //private static long _maxPictureSize = 209715200;

        public static bool IsPictureValid(IFormFile Picture)
        {
            if (!_allowedPictureExtensions.Contains(Path.GetExtension(Picture.FileName).ToLower()))
                return false;

            //if (Picture.Length > _maxPictureSize)
            //    return false;
            return true;
        }
        public static byte[] ConvertPicture(IFormFile Picture)
        {
            using var DataStream = new MemoryStream();
            Picture.CopyTo(DataStream);
            return DataStream.ToArray();
        }
    }
}
