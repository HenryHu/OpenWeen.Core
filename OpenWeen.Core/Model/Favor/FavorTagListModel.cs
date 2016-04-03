using System.Collections.Generic;
using Newtonsoft.Json;

namespace OpenWeen.Core.Model.Favor
{
    public class FavorTagListModel
    {
        [JsonProperty("tags")]
        public List<FavorTagModel> Tags { get; set; }

        [JsonProperty("total_number")]
        public int TotalNumber { get; set; }
    }
}