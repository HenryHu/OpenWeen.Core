using Newtonsoft.Json;
using OpenWeen.Core.Model.User;

namespace OpenWeen.Core.Model.DirectMessage
{
    public class DirectMessageUserModel
    {
        [JsonProperty("user")]
        public UserModel User { get; set; }

        [JsonProperty("direct_message")]
        public DirectMessageModel DirectMessage { get; set; }
    }
}