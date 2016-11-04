using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;

namespace OpenWeen.Core.Model.Status
{
    public class MessageModel : BaseModel
    {
        //[JsonProperty("isLongText")]
        //public bool IsLongText { get; set; }

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

        [JsonProperty("longText")]
        public LongTextModel LongText { get; set; }

        [JsonProperty("visible")]
        public WeiboVisibilityModel Visible { get; set; }

        [JsonProperty("pic_urls")]
        internal List<PictureModel> _picUrls;

        public List<PictureModel> PicUrls
            => _picUrls == null && UserTimelineImage != null ?
                    UserTimelineImage.Values.Select(item => new PictureModel(item)).ToList() :
                    _picUrls;


        [JsonProperty("pic_infos")]
        public Dictionary<string,UserTimelineImageModel> UserTimelineImage { get; set; }

        public override string ToString() => JsonConvert.SerializeObject(this);
    }

    public class UserTimelineImageModel
    {
        public UserTimelineImageDetailModel thumbnail { get; set; }
        public UserTimelineImageDetailModel bmiddle { get; set; }
        public UserTimelineImageDetailModel middleplus { get; set; }
        public UserTimelineImageDetailModel large { get; set; }
        public UserTimelineImageDetailModel original { get; set; }
        public UserTimelineImageDetailModel largest { get; set; }
        public string object_id { get; set; }
        public string pic_id { get; set; }
        public int photo_tag { get; set; }
        public string type { get; set; }
        public int pic_status { get; set; }
    }

    public class UserTimelineImageDetailModel
    {
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public int cut_type { get; set; }
        public string type { get; set; }
    }
   
    public class LongTextModel
    {
        [JsonProperty("longTextContent")]
        public string Content { get; set; }

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
        public PicInfoModel(UserTimelineImageModel item)
        {
            Thumbnail = new WeiboImageModel(item.thumbnail);
            Bmiddle = new WeiboImageModel(item.bmiddle);
            Large = new WeiboImageModel(item.large);
            Original = new WeiboImageModel(item.original);
        }

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
        public WeiboImageModel(UserTimelineImageDetailModel item)
        {
            Url = item.url;
            Width = item.width;
            Height = item.height;
        }
        [JsonProperty("url")]
        public string Url { get; set; }
        [JsonProperty("width")]
        public int Width { get; set; }
        [JsonProperty("height")]
        public int Height { get; set; }
    }
    public class UrlPicInfoModel : PicInfoModel
    {
        public UrlPicInfoModel(UserTimelineImageModel item) : base(item)
        {
            Original = new WeiboImageModel(item.original);
        }

        [JsonProperty("woriginal")]
        public new WeiboImageModel Original { get; set; }
    }
}