using Newtonsoft.Json;

namespace OpenWeen.Core.Model.Favor
{
    public class FavorTagModel
    {
        [JsonProperty("id")]
        public long ID { get; set; }

        [JsonProperty("tag")]
        public string Tag { get; set; }
    }
}