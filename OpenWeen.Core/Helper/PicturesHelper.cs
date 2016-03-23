using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OpenWeen.Core.Helper
{
    public static class PicturesHelper
    {
        public static IEnumerable<string> GetThumbnailPicsFromIDs(params string[] ids)
            => ids.Select(id => GetThumbnailPicFromID(id));

        public static string GetThumbnailPicFromID(string id) => $"http://ww3.sinaimg.cn/thumbnail/{id}.jpg";

        public static string GetIDFromThumbnail(string link) => Regex.Match(link, "http://ww3.sinaimg.cn/thumbnail/(.*).jpg").Groups[1].Value;

        public static IEnumerable<string> GetbBmiddlePicsFromIDs(params string[] ids)
            => ids.Select(id => GetBmiddlePicFromID(id));

        public static string GetBmiddlePicFromID(string id) => $"http://ww3.sinaimg.cn/bmiddle/{id}.jpg";

        public static string GetIDFromBmiddle(string link) => Regex.Match(link, "http://ww3.sinaimg.cn/bmiddle/(.*).jpg").Groups[1].Value;

        public static IEnumerable<string> GetOriginalPicsFromIDs(params string[] ids)
            => ids.Select(id => GetOriginalPicFromID(id));

        public static string GetOriginalPicFromID(string id) => $"http://ww3.sinaimg.cn/large/{id}.jpg";

        public static string GetIDFromOriginal(string link) => Regex.Match(link, "http://ww3.sinaimg.cn/large/(.*).jpg").Groups[1].Value;
    }
}
