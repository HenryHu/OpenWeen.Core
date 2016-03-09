using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeen.Core.Extension
{
    public static class EncodingExtension
    {
        public static string GetString(this Encoding encoding, byte[] bytes)
            => encoding.GetString(bytes, 0, bytes.Length);
    }
}
