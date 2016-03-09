using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using OpenWeen.Core.Helper;
using OpenWeen.Core.Model;
using OpenWeen.Core.Model.Status;
using OpenWeen.Core.Model.Types;

namespace OpenWeen.Core.Api.Statuses
{
    public class Mentions
    {
        /// <summary>
        /// 获取最新的提到登录用户的微博列表，即@我的微博
        /// </summary>
        /// <param name="since_id">若指定此参数，则返回ID比since_id大的微博（即比since_id时间晚的微博），默认为0。</param>
        /// <param name="max_id">若指定此参数，则返回ID小于或等于max_id的微博，默认为0。</param>
        /// <param name="count">单页返回的记录条数，最大不超过200，默认为20。</param>
        /// <param name="page">返回结果的页码，默认为1。</param>
        /// <param name="filter_by_author">作者筛选类型，0：全部、1：我关注的人、2：陌生人，默认为0。</param>
        /// <param name="filter_by_source">来源筛选类型，0：全部、1：来自微博、2：来自微群，默认为0。</param>
        /// <param name="filter_by_type">原创筛选类型，0：全部微博、1：原创的微博，默认为0。</param>
        /// <returns></returns>
        public static async Task<MessageListModel> GetMentions(long since_id = 0, long max_id = 0, int count = 20, int page = 1, AuthorType filter_by_author = AuthorType.All, SourceType filter_by_source = SourceType.All, FeatureType filter_by_type = FeatureType.All)
        {
            Dictionary<string, string> param = new Dictionary<string, string>()
            {
                { nameof(since_id), since_id.ToString() },
                { nameof(max_id), max_id.ToString() },
                { nameof(count), count.ToString() },
                { nameof(page), page.ToString() },
                { nameof(filter_by_author), filter_by_author.ToString("D") },
                { nameof(filter_by_source), filter_by_source.ToString("D") },
                { nameof(filter_by_type), filter_by_type.ToString("D") },
            };
            return JsonConvert.DeserializeObject<MessageListModel>(await HttpHelper.GetStringAsync(Constants.MENTIONS, param));
        }
    }
}
