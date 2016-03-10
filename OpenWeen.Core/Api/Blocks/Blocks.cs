using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenWeen.Core.Helper;
using OpenWeen.Core.Model.Block;
using OpenWeen.Core.Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeen.Core.Api
{
    public class Blocks
    {
        /// <summary>
        /// 获取当前用户黑名单用户列表
        /// </summary>
        /// <param name="count">单页返回的记录条数，默认为50。</param>
        /// <param name="page">返回结果的页码，默认为1。</param>
        /// <returns></returns>
        public static async Task<BlockListModel> GetBlocksList(int count = 50, int page = 1)
        {
            Dictionary<string, string> param = new Dictionary<string, string>()
            {
                { nameof(count), count.ToString() },
                { nameof(page), page.ToString() },
            };
            return JsonConvert.DeserializeObject<BlockListModel>(await HttpHelper.GetStringAsync(Constants.BLOCKS_LIST, param));
        }
        /// <summary>
        /// 将用户添加到黑名单
        /// </summary>
        /// <param name="uid">需要添加进黑名单的用户的UID。</param>
        /// <returns></returns>
        public static async Task<UserModel> AddBlock(long uid)
        {
            Dictionary<string, HttpContent> param = new Dictionary<string, HttpContent>()
            {
                { nameof(uid), new StringContent(uid.ToString()) },
            };
            return JsonConvert.DeserializeObject<UserModel>(await HttpHelper.PostAsync(Constants.BLOCKS_CREATE, param));
        }
        /// <summary>
        /// 将用户从黑名单移除
        /// </summary>
        /// <param name="uid">需要从黑名单移除的用户的UID。</param>
        /// <returns></returns>
        public static async Task<UserModel> RemoveBlock(long uid)
        {
            Dictionary<string, HttpContent> param = new Dictionary<string, HttpContent>()
            {
                { nameof(uid), new StringContent(uid.ToString()) },
            };
            return JsonConvert.DeserializeObject<UserModel>(await HttpHelper.PostAsync(Constants.BLOCKS_DESTROY, param));
        }

        public static async Task<bool> IsBlocked(long uid, bool invert = false)
        {
            Dictionary<string, string> param = new Dictionary<string, string>()
            {
                { nameof(uid), uid.ToString() },
                { nameof(invert), invert ? "0" : "1" },
            };
            return JsonConvert.DeserializeObject<JObject>(await HttpHelper.GetStringAsync(Constants.BLOCKS_LIST, param)).Value<bool>("result");
        }
    }
}
