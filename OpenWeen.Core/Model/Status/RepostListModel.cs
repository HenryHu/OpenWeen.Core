using System.Collections.Generic;
using Newtonsoft.Json;

namespace OpenWeen.Core.Model.Status
{
    public class RepostListModel : BaseListModel
    {
        [JsonProperty("reposts")]
        public List<MessageModel> Reposts { get; set; }

        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}