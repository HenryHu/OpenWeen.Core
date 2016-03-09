using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
