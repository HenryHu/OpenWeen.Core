using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OpenWeen.Core.Helper
{
    public static class PictureHelper
    {
        public static string ThumbnailToOriginal(string thumb)
        {
            var uri = new Uri(thumb);
            return $"http://{uri.Host}/large/{Regex.Match(thumb, "thumbnail/(.*)\\.").Groups[1].Value}{Path.GetExtension(thumb)}";
        }
        
        public static string GetIDFromThumbnail(string link) => Regex.Match(link, "thumbnail/(.*)\\.").Groups[1].Value;
        
        public static string GetIDFromBmiddle(string link) => Regex.Match(link, "bmiddle/(.*)\\.").Groups[1].Value;
        
        public static string GetIDFromOriginal(string link) => Regex.Match(link, "large/(.*)\\.").Groups[1].Value;
    }
}
