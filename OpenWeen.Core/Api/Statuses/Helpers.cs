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

namespace OpenWeen.Core.Api.Statuses
{
    public static class Helpers
    {
        public const int EXTRA_NONE = 0;
        public const int EXTRA_COMMENT = 1;
        public const int EXTRA_COMMENT_ORIG = 2;
        public const int EXTRA_ALL = 3;


        public static async Task<bool> Post(string status, string version)
        {
            Dictionary<string, HttpContent> param = new Dictionary<string, HttpContent>()
            {
                { nameof(status), new StringContent(status) },
                { "annotations", new StringContent(ParseAnnotation(version)) },
            };
            var msg = JsonConvert.DeserializeObject<MessageModel>(await HttpHelper.PostAsync(Constants.UPDATE, param));
            return !string.IsNullOrEmpty(msg?.IDStr?.Trim());
        }

        public static async Task<bool> PostWithPic(string status, byte[] pic)
        {
            Dictionary<string, HttpContent> param = new Dictionary<string, HttpContent>()
            {
                { nameof(status), new StringContent(status) },
                { nameof(pic), new ByteArrayContent(pic) },
            };
            var msg = JsonConvert.DeserializeObject<MessageModel>(await HttpHelper.PostAsync(Constants.UPLOAD, param));
            return !string.IsNullOrEmpty(msg?.IDStr?.Trim());
        }

        public static async Task<bool> Post(long id, string status, int extra, string version)
        {
            Dictionary<string, HttpContent> param = new Dictionary<string, HttpContent>()
            {
                { nameof(status), new StringContent(status) },
                { nameof(id), new StringContent(id.ToString()) },
                { "is_comment", new StringContent(extra.ToString()) },
                { "annotations", new StringContent(ParseAnnotation(version)) },
            };
            var msg = JsonConvert.DeserializeObject<MessageModel>(await HttpHelper.PostAsync(Constants.REPOST, param));
            return !string.IsNullOrEmpty(msg?.IDStr?.Trim());
        }

        public static async Task DeletePost(long id)
        {
            Dictionary<string, HttpContent> param = new Dictionary<string, HttpContent>()
            {
                { nameof(id), new StringContent(id.ToString()) },
            };
            await HttpHelper.PostAsync(Constants.DESTROY, param);
        }

        public static async Task AddFavor(long id)
        {
            Dictionary<string, HttpContent> param = new Dictionary<string, HttpContent>()
            {
                { nameof(id), new StringContent(id.ToString()) },
            };
            await HttpHelper.PostAsync(Constants.FAVORITES_CREATE, param);
        }

        public static async Task RemoveFavor(long id)
        {
            Dictionary<string, HttpContent> param = new Dictionary<string, HttpContent>()
            {
                { nameof(id), new StringContent(id.ToString()) },
            };
            await HttpHelper.PostAsync(Constants.FAVORITES_DESTROY, param);
        }

        public static async Task<string> UploadPicture(byte[] pic)
        {
            Dictionary<string, HttpContent> param = new Dictionary<string, HttpContent>()
            {
                { nameof(pic), new ByteArrayContent(pic) },
            };
            return JsonConvert.DeserializeObject<JObject>(await HttpHelper.PostAsync(Constants.UPLOAD_PIC, param)).Value<string>("pic_id");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="status"></param>
        /// <param name="pics">returned by UploadPicture, split with ","</param>
        /// <param name="version"></param>
        /// <returns></returns>
        public static async Task<bool> PostWithMultiPics(string status, string pics, string version)
        {
            Dictionary<string, HttpContent> param = new Dictionary<string, HttpContent>()
            {
                { nameof(status), new StringContent(status) },
                { "pic_id", new StringContent(pics) },
                { "annotations", new StringContent(ParseAnnotation(version)) },
            };
            var msg = JsonConvert.DeserializeObject<MessageModel>(await HttpHelper.PostAsync(Constants.UPLOAD_URL_TEXT, param));
            return !string.IsNullOrEmpty(msg?.IDStr?.Trim());
        }

        private static string ParseAnnotation(string version)
        {
            AnnotationModel ann = new AnnotationModel();
            ann.BlVersion = version;
            return $"[{JsonConvert.SerializeObject(ann)}]";//TODO: Check
        }
    }
}
