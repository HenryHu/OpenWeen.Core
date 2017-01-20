using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenWeen.Core.Helper;
using OpenWeen.Core.Model.Attitude;

namespace OpenWeen.Core.Api
{
    /// <summary>
    /// 点赞
    /// </summary>
    public class Attitudes
    {
        /// <summary>
        /// 点赞
        /// </summary>
        /// <param name="id">微博ID</param>
        /// <returns></returns>
        public static async Task<bool> Like(long id)
        {
            Dictionary<string, HttpContent> param = new Dictionary<string, HttpContent>()
            {
                { "attitude", new StringContent("smile") },
                { nameof(id), new StringContent(id.ToString()) },
            };
            return JsonConvert.DeserializeObject<JObject>(await HttpHelper.PostAsync(Constants.ATTITUDE_CREATE, param)).Value<string>("attitude") == "heart";
        }
        /// <summary>
        /// 取消赞
        /// </summary>
        /// <param name="id">微博ID</param>
        /// <returns></returns>
        public static async Task<bool> UnLike(long id)
        {
            Dictionary<string, HttpContent> param = new Dictionary<string, HttpContent>()
            {
                { nameof(id), new StringContent(id.ToString()) },
            };
            return JsonConvert.DeserializeObject<JObject>(await HttpHelper.PostAsync(Constants.ATTITUDE_DESTROY, param)).Value<bool>("result");
        }
        public static async Task<AttitudeListModel> LikeToMe(bool with_common_attitude = true, bool with_comment = true,long since_id = 0, long max_id = 0, int count = 20, int page = 1) 
        {
            Dictionary<string, string> param = new Dictionary<string, string>()
            {
                { nameof(with_common_attitude), with_common_attitude ? "1" : "0" },
                { nameof(with_comment), with_comment ? "1" : "0" },
                { nameof(since_id), since_id.ToString() },
                { nameof(max_id), max_id.ToString() },
                { nameof(count), count.ToString() },
                { nameof(page), page.ToString() },
                { "source", "211160679" },
                { "from", "1055095010" }
            };
            return JsonConvert.DeserializeObject<AttitudeListModel>(await HttpHelper.GetStringAsync("https://api.weibo.cn/2/like/to_me", param));
        }
    }
}