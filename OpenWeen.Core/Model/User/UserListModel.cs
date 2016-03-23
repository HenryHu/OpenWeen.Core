using Newtonsoft.Json;
using OpenWeen.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeen.Core.Model.User
{
    public class UserListModel : BaseListModel
    {
        [JsonProperty("users")]
        public List<UserModel> Users { get; set; }
    }
}
