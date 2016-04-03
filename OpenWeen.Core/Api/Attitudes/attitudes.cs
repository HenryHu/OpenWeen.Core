using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenWeen.Core.Helper;

namespace OpenWeen.Core.Api
{
    [Obsolete]
    public class Attitudes
    {
        [Obsolete]
        public static async Task<bool> Like(long id)
        {
            Dictionary<string, HttpContent> param = new Dictionary<string, HttpContent>()
            {
                { "attitude", new StringContent("smile") },
                { nameof(id), new StringContent(id.ToString()) },
            };
            return JsonConvert.DeserializeObject<JObject>(await HttpHelper.PostAsync(Constants.ATTITUDE_CREATE, param)).Value<string>("attitude") == "smile";
        }

        [Obsolete]
        public static async Task<bool> UnLike(long id)
        {
            Dictionary<string, HttpContent> param = new Dictionary<string, HttpContent>()
            {
                { nameof(id), new StringContent(id.ToString()) },
            };
            return JsonConvert.DeserializeObject<JObject>(await HttpHelper.PostAsync(Constants.ATTITUDE_DESTROY, param)).Value<bool>("result");
        }
    }
}