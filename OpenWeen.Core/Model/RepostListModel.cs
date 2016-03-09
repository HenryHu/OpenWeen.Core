using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeen.Core.Model
{
    public class RepostListModel : BaseListModel
    {
        [JsonProperty("reposts")]
        public List<MessageModel> Reposts { get; set; }
        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}
