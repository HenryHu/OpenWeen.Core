using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeen.Core.Model
{
    public class UserListModel : BaseModel
    {
        [JsonProperty("users")]
        public List<UserModel> Users { get; set; }
    }
}
