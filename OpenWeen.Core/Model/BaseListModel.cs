using Newtonsoft.Json;

namespace OpenWeen.Core.Model
{
    public class BaseListModel
    {
        [JsonProperty("previous_cursor")]
        public string PreviousCursor { get; set; }

        [JsonProperty("next_cursor")]
        public string NextCursor { get; set; }

        [JsonProperty("total_number")]
        public int TotalNumber { get; set; }
    }
}