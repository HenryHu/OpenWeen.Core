using Newtonsoft.Json;
using OpenWeen.Core.Helper;
using OpenWeen.Core.Model;
using OpenWeen.Core.Model.Status;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeen.Core.Api.Search
{
    public class Topics
    {
        public static async Task<MessageListModel> GetSearchTopics(string q, int count, int page)
        {
            Dictionary<string, string> param = new Dictionary<string, string>()
            {
                { nameof(q), q},
                { nameof(count), count.ToString() },
                { nameof(page), page.ToString() },
            };
            return JsonConvert.DeserializeObject<MessageListModel>(await HttpHelper.GetStringAsync(Constants.SEARCH_TOPICS, param));
        }
    }
}
