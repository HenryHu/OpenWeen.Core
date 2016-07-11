using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OpenWeen.Core.Helper;
using OpenWeen.Core.Model.Status;
using OpenWeen.Core.Model.Types;

namespace OpenWeen.Core.Api.Statuses
{
    /// <summary>
    /// 指定用户微博列表
    /// </summary>
    public class UserTimeline
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

        /// <summary>
        /// 获取某个用户最新发表的微博列表
        /// </summary>
        /// <param name="uid">需要查询的用户ID。</param>
        /// <param name="count">单页返回的记录条数，最大不超过100，超过100以100处理，默认为20。</param>
        /// <param name="page">返回结果的页码，默认为1。</param>
        /// <param name="max_id">若指定此参数，则返回ID小于或等于max_id的微博，默认为0。</param>
        /// <param name="since_id">若指定此参数，则返回ID比since_id大的微博（即比since_id时间晚的微博），默认为0。</param>
        /// <param name="base_app">是否只获取当前应用的数据。0为否（所有数据），1为是（仅当前应用），默认为0。</param>
        /// <param name="feature">过滤类型ID，0：全部、1：原创、2：图片、3：视频、4：音乐，默认为0。</param>
        /// <param name="trim_user">返回值中user字段开关，0：返回完整user字段、1：user字段仅返回user_id，默认为0。</param>
        /// <returns></returns>
        public static async Task<MessageListModel> GetUserTimeline(long uid, int count = 20, int page = 1, long max_id = 0, long since_id = 0, int base_app = 0, FeatureType feature = FeatureType.All, int trim_user = 0)
        {
            Dictionary<string, string> param = new Dictionary<string, string>()
            {
                { nameof(uid), uid.ToString() },
                { nameof(count), count.ToString() },
                { nameof(page), page.ToString() },
                { nameof(since_id), since_id.ToString() },
                { nameof(max_id), max_id.ToString() },
                { nameof(base_app), base_app.ToString() },
                { nameof(feature), feature.ToString("D") },
                { nameof(trim_user), trim_user.ToString() },//TODO: Change MessageListModel to user_id
            };
            return JsonConvert.DeserializeObject<MessageListModel>(await HttpHelper.GetStringAsync(Constants.USER_TIMELINE, param));
        }

        /// <summary>
        /// 获取某个用户最新发表的微博列表
        /// </summary>
        /// <param name="screen_name">需要查询的用户昵称。</param>
        /// <param name="count">单页返回的记录条数，最大不超过100，超过100以100处理，默认为20。</param>
        /// <param name="page">返回结果的页码，默认为1。</param>
        /// <param name="max_id">若指定此参数，则返回ID小于或等于max_id的微博，默认为0。</param>
        /// <param name="since_id">若指定此参数，则返回ID比since_id大的微博（即比since_id时间晚的微博），默认为0。</param>
        /// <param name="base_app">是否只获取当前应用的数据。0为否（所有数据），1为是（仅当前应用），默认为0。</param>
        /// <param name="feature">过滤类型ID，0：全部、1：原创、2：图片、3：视频、4：音乐，默认为0。</param>
        /// <param name="trim_user">返回值中user字段开关，0：返回完整user字段、1：user字段仅返回user_id，默认为0。</param>
        /// <returns></returns>
        public static async Task<MessageListModel> GetUserTimeline(string screen_name, int count = 20, int page = 1, long max_id = 0, long since_id = 0, int base_app = 0, FeatureType feature = FeatureType.All, int trim_user = 0)
        {
            Dictionary<string, string> param = new Dictionary<string, string>()
            {
                { nameof(screen_name), screen_name },
                { nameof(count), count.ToString() },
                { nameof(page), page.ToString() },
                { nameof(since_id), since_id.ToString() },
                { nameof(max_id), max_id.ToString() },
                { nameof(base_app), base_app.ToString() },
                { nameof(feature), feature.ToString("D") },
                { nameof(trim_user), trim_user.ToString() },//TODO: Change MessageListModel to user_id
            };
            return JsonConvert.DeserializeObject<MessageListModel>(await HttpHelper.GetStringAsync(Constants.USER_TIMELINE, param));
        }
    }
}