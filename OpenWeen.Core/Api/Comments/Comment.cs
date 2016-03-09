using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenWeen.Core.Helper;
using OpenWeen.Core.Model;
using System.Net.Http;

namespace OpenWeen.Core.Api.Comments
{
    public class Comment : CommentBase
    {
        public static async Task<CommentListModel> GetComment(int count, int page)
            => await Get(count, page, Constants.COMMENTS_TIMELINE);
        public static async Task<CommentListModel> GetCommentToMe(int count, int page)
            => await Get(count, page, Constants.COMMENTS_TO_ME);
        public static async Task<CommentListModel> GetCommentSince(long id)
        {
            Dictionary<string, string> param = new Dictionary<string, string>()
            {
                { "since_id", id.ToString() },
            };
            return JsonConvert.DeserializeObject<CommentListModel>(await HttpHelper.GetStringAsync(Constants.COMMENTS_TIMELINE, param));
        }
        public static async Task<CommentListModel> GetCommentMentions(int count, int page)
            => await Get(count, page, Constants.COMMENTS_MENTIONS);
        public static async Task<bool> PostComment(long id,string comment,bool commentOri = false)
        {
            Dictionary<string, HttpContent> param = new Dictionary<string, HttpContent>()
            {
                { nameof(id), new StringContent(id.ToString()) },
                { nameof(comment), new StringContent(comment) },
                { "comment_ori", new StringContent(commentOri ? "1" : "0") },
            };
            return JsonConvert.DeserializeObject<CommentModel>(await HttpHelper.PostAsync(Constants.COMMENTS_CREATE, param))?.ID > 0;
        }
        public static async Task<bool> Reply(long id, long cid, string comment, bool commentOri = false)
        {
            Dictionary<string, HttpContent> param = new Dictionary<string, HttpContent>()
            {
                { nameof(id), new StringContent(id.ToString()) },
                { nameof(comment), new StringContent(comment) },
                { nameof(cid), new StringContent(cid.ToString()) },
                { "comment_ori", new StringContent(commentOri ? "1" : "0") },
            };
            return JsonConvert.DeserializeObject<CommentModel>(await HttpHelper.PostAsync(Constants.COMMENTS_REPLY, param))?.ID > 0;
        }
        public static async Task Delete(long cid)
        {
            Dictionary<string, HttpContent> param = new Dictionary<string, HttpContent>()
            {
                { nameof(cid), new StringContent(cid.ToString()) },
            };
            await HttpHelper.PostAsync(Constants.COMMENTS_DESTROY, param);
        }
        public static async Task<CommentListModel> GetCommentStatus(long msgId, int count, int page)
        {
            Dictionary<string, string> param = new Dictionary<string, string>()
            {
                { "id", msgId.ToString() },
                { nameof(count), count.ToString() },
                { nameof(page), page.ToString() },
            };
            return JsonConvert.DeserializeObject<CommentListModel>(await HttpHelper.GetStringAsync(Constants.COMMENTS_SHOW, param));
        }
    }
}
