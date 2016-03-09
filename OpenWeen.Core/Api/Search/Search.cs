using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenWeen.Core.Helper;
using OpenWeen.Core.Model;
using OpenWeen.Core.Model.Status;
using OpenWeen.Core.Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeen.Core.Api.Search
{
    public class Search
    {
        public static async Task<MessageListModel> SearchStatus(string q, int count, int page)
            => await Searching<MessageListModel>(q, count, page, Constants.SEARCH_STATUSES);

        public static async Task<UserModel> SearchUsers(string q, int count, int page)
            => await Searching<UserModel>(q, count, page, Constants.SEARCH_USERS);

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
