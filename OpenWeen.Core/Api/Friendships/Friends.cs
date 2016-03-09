using Newtonsoft.Json;
using OpenWeen.Core.Helper;
using OpenWeen.Core.Model;
using OpenWeen.Core.Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeen.Core.Api.Friendships
{
    public class Friends
    {
        private static async Task<UserListModel> GetUsers(string uid, int count, int cursor, string url)
        {
            Dictionary<string, string> param = new Dictionary<string, string>()
            {
                { nameof(uid), uid },
                { nameof(count), count.ToString() },
                { nameof(cursor), cursor.ToString() },
            };
            return JsonConvert.DeserializeObject<UserListModel>(await HttpHelper.GetStringAsync(url, param));
        }
        public static async Task<UserListModel> GetFriendsOf(string uid, int count, int cursor)
            => await GetUsers(uid, count, cursor, Constants.FRIENDSHIPS_FRIENDS);
        public static async Task<UserListModel> GetFollowersOf(string uid, int count, int cursor)
            => await GetUsers(uid, count, cursor, Constants.FRIENDSHIPS_FOLLOWERS);
        public static async Task<bool> Follow(string uid)
        {
            Dictionary<string, HttpContent> param = new Dictionary<string, HttpContent>()
            {
                { nameof(uid), new StringContent(uid) },
            };
            return !string.IsNullOrEmpty(JsonConvert.DeserializeObject<UserModel>(await HttpHelper.PostAsync(Constants.FRIENDSHIPS_CREATE, param))?.ID?.Trim());
        }
        public static async Task<bool> UnFollow(string uid)
        {
            Dictionary<string, HttpContent> param = new Dictionary<string, HttpContent>()
            {
                { nameof(uid), new StringContent(uid) },
            };
            return !string.IsNullOrEmpty(JsonConvert.DeserializeObject<UserModel>(await HttpHelper.PostAsync(Constants.FRIENDSHIPS_DESTROY, param))?.ID?.Trim());
        }
    }
}
