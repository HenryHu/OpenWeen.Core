using System.Collections.Generic;
using Newtonsoft.Json;

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

        [JsonProperty("pic_urls")]
        public List<PictureModel> PicUrls { get; set; }

        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}