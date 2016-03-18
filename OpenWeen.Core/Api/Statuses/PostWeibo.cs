using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using OpenWeen.Core.Helper;
using OpenWeen.Core.Model;
using OpenWeen.Core.Model.Status;
using OpenWeen.Core.Model.Types;
using System.Net;

namespace OpenWeen.Core.Api.Statuses
{
    /// <summary>
    /// 发布/转发微博
    /// </summary>
    public static class PostWeibo
    {
        /// <summary>
        /// 发布一条新微博
        /// </summary>
        /// <param name="status">要发布的微博文本内容，内容不超过140个汉字。</param>
        /// <param name="visible">微博的可见性，0：所有人能看，1：仅自己可见，2：密友可见，3：指定分组可见，默认为0。</param>
        /// <param name="list_id">微博的保护投递指定分组ID，只有当visible参数为3时生效且必选。</param>
        /// <param name="plat">纬度，有效范围：-90.0到+90.0，+表示北纬，默认为0.0。</param>
        /// <param name="plong">经度，有效范围：-180.0到+180.0，+表示东经，默认为0.0。</param>
        /// <returns></returns>
        public static async Task<MessageModel> Post(string status, WeiboVisibility visible = WeiboVisibility.All, string list_id = "", float plat = 0f, float plong = 0f)
        {
            Dictionary<string, HttpContent> param = new Dictionary<string, HttpContent>()
            {
                { nameof(status), new StringContent(WebUtility.UrlEncode(status)) },
                { nameof(visible), new StringContent(visible.ToString("D")) },
                { "lat", new StringContent(plat.ToString()) },
                { "long", new StringContent(plong.ToString()) },
            };
            CheckForVisibility(visible, list_id, param);
            return JsonConvert.DeserializeObject<MessageModel>(await HttpHelper.PostAsync(Constants.UPDATE, param));
        }

        /// <summary>
        /// 上传图片并发布一条新微博
        /// </summary>
        /// <param name="status">要发布的微博文本内容，内容不超过140个汉字。</param>
        /// <param name="pic">要上传的图片，仅支持JPEG、GIF、PNG格式，图片大小小于5M。</param>
        /// <param name="visible">微博的可见性，0：所有人能看，1：仅自己可见，2：密友可见，3：指定分组可见，默认为0。</param>
        /// <param name="list_id">微博的保护投递指定分组ID，只有当visible参数为3时生效且必选。</param>
        /// <param name="plat">纬度，有效范围：-90.0到+90.0，+表示北纬，默认为0.0。</param>
        /// <param name="plong">经度，有效范围：-180.0到+180.0，+表示东经，默认为0.0。</param>
        /// <returns></returns>
        public static async Task<MessageModel> PostWithPic(string status, byte[] pic, WeiboVisibility visible = WeiboVisibility.All, string list_id = "", float plat = 0f, float plong = 0f)
        {
            Dictionary<string, HttpContent> param = new Dictionary<string, HttpContent>()
            {
                { nameof(status), new StringContent(status) },
                { nameof(pic), new ByteArrayContent(pic) },
                { nameof(visible), new StringContent(visible.ToString("D")) },
                { "lat", new StringContent(plat.ToString()) },
                { "long", new StringContent(plong.ToString()) },
            };
            CheckForVisibility(visible, list_id, param);
            return JsonConvert.DeserializeObject<MessageModel>(await HttpHelper.PostAsync(Constants.UPLOAD, param));
        }

        /// <summary>
        /// 检查参数是否正确
        /// </summary>
        /// <param name="visible"></param>
        /// <param name="list_id"></param>
        /// <param name="param"></param>
        private static void CheckForVisibility(WeiboVisibility visible, string list_id, Dictionary<string, HttpContent> param)
        {
            if (visible == WeiboVisibility.SpecifiedGroup)
                if (string.IsNullOrEmpty(list_id))
                    throw new ArgumentException($"list_id can not be empty or null when visible == WeiboVisibility.SpecifiedGroup");
                else
                    param.Add(nameof(list_id), new StringContent(list_id));
        }

