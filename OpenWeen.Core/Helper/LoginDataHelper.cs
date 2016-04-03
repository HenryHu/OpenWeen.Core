using System;
using System.Text;
using OpenWeen.Core.Exception;
using OpenWeen.Core.Extension;

using static System.Convert;

namespace OpenWeen.Core.Helper
{
    public static class LoginDataHelper
    {
        private const string START = "SS", SEPERATOR = "::", END = "EE";

        public static string Encode(string id, string secret, string uri, string scope, string pkg)
            => $"{START}{ToBase64String(Encoding.UTF8.GetBytes($"{id}{SEPERATOR}{secret}{SEPERATOR}{uri}{SEPERATOR}{scope}{SEPERATOR}{pkg}{SEPERATOR}{END}"))}";

        /// <summary>
        /// Decode from base64
        /// </summary>
        /// <param name="data">Well, you can jump to <see cref="https://gist.github.com/PeterCxy/3085799055f63c63c911"/></param>
        /// <returns></returns>
        public static string[] Decode(string data)
        {
            if (!CheckData(data))
                throw new InvalidLoginDataException($"{data} is invalid");
            data = data.Substring(START.Length, data.Length - END.Length - 2);
            return Encoding.UTF8.GetString(FromBase64String(data)).Split(new[] { "::" }, StringSplitOptions.RemoveEmptyEntries);
        }

        private static bool CheckData(string data)
            => data.StartsWith(START) && data.Length > START.Length + END.Length && data.EndsWith(END);
    }
}