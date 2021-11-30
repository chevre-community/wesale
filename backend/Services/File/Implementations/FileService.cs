using Core.Services.File.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.File.Implementations
{
    public class FileService : IFileService
    {
        private readonly IConfiguration _configuration;
        private readonly string _uploadDirectory;

        public FileService(IConfiguration configuration)
        {
            _uploadDirectory = configuration.GetSection("UploadDirectory").Value;
        }

        public async Task<string> UploadFileAsync(IFormFile file, string path)
        {
            if (path != null && file != null)
            {
                string unique_filename = Guid.NewGuid() + "_" + file.FileName;

                var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", _uploadDirectory, path);
                if (!Directory.Exists(uploadPath)) Directory.CreateDirectory(uploadPath);

                var filePath = Path.Combine(uploadPath, unique_filename);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                return unique_filename;
            }

            return String.Empty;
        }

        public void Delete(string filename, string path)
        {
            if (filename != null && path != null)
            {
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", _uploadDirectory, path, filename);

                if (System.IO.File.Exists(filePath))
                    System.IO.File.Delete(filePath);
            }

        }

        public string GetFileUrl(string fileName, string path)
        {
            if (fileName != null && path != null)
            {
                return $"/{_uploadDirectory}/{path}/{fileName}";
            }

            return String.Empty;
        }

        public string GetPureFileName(string fileName, bool withExtension = true)
        {
            if (fileName != null)
            {
                if (fileName.Contains("_"))
                {
                    string pureFileName = fileName.Split("_", 2)[1];

                    if (withExtension)
                    {
                        return pureFileName;
                    }

                    return TruncateExtension(pureFileName);
                }

                return fileName;
            }

            return String.Empty;
        }

        public string TruncateExtension(string fileName)
        {
            if (fileName != null)
            {
                return Path.GetFileNameWithoutExtension(fileName);
            }

            return String.Empty;
        }

        public IFormFile GetFile(string fileName, string path)
        {
            if (fileName != null && path != null)
            {
                var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", _uploadDirectory, path, fileName);

                try
                {
                    using (var stream = new FileStream(uploadPath, FileMode.Open, FileAccess.Read))
                    {
                        return new FormFile(stream, 0, stream.Length, "name", GetPureFileName(fileName));
                    }
                }
                catch (Exception)
                {

                    return null;
                }
            }

            return null;
        }

        public double GetFileSize(string fileName, string path, double unitType)
        {
            if (fileName != null && path != null)
            {
                var file = GetFile(fileName, path);

                if (file != null)
                {
                    return Math.Round(file.Length / unitType, 2);
                }
            }

            return 0;
        }
    }
}