using Newtonsoft.Json;

namespace OpenWeen.Core.Model.Status
{
    public class GroupModel
    {
        [JsonProperty("id")]
        public long ID { get; set; }

        [JsonProperty("idstr")]
        public string IDStr { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}