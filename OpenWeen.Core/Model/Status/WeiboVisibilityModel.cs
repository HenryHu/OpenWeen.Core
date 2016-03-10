using Newtonsoft.Json;
using OpenWeen.Core.Model.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeen.Core.Model.Status
{
    public class WeiboVisibilityModel
    {
        [JsonProperty("type")]
        public WeiboVisibility Visibility { get; set; }
        [JsonProperty("list_id")]
        public int ListID { get; set; }
    }
}
