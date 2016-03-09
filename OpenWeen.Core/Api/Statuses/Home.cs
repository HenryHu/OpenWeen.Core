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
    public class Home : StatusesBase
    {
        public static async Task<MessageListModel> GetTimeline(int count, int page)
            => await Get(count, page, Constants.HOME_TIMELINE);
    }
}
