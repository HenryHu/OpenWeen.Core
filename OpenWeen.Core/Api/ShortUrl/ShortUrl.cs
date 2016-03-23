using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenWeen.Core.Exception;
using OpenWeen.Core.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeen.Core.Api
{
    /// <summary>
    /// 短链接
    /// </summary>
    public class ShortUrl
    {
        /// <summary>
        /// 将长链接转换成短链接
        /// </summary>
        /// <param name="url">需要转换的长链接</param>
        /// <returns></returns>
        public static async Task<string> Shorten(string url)
        {
            Dictionary<string, string> param = new Dictionary<string, string>()
            {
                { "url_long", url},
            };
            var res = JsonConvert.DeserializeObject<JObject>(await HttpHelper.GetStringAsync(Constants.SHORT_URL_SHORTEN, param)).Value<JArray>("urls")[0];
            if (res.Value<bool>("result"))
                return res.Value<string>("url_short");
            else
                throw new ShortUrlException($"Can not shorten {url}");
        }
        /// <summary>
        /// 将短链接还原成原始的长链接
        /// </summary>
        /// <param name="url">	需要还原的短链接</param>
        /// <returns></returns>
        public static async Task<string> Expand(string url)
        {
            Dictionary<string, string> param = new Dictionary<string, string>()
            {
                { "url_short", url},
            };
            var res = JsonConvert.DeserializeObject<JObject>(await HttpHelper.GetStringAsync(Constants.SHORT_URL_EXPAND, param)).Value<JArray>("urls")[0];
            if (res.Value<bool>("result"))
                return res.Value<string>("url_long");
            else
                throw new ShortUrlException($"Can not expand {url}");
        }
    }
}
