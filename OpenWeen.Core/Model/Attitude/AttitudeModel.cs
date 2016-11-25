using Newtonsoft.Json;
using OpenWeen.Core.Model.User;
using OpenWeen.Core.Model.Status;
namespace OpenWeen.Core.Model.Attitude
{
    public class AttitudeModel
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        [JsonProperty("attitude")]
        public string Attitude { get; set; }

        [JsonProperty("attitude_type")]
        public int AttitudeType { get; set; }

        [JsonProperty("last_attitude")]
        public string LastAttitude { get; set; }

        [JsonProperty("source_allowclick")]
        public int SourceAllowclick { get; set; }

        [JsonProperty("source_type")]
        public int SourceType { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("user")]
        public UserModel User { get; set; }

        [JsonProperty("status")]
        public MessageModel Status { get; set; }
    }
}