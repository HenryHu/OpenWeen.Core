using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
