using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OpenWeen.Core.Helper;
using OpenWeen.Core.Model.Comment;
using OpenWeen.Core.Model.Types;

namespace OpenWeen.Core.Api
{
    /// <summary>
    /// 评论
    /// </summary>
    public class Comments
    {
        /// <summary>
        /// 根据微博ID返回某条微博的评论列表
        /// </summary>
        /// <param name="id">需要查询的微博ID。</param>
        /// <param name="since_id">若指定此参数，则返回ID比since_id大的评论（即比since_id时间晚的评论），默认为0。</param>
        /// <param name="max_id">若指定此参数，则返回ID小于或等于max_id的评论，默认为0。</param>
        /// <param name="count">单页返回的记录条数，默认为50。</param>
        /// <param name="page">返回结果的页码，默认为1。</param>
        /// <param name="filter_by_author">作者筛选类型，0：全部、1：我关注的人、2：陌生人，默认为0。</param>
        /// <returns></returns>
        public static async Task<CommentListModel> GetCommentStatus(long id, long since_id = 0, long max_id = 0, int count = 20, int page = 1, AuthorType filter_by_author = AuthorType.All)
        {
            Dictionary<string, string> param = new Dictionary<string, string>()
            {
                { nameof(id), id.ToString() },
                { nameof(count), count.ToString() },
                { nameof(page), page.ToString() },
                { nameof(since_id), since_id.ToString() },
                { nameof(max_id), max_id.ToString() },
                { nameof(filter_by_author), filter_by_author.ToString("D") },
            };
            return JsonConvert.DeserializeObject<CommentListModel>(await HttpHelper.GetStringAsync(Constants.COMMENTS_SHOW, param));
        }

        /// <summary>
        /// 获取当前登录用户所发出的评论列表
        /// </summary>
        /// <param name="since_id">若指定此参数，则返回ID比since_id大的评论（即比since_id时间晚的评论），默认为0。</param>
        /// <param name="max_id">若指定此参数，则返回ID小于或等于max_id的评论，默认为0。</param>
        /// <param name="count">单页返回的记录条数，默认为50。</param>
        /// <param name="page">返回结果的页码，默认为1。</param>
        /// <param name="filter_by_source">来源筛选类型，0：全部、1：来自微博的评论、2：来自微群的评论，默认为0。</param>
        /// <returns></returns>
        public static async Task<CommentListModel> GetCommentByMe(long since_id = 0, long max_id = 0, int count = 50, int page = 1, SourceType filter_by_source = SourceType.All)
        {
            Dictionary<string, string> param = new Dictionary<string, string>()
            {
                { nameof(count), count.ToString() },
                { nameof(page), page.ToString() },
                { nameof(since_id), since_id.ToString() },
                { nameof(max_id), max_id.ToString() },
                { nameof(filter_by_source), filter_by_source.ToString("D") },
            };
            return JsonConvert.DeserializeObject<CommentListModel>(await HttpHelper.GetStringAsync(Constants.COMMENTS_BY_ME, param));
        }

        /// <summary>
        /// 获取当前登录用户所接收到的评论列表
        /// </summary>
        /// <param name="since_id">若指定此参数，则返回ID比since_id大的评论（即比since_id时间晚的评论），默认为0。</param>
        /// <param name="max_id">若指定此参数，则返回ID小于或等于max_id的评论，默认为0。</param>
        /// <param name="count">单页返回的记录条数，默认为50。</param>
        /// <param name="page">返回结果的页码，默认为1。</param>
        /// <param name="filter_by_author">作者筛选类型，0：全部、1：我关注的人、2：陌生人，默认为0。</param>
        /// <param name="filter_by_source">来源筛选类型，0：全部、1：来自微博的评论、2：来自微群的评论，默认为0。</param>
        /// <returns></returns>
        public static async Task<CommentListModel> GetCommentToMe(long since_id = 0, long max_id = 0, int count = 50, int page = 1, AuthorType filter_by_author = AuthorType.All, SourceType filter_by_source = SourceType.All)
        {
            Dictionary<string, string> param = new Dictionary<string, string>()
            {
                { nameof(count), count.ToString() },
                { nameof(page), page.ToString() },
                { nameof(since_id), since_id.ToString() },
                { nameof(max_id), max_id.ToString() },
                { nameof(filter_by_author), filter_by_author.ToString("D") },
                { nameof(filter_by_source), filter_by_source.ToString("D") },
            };
            return JsonConvert.DeserializeObject<CommentListModel>(await HttpHelper.GetStringAsync(Constants.COMMENTS_TO_ME, param));
        }

        /// <summary>
        /// 获取当前登录用户的最新评论包括接收到的与发出的
        /// </summary>
        /// <param name="since_id">若指定此参数，则返回ID比since_id大的评论（即比since_id时间晚的评论），默认为0。</param>
        /// <param name="max_id">若指定此参数，则返回ID小于或等于max_id的评论，默认为0。</param>
        /// <param name="count">单页返回的记录条数，默认为50。</param>
        /// <param name="page">返回结果的页码，默认为1。</param>
        /// <param name="trim_user">返回值中user字段开关，0：返回完整user字段、1：user字段仅返回user_id，默认为0。</param>
        /// <returns></returns>
        public static async Task<CommentListModel> GetComment(long since_id = 0, long max_id = 0, int count = 50, int page = 1, int trim_user = 0)
        {
            Dictionary<string, string> param = new Dictionary<string, string>()
            {
                { nameof(count), count.ToString() },
                { nameof(page), page.ToString() },
                { nameof(since_id), since_id.ToString() },
                { nameof(max_id), max_id.ToString() },
                { nameof(trim_user), trim_user.ToString() },
            };
            return JsonConvert.DeserializeObject<CommentListModel>(await HttpHelper.GetStringAsync(Constants.COMMENTS_TIMELINE, param));
        }

