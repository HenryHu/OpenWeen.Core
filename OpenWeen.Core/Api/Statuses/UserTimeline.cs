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

namespace OpenWeen.Core.Api.Statuses
{
    public class UserTimeline
    {
        public static async Task<MessageListModel> GetUserTimeline(string uid, int count, int page, bool orig)
        {
            Dictionary<string, string> param = new Dictionary<string, string>()
            {
                { nameof(uid), uid },
                { nameof(count), count.ToString() },
                { nameof(page), page.ToString() },
                { "feature", (orig?1:0).ToString() },
            };
            return JsonConvert.DeserializeObject<MessageListModel>(await HttpHelper.GetStringAsync(Constants.USER_TIMELINE, param));

        }
    }
}
