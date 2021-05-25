using System;
using System.IO;
using USend.UserApi.Application.Interfaces;

namespace USend.UserApi.Application.Services
{
    public class ImageService : IImageService
    {
        private readonly INotificationContext _notification;
        private readonly string _defaultPath = $"{Directory.GetCurrentDirectory()}\\UserImages";

        public ImageService(INotificationContext notification)
        {
            _notification = notification;
        }

        public void WriteFileOnDisk(string base64File, string fileName)
        {
            if (string.IsNullOrEmpty(base64File) || string.IsNullOrEmpty(fileName))
                return;
            try
            {
                Directory.CreateDirectory(_defaultPath);
                var filePath = $"{_defaultPath}\\{fileName}.jpg";
                byte[] bytes = null;
                try
                {
                    bytes = Convert.FromBase64String(base64File);
                }
                catch (Exception)
                {
                    _notification.AddNotification("Invalid base64 image!");
                    return;
                }

                using var imageFile = new FileStream(filePath, FileMode.Create);
                imageFile.Write(bytes, 0, bytes.Length);
                imageFile.Flush();
            }
            catch (Exception)
            {
                _notification.AddNotification("Error on writing image. Try again!");
            }
        }

        public string FindImageUrl(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                return null;

            var filePath = $"{_defaultPath}\\{fileName}.jpg";
            if (File.Exists(filePath))
                return filePath;

            return null;
        }
    }
}
