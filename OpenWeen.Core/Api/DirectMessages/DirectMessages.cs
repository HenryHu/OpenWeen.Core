using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenWeen.Core.Model.DirectMessage;
using OpenWeen.Core.Helper;
using OpenWeen.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OpenWeen.Core.Api
{
    /// <summary>
    /// 私信
    /// </summary>
    public class DirectMessages
    {
        /// <summary>
        /// 获取与当前登录用户有私信往来的用户列表，与该用户往来的最新私信
        /// </summary>
        /// <param name="count">单页返回的记录条数，默认为20。</param>
        /// <param name="cursor">返回结果的游标，下一页用返回值里的next_cursor，上一页用previous_cursor，默认为0。</param>
        /// <returns></returns>
        public static async Task<DirectMessageUserListModel> GetUserList(int count = 20, int cursor = 0)
        {
            Dictionary<string, string> param = new Dictionary<string, string>()
            {
                { nameof(count), count.ToString() },
                { nameof(cursor), cursor.ToString() }
            };
            return JsonConvert.DeserializeObject<DirectMessageUserListModel>(await HttpHelper.GetStringAsync(Constants.DIRECT_MESSAGES_USER_LIST, param));
        }

        /// <summary>
        /// 获取与指定用户的往来私信列表
        /// </summary>
        /// <param name="uid">需要查询的用户的UID。</param>
        /// <param name="since_id">若指定此参数，则返回ID比since_id大的私信（即比since_id时间晚的私信），默认为0。</param>
        /// <param name="max_id">若指定此参数，则返回ID小于或等于max_id的私信，默认为0。</param>
        /// <param name="count">单页返回的记录条数，默认为20。</param>
        /// <param name="page">返回结果的页码，默认为1。</param>
        /// <returns></returns>
        public static async Task<DirectMessageListModel> GetConversation(string uid, long since_id = 0, long max_id = 0, int count = 20, int page = 1)
        {
            Dictionary<string, string> param = new Dictionary<string, string>()
            {
                { nameof(uid), uid },
                { nameof(count), count.ToString() },
                { nameof(page), page.ToString() },
            };
            return JsonConvert.DeserializeObject<DirectMessageListModel>(await HttpHelper.GetStringAsync(Constants.DIRECT_MESSAGES_CONVERSATION, param));
        }
        /// <summary>
        /// 获取当前登录用户收到的最新私信列表
        /// </summary>
        /// <param name="since_id">若指定此参数，则返回ID比since_id大的私信（即比since_id时间晚的私信），默认为0。</param>
        /// <param name="max_id">若指定此参数，则返回ID小于或等于max_id的私信，默认为0。</param>
        /// <param name="count">单页返回的记录条数，默认为20。</param>
        /// <param name="page">返回结果的页码，默认为1。</param>
        /// <returns></returns>
        public static async Task<DirectMessageListModel> GetDirectMessages(long since_id = 0, long max_id = 0, int count = 20, int page = 1)
        {
            Dictionary<string, string> param = new Dictionary<string, string>()
            {
                { nameof(since_id), since_id.ToString() },
                { nameof(max_id), max_id.ToString() },
                { nameof(count), count.ToString() },
                { nameof(page), page.ToString() },
            };
            return JsonConvert.DeserializeObject<DirectMessageListModel>(await HttpHelper.GetStringAsync(Constants.DIRECT_MESSAGES, param));
        }

        /// <summary>
        /// 发送一条私信【该接口已停止开放】
        /// </summary>
        /// <param name="uid">私信接收方的用户UID。</param>
        /// <param name="text">要发送的私信内容，需要做URLencode，内容小于300个汉字。</param>
        /// <param name="id">需要发送的微博ID。</param>
        /// <returns></returns>
        public static async Task Send(long uid, string text, long id)
        {
            Dictionary<string, HttpContent> param = new Dictionary<string, HttpContent>()
            {
                { nameof(uid), new StringContent(uid.ToString()) },
                { nameof(text), new StringContent(text) },
                { nameof(id), new StringContent(id.ToString()) },
            };
            await HttpHelper.PostAsync(Constants.DIRECT_MESSAGES_SEND, param);
        }
        /// <summary>
        /// 发送一条私信【该接口已停止开放】
        /// </summary>
        /// <param name="screen_name">私信接收方的微博昵称。</param>
        /// <param name="text">要发送的私信内容，需要做URLencode，内容小于300个汉字。</param>
        /// <param name="id">需要发送的微博ID。</param>
        /// <returns></returns>
        public static async Task Send(string screen_name, string text, long id)
        {
            Dictionary<string, HttpContent> param = new Dictionary<string, HttpContent>()
            {
                { nameof(screen_name), new StringContent(screen_name) },
                { nameof(text), new StringContent(text) },
                { nameof(id), new StringContent(id.ToString()) },
            };
            await HttpHelper.PostAsync(Constants.DIRECT_MESSAGES_SEND, param);
        }
        public static async Task<string> SendPicture(byte[] pic,string toUid)
        {
            Dictionary<string, HttpContent> param = new Dictionary<string, HttpContent>()
            {
                { "file", new StreamContent(new MemoryStream(pic)) },
            };
            return JsonConvert.DeserializeObject<JObject>(await HttpHelper.PostAsync($"{Constants.DIRECT_MESSAGES_UPLOAD_PIC}{toUid}", param)).Value<string>("fid");
        }
    }
}
