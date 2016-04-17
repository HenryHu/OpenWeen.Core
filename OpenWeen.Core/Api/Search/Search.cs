using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenWeen.Core.Helper;
using OpenWeen.Core.Model.Status;
using OpenWeen.Core.Model.User;

namespace OpenWeen.Core.Api.Search
{
    /// <summary>
    /// 搜索
    /// </summary>
    public class Search
    {
        /// <summary>
        /// 搜索与指定的一个或多个条件相匹配的微博
        /// </summary>
        /// <param name="q">搜索的关键字</param>
        /// <param name="count">单页返回的记录条数，默认为10，最大为50。</param>
        /// <param name="page">返回结果的页码，默认为1。</param>
        /// <returns></returns>
        public static async Task<MessageListModel> SearchStatus(string q, int count = 10, int page = 1)
            => await Searching<MessageListModel>(q, count, page, Constants.SEARCH_STATUSES);

        /// <summary>
        /// 通过关键词搜索用户
        /// </summary>
        /// <param name="q">搜索的关键字</param>
        /// <param name="count">单页返回的记录条数，默认为10，最大为50。</param>
        /// <param name="page">返回结果的页码，默认为1。</param>
        /// <returns></returns>
        public static async Task<UserListModel> SearchUsers(string q, int count = 10, int page = 1)
            => await Searching<UserListModel>(q, count, page, Constants.SEARCH_USERS);

        private static async Task<T> Searching<T>(string q, int count, int page, string uri)
        {
            Dictionary<string, string> param = new Dictionary<string, string>()
            {
                { nameof(q), q},
                { nameof(count), count.ToString() },
                { nameof(page), page.ToString() },
            };
            return JsonConvert.DeserializeObject<T>(await HttpHelper.GetStringAsync(uri, param));
        }

        public static async Task<IEnumerable<string>> SuggestAtUser(string q, int count)
        {
            Dictionary<string, string> param = new Dictionary<string, string>()
            {
                { nameof(q), q},
                { nameof(count), count.ToString() },
                { "type", "0" },
                { "range", "0" },
            };
            return JsonConvert.DeserializeObject<JArray>(await HttpHelper.GetStringAsync(Constants.SEARCH_SUGGESTIONS_AT_USERS, param)).Select(item => item.Value<string>("nickname"));
        }
    }
}