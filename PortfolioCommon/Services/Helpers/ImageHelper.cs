using System;
using System.IO;

namespace PortfolioCommon.Services.Helpers
{
    public static class ImageHelper
    {
        public static void CheckIfPhotoIsValidImage(string file)
        {
            string extension = Path.GetExtension(file).ToLower();
            if (extension == ".png" || extension == ".jpg"
                || extension == ".jpeg" || extension == ".gif"
                || extension == ".jfif") return;
            throw new Exception($"La photo n'est pas au format image valide. ({extension})");
        }
    }
}
