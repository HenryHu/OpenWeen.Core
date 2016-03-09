using Newtonsoft.Json;
using OpenWeen.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeen.Core.Model.Status
{
    public class MessageListModel : BaseListModel
    {
        [JsonProperty("statuses")]
        public List<MessageModel> Statuses { get; set; }
        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}
