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
    public class Repost
    {
        public static async Task<RepostListModel> GetRepost(long id, int count, int page)
        {
            Dictionary<string, string> param = new Dictionary<string, string>()
            {
                { nameof(id), id.ToString() },
                { nameof(count), count.ToString() },
                { nameof(page), page.ToString() },
            };
            return JsonConvert.DeserializeObject<RepostListModel>(await HttpHelper.GetStringAsync(Constants.REPOST_TIMELINE, param));
        }
    }
}
