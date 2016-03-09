using Newtonsoft.Json;
using OpenWeen.Core.Helper;
using OpenWeen.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeen.Core.Api.Remind
{
    public class Remind
    {
        public static async Task<UnReadModel> GetUnRead(string uid)
        {
            Dictionary<string, string> param = new Dictionary<string, string>()
            {
                { nameof(uid), uid },
                { "unread_message", "0" },
            };
            return JsonConvert.DeserializeObject<UnReadModel>(await HttpHelper.GetStringAsync(Constants.REMIND_UNREAD_COUNT, param));
        }
        public static async Task ClearUnRead(string type)
        {
            Dictionary<string, HttpContent> param = new Dictionary<string, HttpContent>()
            {
                { nameof(type), new StringContent(type) },
            };
            await HttpHelper.PostAsync(Constants.REMIND_UNREAD_SET_COUNT, param);
        }
    }
    public sealed class RemindType
    {
        public static string Follower => "follower";
        public static string Cmt => "cmt";
        public static string Dm => "dm";
        public static string MentionStatus => "mention_status";
        public static string MentionCmt => "mention_cmt";
        public static string Group => "group";
        public static string Notice => "notice";
        public static string Invite => "invite";
        public static string Badge => "badge";
        public static string Photo => "photo";
    }
}
