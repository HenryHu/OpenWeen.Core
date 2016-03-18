using Newtonsoft.Json;
using OpenWeen.Core.Helper;
using OpenWeen.Core.Model.Status;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeen.Core.Api.Statuses
{
    /// <summary>
    /// 公共首页
    /// </summary>
    public class Public
    {
        /// <summary>
        /// 返回最新的公共微博
        /// </summary>
        /// <param name="count">单页返回的记录条数，默认为50。</param>
        /// <param name="page">返回结果的页码，默认为1。</param>
        /// <param name="base_app">是否只获取当前应用的数据。0为否（所有数据），1为是（仅当前应用），默认为0。</param>
        /// <returns></returns>
        public static async Task<MessageListModel> GetPublicTimeline(int count = 50, int page = 1, int base_app = 0)
        {
            Dictionary<string, string> param = new Dictionary<string, string>()
            {
                { nameof(count), count.ToString() },
                { nameof(page), page.ToString() },
                { nameof(base_app), base_app.ToString() }
            };
            return JsonConvert.DeserializeObject<MessageListModel>(await HttpHelper.GetStringAsync(Constants.PUBLIC_TIMELINE, param));
        }
    }
}
