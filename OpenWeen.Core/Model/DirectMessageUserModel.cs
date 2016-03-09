using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeen.Core.Model
{
    public class DirectMessageUserModel
    {
        [JsonProperty("user")]
        public string User { get; set; }
        [JsonProperty("direct_message")]
        public DirectMessageModel DirectMessage { get; set; }
    }
}
