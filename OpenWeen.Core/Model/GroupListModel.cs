using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeen.Core.Model
{
    public class GroupListModel : BaseModel
    {
        [JsonProperty("lists")]
        public List<GroupModel> Lists { get; set; }
    }
}
