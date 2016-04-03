using System.Collections.Generic;
using Newtonsoft.Json;

namespace OpenWeen.Core.Model.Status
{
    public class GroupListModel : BaseListModel
    {
        [JsonProperty("lists")]
        public List<GroupModel> Lists { get; set; }
    }
}