using Newtonsoft.Json;
using OpenWeen.Core.Model;
using OpenWeen.Core.Model.User;
using OpenWeen.Core.Model.Status;
namespace OpenWeen.Core.Model.Attitude
{
    public class AttitudeModel : BaseModel
    {
        [JsonProperty("attitude")]
        public string Attitude { get; set; }

        [JsonProperty("attitude_type")]
        public int AttitudeType { get; set; }

        [JsonProperty("last_attitude")]
        public string LastAttitude { get; set; }
        
        [JsonProperty("status")]
        public MessageModel Status { get; set; }
    }
}