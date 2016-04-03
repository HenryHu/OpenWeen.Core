using System.Collections.Generic;
using Newtonsoft.Json;
using OpenWeen.Core.Model.Status;

namespace OpenWeen.Core.Model.Favor
{
    public class FavorModel
    {
        [JsonProperty("status")]
        public MessageModel Status { get; set; }

        [JsonProperty("favorited_time")]
        public string FavoritedTime { get; set; }

        [JsonProperty("tags")]
        public List<FavorTagModel> Tags { get; set; }
    }
}