using Newtonsoft.Json;
using OpenWeen.Core.Helper;
using OpenWeen.Core.Model;
using OpenWeen.Core.Model.Status;
using OpenWeen.Core.Model.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeen.Core.Api.Statuses
{
    public class Timeline
    {
        /// <summary>
        /// 批量获取指定的一批用户的微博列表
        /// </summary>
        /// <param name="count">单页返回的记录条数，默认为20。</param>
        /// <param name="page">返回结果的页码，默认为1。</param>
        /// <param name="base_app">是否只获取当前应用的数据。0为否（所有数据），1为是（仅当前应用），默认为0。</param>
        /// <param name="feature">过滤类型ID，0：全部、1：原创、2：图片、3：视频、4：音乐，默认为0。</param>
        /// <param name="uids">需要查询的用户ID，用半角逗号分隔，一次最多20个。</param>
        /// <returns></returns>
        public static async Task<MessageListModel> GetTimelineBatch(int count = 20, int page = 1, int base_app = 0, FeatureType feature = FeatureType.All, params string[] uids)
        {
            Dictionary<string, string> param = new Dictionary<string, string>()
            {
                { nameof(uids), string.Join(",", uids) },
                { nameof(count), count.ToString() },
                { nameof(page), page.ToString() },
                { nameof(base_app), base_app.ToString() },
                { nameof(feature), feature.ToString("D") },
            };
            return JsonConvert.DeserializeObject<MessageListModel>(await HttpHelper.GetStringAsync(Constants.TIMELINE_BATCH, param));
        }
    }
}
