using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OpenWeen.Core.Helper;
using OpenWeen.Core.Model.User;

namespace OpenWeen.Core.Api.Friendships
{
    /// <summary>
    /// 关注/粉丝
    /// </summary>
    public class Friends
    {
        private static async Task<UserListModel> GetUsers<T>(T uid, int count, int cursor, string url)
        {
            Dictionary<string, string> param = new Dictionary<string, string>()
            {
                { nameof(uid), uid.ToString() },
                { nameof(count), count.ToString() },
                { nameof(cursor), cursor.ToString() },
            };
            return JsonConvert.DeserializeObject<UserListModel>(await HttpHelper.GetStringAsync(url, param));
        }

        /// <summary>
        /// 获取用户的关注列表
        /// </summary>
        /// <param name="uid">需要查询的用户UID。</param>
        /// <param name="count">单页返回的记录条数，默认为50，最大不超过200。</param>
        /// <param name="cursor">返回结果的游标，下一页用返回值里的next_cursor，上一页用previous_cursor，默认为0。</param>
        /// <returns></returns>
        public static async Task<UserListModel> GetFriends(long uid, int count = 50, int cursor = 0)
            => await GetUsers(uid, count, cursor, Constants.FRIENDSHIPS_FRIENDS);

        /// <summary>
        /// 获取用户的关注列表
        /// </summary>
        /// <param name="screen_name">需要查询的用户昵称。</param>
        /// <param name="count">单页返回的记录条数，默认为50，最大不超过200。</param>
        /// <param name="cursor">返回结果的游标，下一页用返回值里的next_cursor，上一页用previous_cursor，默认为0。</param>
        /// <returns></returns>
        public static async Task<UserListModel> GetFriends(string screen_name, int count = 50, int cursor = 0)
            => await GetUsers(screen_name, count, cursor, Constants.FRIENDSHIPS_FRIENDS);

        /// <summary>
        /// 获取两个用户之间的共同关注人列表
        /// </summary>
        /// <param name="uid">需要获取共同关注关系的用户UID。</param>
        /// <param name="suid">需要获取共同关注关系的用户UID，默认为当前登录用户。</param>
        /// <param name="count">单页返回的记录条数，默认为50。</param>
        /// <param name="page">返回结果的页码，默认为1。</param>
        /// <returns></returns>
        public static async Task<UserListModel> GetFriendsInCommon(long uid, long suid = -1, int count = 50, int page = 1)
        {
            Dictionary<string, string> param = new Dictionary<string, string>()
            {
                { nameof(uid), uid.ToString() },
                { nameof(count), count.ToString() },
                { nameof(page), page.ToString() },
            };
            if (suid != -1)
                param.Add(nameof(suid), suid.ToString());
            return JsonConvert.DeserializeObject<UserListModel>(await HttpHelper.GetStringAsync(Constants.FRIENDSHIPS_FRIENDS_IN_COMMON, param));
        }

        /// <summary>
        /// 获取用户的双向关注列表，即互粉列表
        /// </summary>
        /// <param name="uid">需要获取双向关注列表的用户UID。</param>
        /// <param name="count">单页返回的记录条数，默认为50。</param>
        /// <param name="page">返回结果的页码，默认为1。</param>
        /// <param name="sort">排序类型，0：按关注时间最近排序，默认为0。</param>
        /// <returns></returns>
        public static async Task<UserListModel> GetBliateral(long uid, int count = 50, int page = 1, int sort = 0)
        {
            Dictionary<string, string> param = new Dictionary<string, string>()
            {
                { nameof(uid), uid.ToString() },
                { nameof(count), count.ToString() },
                { nameof(page), page.ToString() },
                { nameof(sort), sort.ToString() },
            };
            return JsonConvert.DeserializeObject<UserListModel>(await HttpHelper.GetStringAsync(Constants.FRIENDSHIPS_FRIENDS_BILATERAL, param));
        }

        /// <summary>
        /// 获取用户的粉丝列表
        /// </summary>
        /// <param name="uid">需要查询的用户UID。</param>
        /// <param name="count">单页返回的记录条数，默认为50，最大不超过200。</param>
        /// <param name="cursor">返回结果的游标，下一页用返回值里的next_cursor，上一页用previous_cursor，默认为0。</param>
        /// <returns></returns>
        public static async Task<UserListModel> GetFollowers(long uid, int count = 50, int cursor = 0)
            => await GetUsers(uid, count, cursor, Constants.FRIENDSHIPS_FOLLOWERS);

