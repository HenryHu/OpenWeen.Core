using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OpenWeen.Core.Helper;
using OpenWeen.Core.Model.Status;

namespace OpenWeen.Core.Api.Statuses
{
    /// <summary>
    /// 屏蔽
    /// </summary>
    public class Filter
    {
        /// <summary>
        /// 屏蔽某条微博
        /// </summary>
        /// <param name="id">微博id。</param>
        /// <returns></returns>
        public static async Task<MessageModel> Create(long id)
        {
            Dictionary<string, HttpContent> param = new Dictionary<string, HttpContent>()
            {
                { nameof(id), new StringContent(id.ToString()) },
            };
            return JsonConvert.DeserializeObject<MessageModel>(await HttpHelper.PostAsync(Constants.FILTER_CREATE, param));
        }
    }
}