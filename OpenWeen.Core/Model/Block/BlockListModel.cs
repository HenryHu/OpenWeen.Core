using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeen.Core.Model.Block
{
    public class BlockListModel : BaseListModel
    {
        [JsonProperty("users")]
        public List<BlockModel> Users { get; set; }
    }
}
