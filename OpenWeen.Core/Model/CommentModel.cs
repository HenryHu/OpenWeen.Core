using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeen.Core.Model
{
    public class CommentModel : MessageModel
    {
        [JsonProperty("status")]
        public MessageModel Status { get; set; }
        [JsonProperty("reply_comment")]
        public CommentModel ReplyComment { get; set; }
    }
}
