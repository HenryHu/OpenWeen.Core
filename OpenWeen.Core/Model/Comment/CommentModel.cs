using Newtonsoft.Json;
using OpenWeen.Core.Model;
using OpenWeen.Core.Model.Status;
using OpenWeen.Core.Model.User;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeen.Core.Model.Comment
{
    public class CommentModel
    {
        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }
        public DateTime CreateTime => DateTime.ParseExact(CreatedAt, "ddd MMM dd HH:mm:ss K yyyy", CultureInfo.InvariantCulture);
        [JsonProperty("id")]
        public long ID { get; set; }
        [JsonProperty("text")]
        public string Text { get; set; }
        [JsonProperty("source_allowclick")]
        public int SourceAllowClick { get; set; }
        [JsonProperty("source_type")]
        public int SourceType { get; set; }
        [JsonProperty("source")]
        public string Source { get; set; }
        [JsonProperty("mid")]
        public long MID { get; set; }
        [JsonProperty("idstr")]
        public string IDStr { get; set; }
        [JsonProperty("status")]
        public MessageModel Status { get; set; }
        [JsonProperty("reply_comment")]
        public CommentModel ReplyComment { get; set; }
        [JsonProperty("user")]
        public UserModel User { get; set; }
    }
}
