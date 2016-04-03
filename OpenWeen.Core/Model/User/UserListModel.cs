using System.Collections.Generic;
using Newtonsoft.Json;

namespace OpenWeen.Core.Model.User
{
    public class UserListModel : BaseListModel
    {
        [JsonProperty("users")]
        public List<UserModel> Users { get; set; }
    }
}