        /// <summary>
        /// 获取最新的提到当前登录用户的评论，即@我的评论
        /// </summary>
        /// <param name="since_id">若指定此参数，则返回ID比since_id大的评论（即比since_id时间晚的评论），默认为0。</param>
        /// <param name="max_id">若指定此参数，则返回ID小于或等于max_id的评论，默认为0。</param>
        /// <param name="count">单页返回的记录条数，默认为50。</param>
        /// <param name="page">返回结果的页码，默认为1。</param>
        /// <param name="filter_by_author">作者筛选类型，0：全部、1：我关注的人、2：陌生人，默认为0。</param>
        /// <param name="filter_by_source">来源筛选类型，0：全部、1：来自微博的评论、2：来自微群的评论，默认为0。</param>
        /// <returns></returns>
        public static async Task<CommentListModel> GetCommentMentions(long since_id = 0, long max_id = 0, int count = 50, int page = 1, AuthorType filter_by_author = AuthorType.All, SourceType filter_by_source = SourceType.All)
        {
            Dictionary<string, string> param = new Dictionary<string, string>()
            {
                { nameof(count), count.ToString() },
                { nameof(page), page.ToString() },
                { nameof(since_id), since_id.ToString() },
                { nameof(max_id), max_id.ToString() },
                { nameof(filter_by_author), filter_by_author.ToString("D") },
                { nameof(filter_by_source), filter_by_source.ToString("D") },
            };
            return JsonConvert.DeserializeObject<CommentListModel>(await HttpHelper.GetStringAsync(Constants.COMMENTS_MENTIONS, param));
        }

        /// <summary>
        /// 根据评论ID批量返回评论信息
        /// </summary>
        /// <param name="cids">需要查询的批量评论ID，用半角逗号分隔，最大50。</param>
        /// <returns></returns>
        public static async Task<IEnumerable<CommentModel>> Batch(params long[] cids)
        {
            Dictionary<string, string> param = new Dictionary<string, string>()
            {
                { nameof(cids), string.Join(",",cids) },
            };
            return JsonConvert.DeserializeObject<IEnumerable<CommentModel>>(await HttpHelper.GetStringAsync(Constants.COMMENTS_BATCH, param));
        }

        /// <summary>
        /// 对一条微博进行评论
        /// </summary>
        /// <param name="id">需要评论的微博ID。</param>
        /// <param name="comment">评论内容，必须做URLencode，内容不超过140个汉字。</param>
        /// <param name="commentOri">当评论转发微博时，是否评论给原微博，默认为否。</param>
        /// <returns></returns>
        public static async Task<CommentModel> PostComment(long id, string comment, bool commentOri = false)
        {
            Dictionary<string, HttpContent> param = new Dictionary<string, HttpContent>()
            {
                { nameof(id), new StringContent(id.ToString()) },
                { nameof(comment), new StringContent(comment) },
                { "comment_ori", new StringContent(commentOri ? "1" : "0") },
            };
            return JsonConvert.DeserializeObject<CommentModel>(await HttpHelper.PostAsync(Constants.COMMENTS_CREATE, param));
        }

        /// <summary>
        /// 回复一条评论
        /// </summary>
        /// <param name="id">需要评论的微博ID。</param>
        /// <param name="cid">需要回复的评论ID。</param>
        /// <param name="comment">回复评论内容，内容不超过140个汉字。</param>
        /// <param name="comment_ori">当评论转发微博时，是否评论给原微博，默认为否。</param>
        /// <param name="without_mention">回复中是否自动加入“回复@用户名”，默认为否。</param>
        /// <returns></returns>
        public static async Task<CommentModel> Reply(long id, long cid, string comment, bool comment_ori = false, bool without_mention = false)
        {
            Dictionary<string, HttpContent> param = new Dictionary<string, HttpContent>()
            {
                { nameof(id), new StringContent(id.ToString()) },
                { nameof(comment), new StringContent(comment) },
                { nameof(cid), new StringContent(cid.ToString()) },
                { nameof(comment_ori), new StringContent(comment_ori ? "1" : "0") },
                { nameof(without_mention), new StringContent(without_mention ? "1" : "0") },
            };
            return JsonConvert.DeserializeObject<CommentModel>(await HttpHelper.PostAsync(Constants.COMMENTS_REPLY, param));
        }

        /// <summary>
        /// 删除一条评论
        /// </summary>
        /// <param name="cid">要删除的评论ID，只能删除登录用户自己发布的评论。</param>
        /// <returns></returns>
        public static async Task<CommentModel> Delete(long cid)
        {
            Dictionary<string, HttpContent> param = new Dictionary<string, HttpContent>()
            {
                { nameof(cid), new StringContent(cid.ToString()) },
            };
            return JsonConvert.DeserializeObject<CommentModel>(await HttpHelper.PostAsync(Constants.COMMENTS_DESTROY, param));
        }

        /// <summary>
        /// 根据评论ID批量删除评论
        /// </summary>
        /// <param name="cids">需要删除的评论ID，最多20个。</param>
        /// <returns></returns>
        public static async Task<IEnumerable<CommentModel>> DeleteBatch(params long[] cids)
        {
            Dictionary<string, HttpContent> param = new Dictionary<string, HttpContent>()
            {
                { nameof(cids), new StringContent(string.Join(",", cids)) },
            };
            return JsonConvert.DeserializeObject<IEnumerable<CommentModel>>(await HttpHelper.PostAsync(Constants.COMMENTS_DESTROY_BATCH, param));
        }
    }
}