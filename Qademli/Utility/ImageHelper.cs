using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace Qademli.Utility
{
    public static class ImageHelper
    {
        public static string UploadImageFile(IWebHostEnvironment hostEnvironment, string path, IFormFile file)
        {
            string uniqueFileName = null;

            if (file.FileName != null)
            {
                string uploadsFolder = Path.Combine(hostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
            }
            uniqueFileName = Path.Combine("/images/", uniqueFileName);
            return uniqueFileName;
        }
       
        public static bool DeleteImage(IWebHostEnvironment hostEnvironment,string pathName,string fileName)
        {
            string webRootPath = hostEnvironment.WebRootPath;
            var upload = Path.Combine(webRootPath, "images");
            string NewFileName = fileName.Replace("/images/", "") ;
            string pathToSave =Path.Combine(upload, NewFileName);
            if (File.Exists(pathToSave))
            {
                File.Delete(pathToSave);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
