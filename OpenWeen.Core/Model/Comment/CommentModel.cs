using System.Collections.Generic;
using Newtonsoft.Json;
using OpenWeen.Core.Model.Status;

namespace OpenWeen.Core.Model.Comment
{
    public class CommentModel : BaseModel
    {
        [JsonProperty("source_allowclick")]
        public int SourceAllowClick { get; set; }

        [JsonProperty("source_type")]
        public int SourceType { get; set; }

        [JsonProperty("status")]
        public MessageModel Status { get; set; }

        [JsonProperty("reply_comment")]
        public CommentModel ReplyComment { get; set; }

        [JsonProperty("pic_infos")]
        public IDictionary<string, PicInfoModel> PicInfos { get; set; }

        [JsonProperty("pic_ids")]
        public string[] PicIds { get; set; }

    }

    
}