        /// <summary>
        /// 获取用户的粉丝列表
        /// </summary>
        /// <param name="screen_name">需要查询的用户UID。</param>
        /// <param name="count">单页返回的记录条数，默认为50，最大不超过200。</param>
        /// <param name="cursor">返回结果的游标，下一页用返回值里的next_cursor，上一页用previous_cursor，默认为0。</param>
        /// <returns></returns>
        public static async Task<UserListModel> GetFollowers(string screen_name, int count = 50, int cursor = 0)
            => await GetUsers(screen_name, count, cursor, Constants.FRIENDSHIPS_FOLLOWERS);

        /// <summary>
        /// 获取用户的活跃粉丝列表
        /// </summary>
        /// <param name="uid">需要查询的用户UID。</param>
        /// <param name="count">返回的记录条数，默认为20，最大不超过200。</param>
        /// <returns></returns>
        public static async Task<IEnumerable<UserModel>> GetActiveFollowers(long uid, int count = 20)
        {
            Dictionary<string, string> param = new Dictionary<string, string>()
            {
                { nameof(uid), uid.ToString() },
                { nameof(count), count.ToString() },
            };
            return JsonConvert.DeserializeObject<IEnumerable<UserModel>>(await HttpHelper.GetStringAsync(Constants.FRIENDSHIPS_FOLLOWERS_ACTIVE, param));
        }

        /// <summary>
        /// 获取当前登录用户的关注人中又关注了指定用户的用户列表
        /// </summary>
        /// <param name="uid">指定的关注目标用户UID。</param>
        /// <param name="count">单页返回的记录条数，默认为50。</param>
        /// <param name="page">返回结果的页码，默认为1。</param>
        /// <returns></returns>
        public static async Task<UserListModel> GetFriendsChain(long uid, int count = 50, int page = 1)
        {
            Dictionary<string, string> param = new Dictionary<string, string>()
            {
                { nameof(uid), uid.ToString() },
                { nameof(count), count.ToString() },
                { nameof(page), page.ToString() },
            };
            return JsonConvert.DeserializeObject<UserListModel>(await HttpHelper.GetStringAsync(Constants.FRIENDSHIPS_FRIENDS_CHAIN, param));
        }

        /// <summary>
        /// 关注一个用户
        /// </summary>
        /// <param name="uid">需要关注的用户ID。</param>
        /// <returns></returns>
        public static async Task<UserModel> Follow(long uid)
        {
            Dictionary<string, HttpContent> param = new Dictionary<string, HttpContent>()
            {
                { nameof(uid), new StringContent(uid.ToString()) },
            };
            return JsonConvert.DeserializeObject<UserModel>(await HttpHelper.PostAsync(Constants.FRIENDSHIPS_CREATE, param));
        }

        /// <summary>
        /// 关注一个用户
        /// </summary>
        /// <param name="screen_name">需要关注的用户昵称。</param>
        /// <returns></returns>
        public static async Task<UserModel> Follow(string screen_name)
        {
            Dictionary<string, HttpContent> param = new Dictionary<string, HttpContent>()
            {
                { nameof(screen_name), new StringContent(screen_name) },
            };
            return JsonConvert.DeserializeObject<UserModel>(await HttpHelper.PostAsync(Constants.FRIENDSHIPS_CREATE, param));
        }

        /// <summary>
        /// 取消关注一个用户
        /// </summary>
        /// <param name="uid">需要取消关注的用户ID。</param>
        /// <returns></returns>
        public static async Task<UserModel> UnFollow(long uid)
        {
            Dictionary<string, HttpContent> param = new Dictionary<string, HttpContent>()
            {
                { nameof(uid), new StringContent(uid.ToString()) },
            };
            return JsonConvert.DeserializeObject<UserModel>(await HttpHelper.PostAsync(Constants.FRIENDSHIPS_DESTROY, param));
        }

        /// <summary>
        /// 取消关注一个用户
        /// </summary>
        /// <param name="screen_name">需要取消关注的用户昵称。</param>
        /// <returns></returns>
        public static async Task<UserModel> UnFollow(string screen_name)
        {
            Dictionary<string, HttpContent> param = new Dictionary<string, HttpContent>()
            {
                { nameof(screen_name), new StringContent(screen_name) },
            };
            return JsonConvert.DeserializeObject<UserModel>(await HttpHelper.PostAsync(Constants.FRIENDSHIPS_DESTROY, param));
        }
    }
}