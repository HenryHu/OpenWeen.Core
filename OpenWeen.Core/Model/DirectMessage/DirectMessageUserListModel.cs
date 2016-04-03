using System.Collections.Generic;
using Newtonsoft.Json;

namespace OpenWeen.Core.Model.DirectMessage
{
    public class DirectMessageUserListModel : BaseListModel
    {
        [JsonProperty("user_list")]
        public List<DirectMessageUserModel> UserList { get; set; }
    }
}