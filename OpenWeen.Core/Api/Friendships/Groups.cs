using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenWeen.Core.Helper;
using OpenWeen.Core.Model;
using OpenWeen.Core.Model.Status;
using OpenWeen.Core.Model.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeen.Core.Api.Friendships
{
    /// <summary>
    /// 分组
    /// </summary>
    public class Groups
    {
        /// <summary>
        /// 获取当前登陆用户好友分组列表
        /// </summary>
        /// <returns></returns>
        public static async Task<GroupListModel> GetGroups()
            => JsonConvert.DeserializeObject<GroupListModel>(await HttpHelper.GetStringAsync(Constants.FRIENDSHIPS_GROUPS, null));
        /// <summary>
        /// 判断某个用户是否是当前登录用户指定好友分组内的成员
        /// </summary>
        /// <param name="uid">需要判断的用户的UID。</param>
        /// <param name="list_id">指定的当前用户的好友分组ID，建议使用返回值里的idstr。</param>
        /// <returns></returns>
        public static async Task<bool> IsMember(string uid, string list_id)
        {
            Dictionary<string, string> param = new Dictionary<string, string>()
            {
                { nameof(uid), uid },
                { nameof(list_id), list_id },
            };
            return JsonConvert.DeserializeObject<JObject>(await HttpHelper.GetStringAsync(Constants.FRIENDSHIPS_GROUPS_IS_MEMBER, param)).Value<bool>("lists");
        }
        /// <summary>
        /// 获取当前登录用户某一好友分组的微博列表
        /// </summary>
        /// <param name="list_id">需要查询的好友分组ID，建议使用返回值里的idstr，当查询的为私有分组时，则当前登录用户必须为其所有者。</param>
        /// <param name="since_id">若指定此参数，则返回ID比since_id大的微博（即比since_id时间晚的微博），默认为0。</param>
        /// <param name="max_id">若指定此参数，则返回ID小于或等于max_id的微博，默认为0。</param>
        /// <param name="count">单页返回的记录条数，最大不超过200，默认为50。</param>
        /// <param name="page">返回结果的页码，默认为1。</param>
        /// <param name="feature">过滤类型ID，0：全部、1：原创、2：图片、3：视频、4：音乐，默认为0。</param>
        /// <returns></returns>
        public static async Task<MessageListModel> GetGroupTimeline(string list_id, long since_id = 0,long max_id = 0, int count = 50, int page = 1, FeatureType feature = FeatureType.All)
        {
            Dictionary<string, string> param = new Dictionary<string, string>()
            {
                { nameof(list_id), list_id },
                { nameof(count), count.ToString() },
                { nameof(page), page.ToString() },
                { nameof(since_id), since_id.ToString() },
                { nameof(max_id), max_id.ToString() },
                { nameof(feature), feature.ToString("D") },
            };
            return JsonConvert.DeserializeObject<MessageListModel>(await HttpHelper.GetStringAsync(Constants.FRIENDSHIPS_GROUPS_TIMELINE, param));
        }
        /// <summary>
        /// 添加关注用户到好友分组
        /// </summary>
        /// <param name="uid">需要添加的用户的UID。</param>
        /// <param name="list_id">好友分组ID，建议使用返回值里的idstr。</param>
        /// <returns></returns>
        public static async Task<GroupModel> AddToGroup(string uid, string list_id)
        {
            Dictionary<string, HttpContent> param = new Dictionary<string, HttpContent>()
            {
                { nameof(uid), new StringContent(uid) },
                { nameof(list_id), new StringContent(list_id) },
            };
            return JsonConvert.DeserializeObject<GroupModel>(await HttpHelper.PostAsync(Constants.FRIENDSHIPS_GROUPS_MEMBERS_ADD, param));
        }
        /// <summary>
        /// 删除好友分组内的关注用户
        /// </summary>
        /// <param name="uid">需要删除的用户的UID。</param>
        /// <param name="list_id">好友分组ID，建议使用返回值里的idstr。</param>
        /// <returns></returns>
        public static async Task<GroupModel> RemoveFromGroup(string uid, string list_id)
        {
            Dictionary<string, HttpContent> param = new Dictionary<string, HttpContent>()
            {
                { nameof(uid), new StringContent(uid) },
                { nameof(list_id), new StringContent(list_id) },
            };
            return JsonConvert.DeserializeObject<GroupModel>(await HttpHelper.PostAsync(Constants.FRIENDSHIPS_GROUPS_MEMBERS_DESTROY, param));
        }
        /// <summary>
        /// 创建好友分组
        /// </summary>
        /// <param name="name">要创建的好友分组的名称，不超过10个汉字，20个半角字符。</param>
        /// <param name="description">要创建的好友分组的描述，不超过70个汉字，140个半角字符。</param>
        /// <param name="tags">要创建的好友分组的标签，多个之间用逗号分隔，最多不超过10个，每个不超过7个汉字，14个半角字符。</param>
        /// <returns></returns>
        public static async Task<GroupModel> CreateGroup(string name, string description = "", params string[] tags)
        {
            Dictionary<string, HttpContent> param = new Dictionary<string, HttpContent>()
            {
                { nameof(name), new StringContent(name) }
            };
            if (!string.IsNullOrEmpty(description))
                param.Add(nameof(description), new StringContent(description));
            if (tags?.Length > 0)
                param.Add(nameof(tags), new StringContent(string.Join(",", tags)));
            return JsonConvert.DeserializeObject<GroupModel>(await HttpHelper.PostAsync(Constants.FRIENDSHIPS_GROUPS_CREATE, param))    ;
        }

        /// <summary>
        /// 删除好友分组
        /// </summary>
        /// <param name="list_id">要删除的好友分组ID，建议使用返回值里的idstr。</param>
        /// <returns></returns>
        public static async Task<GroupModel> DeleteGroup(string list_id)
        {
            Dictionary<string, HttpContent> param = new Dictionary<string, HttpContent>()
            {
                { "list_id", new StringContent(list_id) }
            };
            return JsonConvert.DeserializeObject<GroupModel>(await HttpHelper.PostAsync(Constants.FRIENDSHIPS_GROUPS_DESTROY, param));
        }
    }
}
