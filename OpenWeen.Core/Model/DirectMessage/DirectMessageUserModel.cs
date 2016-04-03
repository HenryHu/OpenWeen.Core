using Newtonsoft.Json;

namespace OpenWeen.Core.Model.DirectMessage
{
    public class DirectMessageUserModel
    {
        [JsonProperty("user")]
        public string User { get; set; }

        [JsonProperty("direct_message")]
        public DirectMessageModel DirectMessage { get; set; }
    }
}