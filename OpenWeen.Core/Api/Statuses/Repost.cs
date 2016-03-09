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
    public class Repost
    {
        /// <summary>
        /// 获取指定微博的转发微博列表
        /// </summary>
        /// <param name="id">需要查询的微博ID。</param>
        /// <param name="since_id">若指定此参数，则返回ID比since_id大的微博（即比since_id时间晚的微博），默认为0。</param>
        /// <param name="max_id">若指定此参数，则返回ID小于或等于max_id的微博，默认为0。</param>
        /// <param name="count">单页返回的记录条数，最大不超过200，默认为20。</param>
        /// <param name="page">返回结果的页码，默认为1。</param>
        /// <param name="filter_by_author">作者筛选类型，0：全部、1：我关注的人、2：陌生人，默认为0。</param>
        /// <returns></returns>
        public static async Task<RepostListModel> GetRepost(long id, long since_id = 0, long max_id = 0, int count = 20, int page = 1, AuthorType filter_by_author = AuthorType.All)
        {
            Dictionary<string, string> param = new Dictionary<string, string>()
            {
                { nameof(id), id.ToString() },
                { nameof(since_id), since_id.ToString() },
                { nameof(max_id), max_id.ToString() },
                { nameof(count), count.ToString() },
                { nameof(page), page.ToString() },
                { nameof(filter_by_author), filter_by_author.ToString("D") },
            };
            return JsonConvert.DeserializeObject<RepostListModel>(await HttpHelper.GetStringAsync(Constants.REPOST_TIMELINE, param));
        }
    }
}
