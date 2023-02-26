namespace AppStore.Helpers
{
    public class ImageHelper
    {
        public static bool IsImage(IFormFile file)
        {
            if (file.ContentType.ToLower() != "image/jpeg" &&
            file.ContentType.ToLower() != "image/jpg" &&
            file.ContentType.ToLower() != "image/png")
            {
                return false;
            }

            return true;
        }
    }
}