        /// <summary>
        /// 转发一条微博
        /// </summary>
        /// <param name="id">要转发的微博ID。</param>
        /// <param name="status">添加的转发文本，内容不超过140个汉字，不填则默认为“转发微博”。</param>
        /// <param name="is_comment">是否在转发的同时发表评论，0：否、1：评论给当前微博、2：评论给原微博、3：都评论，默认为0 。</param>
        /// <returns></returns>
        public static async Task<MessageModel> Repost(long id, string status, RepostType is_comment = RepostType.None)
        {
            Dictionary<string, HttpContent> param = new Dictionary<string, HttpContent>()
            {
                { nameof(status), new StringContent(WebUtility.UrlEncode(string.IsNullOrEmpty(status) ? "转发微博" : status)) },
                { nameof(id), new StringContent(id.ToString()) },
                { nameof(is_comment), new StringContent(is_comment.ToString("D")) },
            };
            return JsonConvert.DeserializeObject<MessageModel>(await HttpHelper.PostAsync(Constants.REPOST, param));
        }

        /// <summary>
        /// 根据微博ID删除指定微博
        /// </summary>
        /// <param name="id">需要删除的微博ID。</param>
        /// <returns></returns>
        public static async Task<MessageModel> DeletePost(long id)
        {
            Dictionary<string, HttpContent> param = new Dictionary<string, HttpContent>()
            {
                { nameof(id), new StringContent(id.ToString()) },
            };
            return JsonConvert.DeserializeObject<MessageModel>(await HttpHelper.PostAsync(Constants.DESTROY, param));
        }

        /// <summary>
        /// 上传图片，返回图片picid,urls(3个url)
        /// </summary>
        /// <param name="pic">需要上传的图片。</param>
        /// <returns></returns>
        public static async Task<PictureModel> UploadPicture(byte[] pic)
        {
            Dictionary<string, HttpContent> param = new Dictionary<string, HttpContent>()
            {
                { nameof(pic), new ByteArrayContent(pic) },
            };
            return JsonConvert.DeserializeObject<PictureModel>(await HttpHelper.PostAsync(Constants.UPLOAD_PIC, param));
        }

        /// <summary>
        /// 指定一个图片URL地址抓取后上传并同时发布一条新微博
        /// </summary>
        /// <param name="status">要发布的微博文本内容内容不超过140个汉字。</param>
        /// <param name="pics">已经上传的图片pid，多个时使用英文半角逗号符分隔，最多不超过9个。图片可以通过<see cref="UploadPicture(byte[])"/>上传</param>
        /// <param name="visible">微博的可见性，0：所有人能看，1：仅自己可见，2：密友可见，3：指定分组可见，默认为0。</param>
        /// <param name="list_id">微博的保护投递指定分组ID，只有当visible参数为3时生效且必选。</param>
        /// <param name="plat">纬度，有效范围：-90.0到+90.0，+表示北纬，默认为0.0。</param>
        /// <param name="plong">经度，有效范围：-180.0到+180.0，+表示东经，默认为0.0。</param>
        /// <returns></returns>
        public static async Task<MessageModel> PostWithMultiPics(string status, string pics, WeiboVisibility visible = WeiboVisibility.All, string list_id = "", float plat = 0f, float plong = 0f)
        {
            Dictionary<string, HttpContent> param = new Dictionary<string, HttpContent>()
            {
                { nameof(status), new StringContent(WebUtility.UrlEncode(status)) },
                { "pic_id", new StringContent(pics) },
                { nameof(visible), new StringContent(visible.ToString("D")) },
                { "lat", new StringContent(plat.ToString()) },
                { "long", new StringContent(plong.ToString()) },
            };
            CheckForVisibility(visible, list_id, param);
            return JsonConvert.DeserializeObject<MessageModel>(await HttpHelper.PostAsync(Constants.UPLOAD_URL_TEXT, param));
        }
    }
}
