using System.Collections.Generic;
using Newtonsoft.Json;

namespace OpenWeen.Core.Model.Block
{
    public class BlockListModel : BaseListModel
    {
        [JsonProperty("users")]
        public List<BlockModel> Users { get; set; }
    }
}