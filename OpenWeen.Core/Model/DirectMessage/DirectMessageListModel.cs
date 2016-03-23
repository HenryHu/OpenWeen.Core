using Newtonsoft.Json;
using OpenWeen.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeen.Core.Model.DirectMessage
{
    public class DirectMessageListModel : BaseListModel
    {
        [JsonProperty("direct_messages")]
        public List<DirectMessageModel> DirectMessages { get; set; }
    }
}
