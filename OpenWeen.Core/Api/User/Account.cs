using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenWeen.Core.Helper;
using OpenWeen.Core.Model;

namespace OpenWeen.Core.Api.User
{
    /// <summary>
    /// 账号信息
    /// </summary>
    public class Account
    {
        /// <summary>
        /// OAuth授权之后，获取授权用户的UID
        /// </summary>
        /// <returns></returns>
        public static async Task<string> GetUid()
            => JsonConvert.DeserializeObject<JObject>(await HttpHelper.GetStringAsync(Constants.GET_UID, null)).Value<string>("uid");//TODO: Check

        /// <summary>
        /// 获取当前登录用户的API访问频率限制情况
        /// </summary>
        /// <returns></returns>
        public static async Task<LimitStatusModel> GetLimitStatus()
            => JsonConvert.DeserializeObject<LimitStatusModel>(await HttpHelper.GetStringAsync(Constants.RATE_LIMIT_STATUS, null));

        /// <summary>
        /// 获取用户的联系邮箱
        /// </summary>
        /// <returns></returns>
        public static async Task<string> GetMail()
            => JsonConvert.DeserializeObject<JArray>(await HttpHelper.GetStringAsync(Constants.GET_UID, null))[0].Value<string>("email");//TODO: Check
    }
}