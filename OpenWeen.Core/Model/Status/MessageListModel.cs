using System.Collections.Generic;
using Newtonsoft.Json;

namespace OpenWeen.Core.Model.Status
{
    public class MessageListModel : BaseListModel
    {
        [JsonProperty("statuses")]
        public List<MessageModel> Statuses { get; set; }

        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}