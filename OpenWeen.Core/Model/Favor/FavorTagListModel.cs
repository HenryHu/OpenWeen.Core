using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
