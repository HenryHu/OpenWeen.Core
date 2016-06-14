using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OpenWeen.Core.Helper;
using OpenWeen.Core.Model.Status;
using OpenWeen.Core.Model.Types;
using System.Linq;
using OpenWeen.Core.Model;

namespace OpenWeen.Core.Api.Statuses
{
    /// <summary>
    /// 主页
    /// </summary>
    public class Home
    {
        private const string PATTERN = "http://t.cn/([A-Z_a-z][A-Z_a-z0-9]*)";

        /// <summary>
        /// 获取当前登录用户及其所关注（授权）用户的最新微博
        /// </summary>
        /// <param name="count">单页返回的记录条数，最大不超过100，默认为20。</param>
        /// <param name="page">返回结果的页码，默认为1。</param>
        /// <param name="max_id">若指定此参数，则返回ID小于或等于max_id的微博，默认为0。</param>
        /// <param name="since_id">若指定此参数，则返回ID比since_id大的微博（即比since_id时间晚的微博），默认为0。</param>
        /// <param name="base_app">是否只获取当前应用的数据。0为否（所有数据），1为是（仅当前应用），默认为0。</param>
        /// <param name="feature">过滤类型ID，0：全部、1：原创、2：图片、3：视频、4：音乐，默认为0。</param>
        /// <param name="trim_user">返回值中user字段开关，0：返回完整user字段、1：user字段仅返回user_id，默认为0。</param>
        /// <returns></returns>
        public static async Task<MessageListModel> GetTimeline(int count = 20, int page = 1, long max_id = 0, long since_id = 0, int base_app = 0, FeatureType feature = FeatureType.All, int trim_user = 0)
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
                { "from","1055095010" },
                { "source", "1" }
            };
            var item = JsonConvert.DeserializeObject<MessageListModel>(await HttpHelper.GetStringAsync(Constants.HOME_TIMELINE, param));
            item.Statuses = (await Task.WhenAll(item.Statuses.Select(async s => await GetUrlInfo(s)))).ToList();
            return item;
        }

        private static async Task<MessageModel> GetUrlInfo(MessageModel status)
        {
            if (status.UrlStruct != null || !Regex.IsMatch(status.Text, PATTERN))
            {
                if (status.RetweetedStatus != null)
                    status.RetweetedStatus = await GetUrlInfo(status.RetweetedStatus);
                return status;
            }
            var matches = Regex.Matches(status.Text, PATTERN);
            UrlInfoListModel result;
            try
            {
                result = await ShortUrl.Info(matches.Cast<Match>().Select(m => m.Value).ToArray());
                status.UrlStruct = result.Urls.Select(item => new UrlStructModel() { Type = (item.AnnotationList?.FirstOrDefault() ?? item.Annotations)?.Item?.ObjectType, UrlTitle = (item.AnnotationList?.FirstOrDefault() ?? item.Annotations)?.Item?.DisplayName, ShortUrl = item.UrlShort, PicIds = (item.AnnotationList?.FirstOrDefault() ?? item.Annotations)?.Item?.PicIds, OriUrl = (item.AnnotationList?.FirstOrDefault() ?? item.Annotations)?.Item?.Url }).ToArray();
            }
            catch (System.Exception)
            {
            }
            if (status.RetweetedStatus != null)
                status.RetweetedStatus = await GetUrlInfo(status.RetweetedStatus);
            return status;
        }
    }
}