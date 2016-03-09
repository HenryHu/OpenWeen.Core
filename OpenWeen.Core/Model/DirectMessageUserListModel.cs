using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeen.Core.Model
{
    public class DirectMessageUserListModel : BaseModel
    {
        [JsonProperty("user_list")]
        public List<DirectMessageUserModel> UserList { get; set; }
    }
}
