using Newtonsoft.Json;
using OpenWeen.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeen.Core.Model.Status
{
    public class GroupListModel : BaseListModel
    {
        [JsonProperty("lists")]
        public List<GroupModel> Lists { get; set; }
    }
}
