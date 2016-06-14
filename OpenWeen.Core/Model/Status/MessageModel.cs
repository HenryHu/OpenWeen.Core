using System.Collections.Generic;
using Newtonsoft.Json;
using OpenWeen.Core.Model.Comment;

namespace OpenWeen.Core.Model.Status
{
    public class MessageModel : BaseModel
    {
        [JsonProperty("isLongText")]
        public bool IsLongText { get; set; }

        [JsonProperty("favorited")]
        public bool Favorited { get; set; }

        [JsonProperty("truncated")]
        public bool Truncated { get; set; }

        [JsonProperty("liked")]
        public bool Liked { get; set; }

        [JsonProperty("in_reply_to_status_id")]
        public string InReplyToStatusID { get; set; }

        [JsonProperty("in_reply_to_user_id")]
        public string InReplyToUserID { get; set; }

        [JsonProperty("in_reply_to_screen_name")]
        public string InReplyToScreenName { get; set; }

        [JsonProperty("thumbnail_pic")]
        public string ThumbnailPic { get; set; }

        [JsonProperty("bmiddle_pic")]
        public string BmiddlePic { get; set; }

        [JsonProperty("original_pic")]
        public string OriginalPic { get; set; }

        [JsonProperty("geo")]
        public GeoModel Geo { get; set; }

        [JsonProperty("retweeted_status")]
        public MessageModel RetweetedStatus { get; set; }

        [JsonProperty("reposts_count")]
        public int RepostsCount { get; set; }

        [JsonProperty("comments_count")]
        public int CommentsCount { get; set; }

        [JsonProperty("attitudes_count")]
        public int AttitudesCount { get; set; }

        [JsonProperty("mlevel")]
        public int MLevel { get; set; }

        [JsonProperty("visible")]
        public WeiboVisibilityModel Visible { get; set; }

        public List<PictureModel> PicUrls
        {
            get
            {
                if (pic_urls == null && PicInfos != null)
                {
                    pic_urls = new List<PictureModel>();
                    foreach (var item in PicInfos)
                    {
                        pic_urls.Add(new PictureModel { PicID = item.Key, BmiddlePic = item.Value.Bmiddle.Url, ThumbnailPic = item.Value.Thumbnail.Url, OriginalPic = item.Value.Original.Url });
                    }
                }
                return pic_urls;
            }
        }

        [JsonProperty("pic_urls")]
        internal List<PictureModel> pic_urls;

        [JsonProperty("pic_infos")]
        public IDictionary<string, PicInfoModel> PicInfos { get; set; }

        [JsonProperty("longText")]
        public LongTextModel LongText { get; set; }

        public override string ToString() => JsonConvert.SerializeObject(this);
    }

    public class UrlStructModel
    {
        [JsonProperty("short_url")]
        public string ShortUrl { get; set; }
        [JsonProperty("ori_url")]
        public string OriUrl { get; set; }
        [JsonProperty("url_title")]
        public string UrlTitle { get; set; }
        [JsonProperty("url_type_pic")]
        public string UrlTypePic { get; set; }
        [JsonProperty("pic_infos")]
        public IDictionary<string, UrlPicInfoModel> PicInfos { get; set; }
        [JsonProperty("pic_ids")]
        public string[] PicIds { get; set; }
        public string Type { get; set; }
    }
    public class PicInfoModel
    {
        [JsonProperty("thumbnail")]
        public WeiboImageModel Thumbnail { get; set; }

        [JsonProperty("bmiddle")]
        public WeiboImageModel Bmiddle { get; set; }

        [JsonProperty("large")]
        public WeiboImageModel Large { get; set; }

        [JsonProperty("original")]
        public WeiboImageModel Original { get; set; }

    }
    public class WeiboImageModel
    {
        [JsonProperty("url")]
        public string Url { get; set; }
        [JsonProperty("width")]
        public int Width { get; set; }
        [JsonProperty("height")]
        public int Height { get; set; }
    }
    public class UrlPicInfoModel : PicInfoModel
    {
        [JsonProperty("woriginal")]
        public new WeiboImageModel Original { get; set; }
    }

    public class LongTextModel
    {
        [JsonProperty("pic_ids")]
        public string[] PicIds { get; set; }
        [JsonProperty("mid")]
        public string Mid { get; set; }
        [JsonProperty("content")]
        public string Content { get; set; }
        [JsonProperty("url_struct")]
        public UrlStructModel[] UrlStruct { get; set; }
    }
}