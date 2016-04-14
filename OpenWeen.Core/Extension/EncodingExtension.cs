using System.Text;

namespace OpenWeen.Core.Extension
{
    internal static class EncodingExtension
    {
        public static string GetString(this Encoding encoding, byte[] bytes)
            => encoding.GetString(bytes, 0, bytes.Length);
    }
}