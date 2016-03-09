using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenWeen.Core.Helper;
using OpenWeen.Core.Model;
using OpenWeen.Core.Model.Status;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeen.Core.Api.Friendships
{
    public class Groups
    {
        public static async Task<GroupListModel> GetGroups()
            => JsonConvert.DeserializeObject<GroupListModel>(await HttpHelper.GetStringAsync(Constants.FRIENDSHIPS_GROUPS, null));
        public static async Task<bool> IsMember(string uid, string groupId)
        {
            Dictionary<string, string> param = new Dictionary<string, string>()
            {
                { nameof(uid), uid },
                { "list_id", groupId },
            };
            return JsonConvert.DeserializeObject<JObject>(await HttpHelper.GetStringAsync(Constants.FRIENDSHIPS_GROUPS_IS_MEMBER, param)).Value<bool>("lists");
        }
        public static async Task<MessageListModel> GetGroupTimeline(string groupId, int count, int page)
        {
            Dictionary<string, string> param = new Dictionary<string, string>()
            {
                { "list_id", groupId },
                { nameof(count), count.ToString() },
                { nameof(page), page.ToString() },
            };
            return JsonConvert.DeserializeObject<MessageListModel>(await HttpHelper.GetStringAsync(Constants.FRIENDSHIPS_GROUPS_TIMELINE, param));
        }
        public static async Task AddToGroup(string uid, string groupId)
        {
            Dictionary<string, HttpContent> param = new Dictionary<string, HttpContent>()
            {
                { nameof(uid), new StringContent(uid) },
                { "list_id", new StringContent(groupId) },
            };
            await HttpHelper.PostAsync(Constants.FRIENDSHIPS_GROUPS_MEMBERS_ADD, param);
        }
        public static async Task RemoveFromGroup(string uid, string groupId)
        {
            Dictionary<string, HttpContent> param = new Dictionary<string, HttpContent>()
            {
                { nameof(uid), new StringContent(uid) },
                { "list_id", new StringContent(groupId) },
            };
            await HttpHelper.PostAsync(Constants.FRIENDSHIPS_GROUPS_MEMBERS_DESTROY, param);
        }
        public static async Task CreateGroup(string name)
        {
            Dictionary<string, HttpContent> param = new Dictionary<string, HttpContent>()
            {
                { nameof(name), new StringContent(name) }
            };
            await HttpHelper.PostAsync(Constants.FRIENDSHIPS_GROUPS_CREATE, param);
        }
        public static async Task DeleteGroup(string groupId)
        {
            Dictionary<string, HttpContent> param = new Dictionary<string, HttpContent>()
            {
                { "list_id", new StringContent(groupId) }
            };
            await HttpHelper.PostAsync(Constants.FRIENDSHIPS_GROUPS_DESTROY, param);
        }
    }
}
