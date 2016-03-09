using Newtonsoft.Json;
using OpenWeen.Core.Model;
using OpenWeen.Core.Model.User;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeen.Core.Model.Status
{
    public class MessageModel
    {
        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }
        public DateTime CreateTime => DateTime.ParseExact(CreatedAt, "ddd MMM dd HH:mm:ss K yyyy", CultureInfo.InvariantCulture);
        [JsonProperty("id")]
        public long ID { get; set; }
        [JsonProperty("mid")]
        public long MID { get; set; }
        [JsonProperty("idstr")]
        public string IDStr { get; set; }
        [JsonProperty("text")]
        public string Text { get; set; }
        [JsonProperty("source")]
        public string Source { get; set; }
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
        [JsonProperty("user")]
        public UserModel User { get; set; }
        [JsonProperty("retweeted_status")]
        public MessageModel RetweetedStatus { get; set; }
        [JsonProperty("reposts_count")]
        public int RepostsCount { get; set; }
        [JsonProperty("comments_count")]
        public int CommentsCount { get; set; }
        [JsonProperty("attitudes_count")]
        public int AttitudesCount { get; set; }
        [JsonProperty("annotations")]
        public List<AnnotationModel> Annotations { get; set; }
        public override string ToString() => JsonConvert.SerializeObject(this);

    }
}
