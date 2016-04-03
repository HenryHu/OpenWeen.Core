using System.Collections.Generic;
using Newtonsoft.Json;

namespace OpenWeen.Core.Model.Favor
{
    public class FavorListModel
    {
        [JsonProperty("favorites")]
        public List<FavorModel> Favorites { get; set; }

        [JsonProperty("total_number")]
        public int TotalNumber { get; set; }
    }
}