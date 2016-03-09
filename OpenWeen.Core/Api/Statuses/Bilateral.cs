using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenWeen.Core.Model;
using OpenWeen.Core.Model.Status;
using Newtonsoft.Json;
using OpenWeen.Core.Helper;
using OpenWeen.Core.Model.Types;

namespace OpenWeen.Core.Api.Statuses
{
    public class Bilateral
    {
        /// <summary>
        /// 获取双向关注用户的最新微博
        /// </summary>
        /// <param name="count">单页返回的记录条数，最大不超过100，默认为20。</param>
        /// <param name="page">返回结果的页码，默认为1。</param>
        /// <param name="max_id">若指定此参数，则返回ID小于或等于max_id的微博，默认为0。</param>
        /// <param name="since_id">若指定此参数，则返回ID比since_id大的微博（即比since_id时间晚的微博），默认为0。</param>
        /// <param name="base_app">是否只获取当前应用的数据。0为否（所有数据），1为是（仅当前应用），默认为0。</param>
        /// <param name="feature">过滤类型ID，0：全部、1：原创、2：图片、3：视频、4：音乐，默认为0。</param>
        /// <param name="trim_user">返回值中user字段开关，0：返回完整user字段、1：user字段仅返回user_id，默认为0。</param>
        /// <returns></returns>
        public static async Task<MessageListModel> GetBilateral(int count = 20, int page = 1, long max_id = 0, long since_id = 0, int base_app = 0, FeatureType feature = FeatureType.All, int trim_user = 0)
        {
            Dictionary<string, string> param = new Dictionary<string, string>()
            {
                { nameof(count), count.ToString() },
                { nameof(page), page.ToString() },
                { nameof(since_id), since_id.ToString() },
                { nameof(max_id), max_id.ToString() },
                { nameof(base_app), base_app.ToString() },
                { nameof(feature), feature.ToString("D") },
                { nameof(trim_user), trim_user.ToString() },//TODO: Change MessageListModel to user_id
            };
            return JsonConvert.DeserializeObject<MessageListModel>(await HttpHelper.GetStringAsync(Constants.BILATERAL_TIMELINE, param));
        }
    }
}
