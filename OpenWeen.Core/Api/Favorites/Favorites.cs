using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenWeen.Core.Helper;
using OpenWeen.Core.Model;
using OpenWeen.Core.Model.Favor;
using OpenWeen.Core.Model.Status;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeen.Core.Api
{
    public class Favorites
    {
        /// <summary>
        /// 获取当前登录用户的收藏列表
        /// </summary>
        /// <param name="count">单页返回的记录条数，默认为50。</param>
        /// <param name="page">返回结果的页码，默认为1。</param>
        /// <returns></returns>
        public static async Task<FavorListModel> GetFavorList(int count = 50, int page = 1)
        {
            Dictionary<string, string> param = new Dictionary<string, string>()
            {
                { nameof(count), count.ToString() },
                { nameof(page), page.ToString() },
            };
            return JsonConvert.DeserializeObject<FavorListModel>(await HttpHelper.GetStringAsync(Constants.FAVORITES_LIST, param));
        }

        /// <summary>
        /// 根据收藏ID获取指定的收藏信息
        /// </summary>
        /// <param name="id">需要查询的收藏ID。</param>
        /// <returns></returns>
        public static async Task<FavorModel> GetFavor(long id)
        {
            Dictionary<string, string> param = new Dictionary<string, string>()
            {
                { nameof(id), id.ToString() },
            };
            return JsonConvert.DeserializeObject<FavorModel>(await HttpHelper.GetStringAsync(Constants.FAVORITES_SHOW, param));
        }
        /// <summary>
        /// 根据标签获取当前登录用户该标签下的收藏列表
        /// </summary>
        /// <param name="tid">需要查询的标签ID。</param>
        /// <param name="count">单页返回的记录条数，默认为50。</param>
        /// <param name="page">返回结果的页码，默认为1。</param>
        /// <returns></returns>
        public static async Task<FavorListModel> GetFavorListByTag(long tid, int count = 50, int page = 1)
        {
            Dictionary<string, string> param = new Dictionary<string, string>()
            {
                { nameof(tid), tid.ToString() },
                { nameof(count), count.ToString() },
                { nameof(page), page.ToString() },
            };
            return JsonConvert.DeserializeObject<FavorListModel>(await HttpHelper.GetStringAsync(Constants.FAVORITES_LIST_BY_TAG, param));
        }
        /// <summary>
        /// 获取当前登录用户的收藏标签列表
        /// </summary>
        /// <param name="count">单页返回的记录条数，默认为10。</param>
        /// <param name="page">返回结果的页码，默认为1。</param>
        /// <returns></returns>
        public static async Task<FavorTagListModel> GetTags(int count = 10, int page = 1)
        {
            Dictionary<string, string> param = new Dictionary<string, string>()
            {
                { nameof(count), count.ToString() },
                { nameof(page), page.ToString() },
            };
            return JsonConvert.DeserializeObject<FavorTagListModel>(await HttpHelper.GetStringAsync(Constants.FAVORITES_TAGS, param));
        }
        /// <summary>
        /// 添加一条微博到收藏里
        /// </summary>
        /// <param name="id">要收藏的微博ID。</param>
        /// <returns></returns>
        public static async Task<FavorModel> AddFavor(long id)
        {
            Dictionary<string, HttpContent> param = new Dictionary<string, HttpContent>()
            {
                { nameof(id), new StringContent(id.ToString()) },
            };
            return JsonConvert.DeserializeObject<FavorModel>(await HttpHelper.PostAsync(Constants.FAVORITES_CREATE, param));
        }
        /// <summary>
        /// 取消收藏一条微博
        /// </summary>
        /// <param name="id">要取消收藏的微博ID。</param>
        /// <returns></returns>
        public static async Task<FavorModel> RemoveFavor(long id)
        {
            Dictionary<string, HttpContent> param = new Dictionary<string, HttpContent>()
            {
                { nameof(id), new StringContent(id.ToString()) },
            };
            return JsonConvert.DeserializeObject<FavorModel>(await HttpHelper.PostAsync(Constants.FAVORITES_DESTROY, param));
        }

        /// <summary>
        /// 根据收藏ID批量取消收藏
        /// </summary>
        /// <param name="ids">要取消收藏的收藏ID，用半角逗号分隔，最多不超过10个。</param>
        /// <returns></returns>
        public static async Task<bool> RemoveFavors(params string[] ids)
        {
            Dictionary<string, HttpContent> param = new Dictionary<string, HttpContent>()
            {
                { nameof(ids), new StringContent(string.Join(",", ids)) },
            };
            return JsonConvert.DeserializeObject<JObject>(await HttpHelper.PostAsync(Constants.FAVORITES_DESTROY_BATCH, param)).Value<bool>("result");
        }
        /// <summary>
        /// 更新一条收藏的收藏标签
        /// </summary>
        /// <param name="id">需要更新的收藏ID。</param>
        /// <param name="tags">需要更新的标签内容，必须做URLencode，用半角逗号分隔，最多不超过2条。</param>
        /// <returns></returns>
        public static async Task<FavorModel> UpdateTags(long id, params string[] tags)
        {
            Dictionary<string, HttpContent> param = new Dictionary<string, HttpContent>()
            {
                { nameof(id), new StringContent(id.ToString()) },
                { nameof(tags), new StringContent(string.Join(",", tags)) },
            };
            return JsonConvert.DeserializeObject<FavorModel>(await HttpHelper.PostAsync(Constants.FAVORITES_TAGS_UPDATE, param));
        }
    }
}
