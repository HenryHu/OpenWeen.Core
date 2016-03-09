using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenWeen.Core.Helper;

namespace OpenWeen.Core.Api.User
{
    public class Account
    {
        public static async Task<string> GetUid()
            => JsonConvert.DeserializeObject<JObject>(await HttpHelper.GetStringAsync(Constants.GET_UID, null)).Value<string>("uid");//TODO: Check
    }
}
