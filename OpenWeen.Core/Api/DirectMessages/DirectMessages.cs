using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenWeen.Core.Helper;
using OpenWeen.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeen.Core.Api.DirectMessages
{
    public class DirectMessages
    {
        public static async Task<DirectMessageUserListModel> GetUserList(int count, int cursor)
        {
            Dictionary<string, string> param = new Dictionary<string, string>()
            {
                { nameof(count), count.ToString() },
                { nameof(cursor), cursor.ToString() }
            };
            return JsonConvert.DeserializeObject<DirectMessageUserListModel>(await HttpHelper.GetStringAsync(Constants.DIRECT_MESSAGES_USER_LIST, param));
        }
        public static async Task<DirectMessageListModel> GetConversation(string uid, int count, int page)
        {
            Dictionary<string, string> param = new Dictionary<string, string>()
            {
                { nameof(uid), uid },
                { nameof(count), count.ToString() },
                { nameof(page), page.ToString() },
            };
            return JsonConvert.DeserializeObject<DirectMessageListModel>(await HttpHelper.GetStringAsync(Constants.DIRECT_MESSAGES_CONVERSATION, param));
        }
        public static async Task<DirectMessageListModel> GetDirectMessages(int count, int page)
        {
            Dictionary<string, string> param = new Dictionary<string, string>()
            {
                { nameof(count), count.ToString() },
                { nameof(page), page.ToString() },
            };
            return JsonConvert.DeserializeObject<DirectMessageListModel>(await HttpHelper.GetStringAsync(Constants.DIRECT_MESSAGES, param));
        }
        public static async Task Send(string uid, string text, string[] fid)
        {
            Dictionary<string, HttpContent> param = new Dictionary<string, HttpContent>()
            {
                { nameof(uid), new StringContent(uid) },
                { nameof(text), new StringContent(text) },
            };
            if (fid.Length > 0)
                param.Add("fids", new StringContent($"{fid[0]}{fid[0]}"));
            await HttpHelper.PostAsync(Constants.DIRECT_MESSAGES_SEND, param);
        }
        public static async Task<string> SendPicture(byte[] pic,string toUid)
        {
            Dictionary<string, HttpContent> param = new Dictionary<string, HttpContent>()
            {
                { "file", new ByteArrayContent(pic) },
            };
            return JsonConvert.DeserializeObject<JObject>(await HttpHelper.PostAsync($"{Constants.DIRECT_MESSAGES_UPLOAD_PIC}{toUid}", param)).Value<string>("fid");
        }
    }
}
