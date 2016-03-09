using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using OpenWeen.Core.Helper;
using OpenWeen.Core.Model;

namespace OpenWeen.Core.Api.Statuses
{
    public class Mentions : StatusesBase
    {
        public static async Task<MessageListModel> GetMentions(int count, int page)
            => await Get(count, page, Constants.MENTIONS);

        public static async Task<MessageListModel> GetMentionsSince(long id)
        {
            Dictionary<string, string> param = new Dictionary<string, string>()
            {
                { "since_id", id.ToString() },
            };
            return JsonConvert.DeserializeObject<MessageListModel>(await HttpHelper.GetStringAsync(Constants.MENTIONS, param));
        }

    }
}
