using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using OpenWeen.Core.Exception;
using OpenWeen.Core.Helper;
using OpenWeen.Core.Model;

namespace OpenWeen.Core.Api.Statuses
{
    public class Query
    {
        public const int TYPE_STATUS = 1;
        public const int TYPE_COMMENT = 2;
        public const int TYPE_DIRECT_MESSAGE = 3;
        public static async Task<string> QueryID(string mid, int type = TYPE_STATUS)
        {
            Dictionary<string, string> param = new Dictionary<string, string>()
            {
                { nameof(mid), mid },
                { nameof(type), type.ToString() },
                { "isBase62", mid.ToCharArray().All(char.IsDigit)? "0" : "1" },
            };
            return await HttpHelper.GetStringAsync(Constants.QUERY_ID, param);
        }
        public static async Task<string> QueryMID(string id, int type = TYPE_STATUS)
        {
            Dictionary<string, string> param = new Dictionary<string, string>()
            {
                { nameof(id), id },
                { nameof(type), type.ToString() },
            };
            return await HttpHelper.GetStringAsync(Constants.QUERY_MID, param);
        }
        public static async Task<MessageModel> GetStatus(string id)
        {
            if (!id.ToCharArray().All(char.IsDigit))
                id = await QueryID(id);
            if (string.IsNullOrEmpty(id))
                throw new InvalidIDException($"{id} is invalid");
            Dictionary<string, string> param = new Dictionary<string, string>()
            {
                { nameof(id), id },
            };
            return JsonConvert.DeserializeObject<MessageModel>(await HttpHelper.GetStringAsync(Constants.SHOW, param));
        }
    }
}
