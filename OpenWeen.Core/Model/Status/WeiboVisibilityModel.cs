using Newtonsoft.Json;
using OpenWeen.Core.Model.Types;

namespace OpenWeen.Core.Model.Status
{
    public class WeiboVisibilityModel
    {
        [JsonProperty("type")]
        public WeiboVisibility Visibility { get; set; }

        [JsonProperty("list_id")]
        public int ListID { get; set; }
    }
}