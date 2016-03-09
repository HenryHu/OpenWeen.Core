using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenWeen.Core.Helper;
using OpenWeen.Core.Model;

namespace OpenWeen.Core.Api.User
{
    public class User
    {
        public static async Task<UserModel> GetUser(string uid)
        {
            Dictionary<string, string> param = new Dictionary<string, string>()
            {
                { nameof(uid), uid }
            };
            return JsonConvert.DeserializeObject<UserModel>((await HttpHelper.GetStringAsync(Constants.USER_SHOW, param)).Replace("-Weibo", ""));
        }

        public static async Task<UserModel> GetUserByName(string name)
        {
            Dictionary<string, string> param = new Dictionary<string, string>()
            {
                { "screen_name", name }
            };
            return JsonConvert.DeserializeObject<UserModel>((await HttpHelper.GetStringAsync(Constants.USER_SHOW, param)).Replace("-Weibo", ""));
        }
    }
}
