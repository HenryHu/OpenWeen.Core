using System.Collections.Generic;
using Newtonsoft.Json;

namespace OpenWeen.Core.Model.DirectMessage
{
    public class DirectMessageListModel : BaseListModel
    {
        [JsonProperty("direct_messages")]
        public List<DirectMessageModel> DirectMessages { get; set; }
    }
}