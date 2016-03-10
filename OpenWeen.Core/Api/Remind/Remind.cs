using Newtonsoft.Json;
using OpenWeen.Core.Helper;
using OpenWeen.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeen.Core.Api
{
    public class Remind
    {
        /// <summary>
        /// 获取某个用户的各种消息未读数
        /// </summary>
        /// <param name="uid">需要获取消息未读数的用户UID，必须是当前登录用户。</param>
        /// <returns></returns>
        public static async Task<UnReadModel> GetUnRead(string uid)
        {
            Dictionary<string, string> param = new Dictionary<string, string>()
            {
                { nameof(uid), uid },
                { "unread_message", "0" },
            };
            return JsonConvert.DeserializeObject<UnReadModel>(await HttpHelper.GetStringAsync(Constants.REMIND_UNREAD_COUNT, param));
        }
        /// <summary>
        /// 对当前登录用户某一种消息未读数进行清零
        /// </summary>
        /// <param name="type">可以通过<see cref="RemindType"/>设置，需要设置未读数计数的消息项，follower：新粉丝数、cmt：新评论数、dm：新私信数、mention_status：新提及我的微博数、mention_cmt：新提及我的评论数、group：微群消息数、notice：新通知数、invite：新邀请数、badge：新勋章数、photo：相册消息数、close_friends_feeds：密友feeds未读数、close_friends_mention_status：密友提及我的微博未读数、close_friends_mention_cmt：密友提及我的评论未读数、close_friends_cmt：密友评论未读数、close_friends_attitude：密友表态未读数、close_friends_common_cmt：密友共同评论未读数、close_friends_invite：密友邀请未读数，一次只能操作一项。</param>
        /// <returns></returns>
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
