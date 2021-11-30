using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Core.Extensions.String
{
    public static class StringExtension
    {
        public static T Deserialize<T>(this string content)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            T result;

            using (TextReader reader = new StringReader(content))
            {
                result = (T)serializer.Deserialize(reader);
            }

            return result;
        }

        public static string SlugifyWithId(this string text, object id)
        {
            string str = text.RemoveAccent().ToLower();
            // invalid chars           
            str = Regex.Replace(str, @"[^a-z0-9\s-]", "");
            // convert multiple spaces into one space   
            str = Regex.Replace(str, @"\s+", " ").Trim();
            str = Regex.Replace(str, @"\s", "-"); // hyphens   
            str = $"{str}-{id}";
            return str;
        }

        public static string RemoveAccent(this string txt)
        {
            byte[] bytes = Encoding.GetEncoding("Cyrillic").GetBytes(txt);
            return Encoding.ASCII.GetString(bytes);
        }
    }
}
