using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.File.Abstractions
{
    public interface IFileService
    {
        Task<string> UploadFileAsync(IFormFile file, string path);
        void Delete(string filename, string path);
        string GetFileUrl(string fileName, string path);
        string GetPureFileName(string fileName, bool withExtension = true);
        IFormFile GetFile(string fileName, string path);
        double GetFileSize(string fileName, string path, double unitType);
        string TruncateExtension(string fileName);
    }
}
