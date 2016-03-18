using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenWeen.Core.Helper;
using OpenWeen.Core.Model;
using OpenWeen.Core.Model.User;

namespace OpenWeen.Core.Api.User
{
    /// <summary>
    /// 用户信息
    /// </summary>
    public class User
    {
        /// <summary>
        /// 根据用户ID获取用户信息
        /// </summary>
        /// <param name="uid">需要查询的用户ID。</param>
        /// <returns></returns>
        public static async Task<UserModel> GetUser(long uid)
        {
            Dictionary<string, string> param = new Dictionary<string, string>()
            {
                { nameof(uid), uid.ToString() }
            };
            return JsonConvert.DeserializeObject<UserModel>((await HttpHelper.GetStringAsync(Constants.USER_SHOW, param)));
        }

        /// <summary>
        /// 根据用户ID获取用户信息
        /// </summary>
        /// <param name="screen_name">需要查询的用户昵称。</param>
        /// <returns></returns>
        public static async Task<UserModel> GetUser(string screen_name)
        {
            Dictionary<string, string> param = new Dictionary<string, string>()
            {
                { nameof(screen_name), screen_name }
            };
            return JsonConvert.DeserializeObject<UserModel>((await HttpHelper.GetStringAsync(Constants.USER_SHOW, param)));
        }
        /// <summary>
        /// 通过个性化域名获取用户资料以及用户最新的一条微博
        /// </summary>
        /// <param name="domain">需要查询的个性化域名。</param>
        /// <returns></returns>
        public static async Task<UserModel> GetUserByDomain(string domain)
        {
            Dictionary<string, string> param = new Dictionary<string, string>()
            {
                { nameof(domain), domain }
            };
            return JsonConvert.DeserializeObject<UserModel>((await HttpHelper.GetStringAsync(Constants.USER_SHOW, param)));
        }

        /// <summary>
        /// 批量获取用户的粉丝数、关注数、微博数
        /// </summary>
        /// <param name="uids">需要获取数据的用户UID，多个之间用逗号分隔，最多不超过100个。</param>
        /// <returns></returns>
        public static async Task<IEnumerable<UserBaseModel>> GetUsersInfo(params string[] uids)
        {
            if (uids.Length > 100)
                throw new ArgumentOutOfRangeException("uids count must lower than 100");
            Dictionary<string, string> param = new Dictionary<string, string>()
            {
                { nameof(uids), string.Join(",", uids) }
            };
            return JsonConvert.DeserializeObject<IEnumerable<UserBaseModel>>(await HttpHelper.GetStringAsync(Constants.USER_COUNTS, param));
        }
    }
}
