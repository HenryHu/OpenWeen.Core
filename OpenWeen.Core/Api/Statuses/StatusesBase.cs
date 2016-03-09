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
    public abstract class StatusesBase
    {
        protected static async Task<MessageListModel> Get(int count, int page, string uri)
        {
            Dictionary<string, string> param = new Dictionary<string, string>()
            {
                { nameof(count), count.ToString() },
                { nameof(page), page.ToString() },
            };
            return JsonConvert.DeserializeObject<MessageListModel>(await HttpHelper.GetStringAsync(uri, param));
        }
    }
}
