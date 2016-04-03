using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OpenWeen.Core.Helper;
using OpenWeen.Core.Model.Status;
using OpenWeen.Core.Model.Types;

namespace OpenWeen.Core.Api.Statuses
{
    public class Query
    {
        /// <summary>
        /// 通过微博（评论、私信）MID获取其ID
        /// </summary>
        /// <param name="type">获取类型，1：微博、2：评论、3：私信，默认为1。</param>
        /// <param name="is_batch">是否使用批量模式，0：否、1：是，默认为0。</param>
        /// <param name="inbox">仅对私信有效，当MID类型为私信时用此参数，0：发件箱、1：收件箱，默认为0 。</param>
        /// <param name="isBase62">MID是否是base62编码，0：否、1：是，默认为0。</param>
        /// <param name="mid">需要查询的微博（评论、私信）MID，批量模式下，用半角逗号分隔，最多不超过20个。</param>
        /// <returns></returns>
        public static async Task<string> QueryID(QueryType type = QueryType.Weibo, bool is_batch = false, DirectMessageType inbox = DirectMessageType.Outbox, bool isBase62 = false, params string[] mid)
        {
            Dictionary<string, string> param = new Dictionary<string, string>()
            {
                { nameof(mid), string.Join(",",mid) },
                { nameof(type), type.ToString("D") },
                { nameof(inbox), inbox.ToString("D") },
                { nameof(isBase62), isBase62 ? "1" : "0" },
                { nameof(is_batch), is_batch ? "1" : "0" },
            };
            return await HttpHelper.GetStringAsync(Constants.QUERY_ID, param);
        }

        /// <summary>
        /// 通过微博（评论、私信）ID获取其MID
        /// </summary>
        /// <param name="type">获取类型，1：微博、2：评论、3：私信，默认为1。</param>
        /// <param name="is_batch">是否使用批量模式，0：否、1：是，默认为0。</param>
        /// <param name="id">需要查询的微博（评论、私信）ID，批量模式下，用半角逗号分隔，最多不超过20个。</param>
        /// <returns></returns>
        public static async Task<string> QueryMID(QueryType type = QueryType.Weibo, bool is_batch = false, params long[] id)
        {
            Dictionary<string, string> param = new Dictionary<string, string>()
            {
                { nameof(id), string.Join(",",id) },
                { nameof(type), type.ToString("D") },
                { nameof(is_batch), is_batch ? "1" : "0" },
            };
            return await HttpHelper.GetStringAsync(Constants.QUERY_MID, param);
        }

        /// <summary>
        /// 根据微博ID获取单条微博内容
        /// </summary>
        /// <param name="id">需要获取的微博ID。</param>
        /// <returns></returns>
        public static async Task<MessageModel> GetStatus(long id)
        {
            Dictionary<string, string> param = new Dictionary<string, string>()
            {
                { nameof(id), id.ToString() },
            };
            return JsonConvert.DeserializeObject<MessageModel>(await HttpHelper.GetStringAsync(Constants.SHOW, param));
        }

        /// <summary>
        /// 根据微博ID批量获取微博信息
        /// </summary>
        /// <param name="ids">需要查询的微博ID，用半角逗号分隔，最多不超过50个。</param>
        /// <returns></returns>
        public static async Task<MessageListModel> GetStatus(params long[] ids)
        {
            Dictionary<string, string> param = new Dictionary<string, string>()
            {
                { nameof(ids), ids.ToString() },
            };
            return JsonConvert.DeserializeObject<MessageListModel>(await HttpHelper.GetStringAsync(Constants.SHOW_BATCH, param));
        }
    }
}