using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Constants.File
{
    public class ContentTypeHelper
    {
        public static string[] Images { get; } =  { "image/jpg", "image/jpeg", "image/png", "image/heic", "image/svg+xml" };

        public static Dictionary<string, string> ContentTypes { get; } = new Dictionary<string, string>()
        {
            { "pdf", "application/pdf" },
            { "doc", "application/msword" },
            { "docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document" }, //Microsoft Word (OpenXML)
            { "jpg", "image/jpg" },
            { "jpeg", "image/jpeg" },
            { "png", "image/png" },
            { "svg", "image/svg+xml"},
            {"heic", "image/heic" }, // Photo extension in iOS and MacOS
            { "xls", "application/vnd.ms-excel" },
            { "xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" } //Microsoft Excel (OpenXML)
        };

        public static string GetExtensionFromMimetype(string mimeType)
        {
            return ContentTypes.FirstOrDefault(ct => ct.Value == mimeType).Key;
        }

        public static string GetExtensionFromMimetypes(string[] mimeTypes)
        {
            IEnumerable<string> extensions = mimeTypes.Select(mt => ContentTypes.FirstOrDefault(ct => ct.Value == mt).Key);

            return string.Join(", ", extensions);
        }

        public static string GetMimetypeFromExtension(string extension)
        {
            return ContentTypes.FirstOrDefault(ct => ct.Key == extension).Value;
        }
    }
}
