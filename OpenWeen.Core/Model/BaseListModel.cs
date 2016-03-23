using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
