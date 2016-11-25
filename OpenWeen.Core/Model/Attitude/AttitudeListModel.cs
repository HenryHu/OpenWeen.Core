using Newtonsoft.Json;
using System.Collections.Generic;
namespace OpenWeen.Core.Model.Attitude
{
    public class AttitudeListModel
    {
        [JsonProperty("attitudes")]
        public IList<AttitudeModel> Attitudes { get; set; }

        [JsonProperty("hasvisible")]
        public bool Hasvisible { get; set; }

        [JsonProperty("previous_cursor")]
        public int PreviousCursor { get; set; }

        [JsonProperty("next_cursor")]
        public long NextCursor { get; set; }

        [JsonProperty("total_number")]
        public int TotalNumber { get; set; }

        [JsonProperty("interval")]
        public int Interval { get; set; }
    }
}
