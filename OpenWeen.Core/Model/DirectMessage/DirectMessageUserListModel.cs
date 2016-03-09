﻿using Newtonsoft.Json;
using OpenWeen.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeen.Core.Model.DirectMessage
{
    public class DirectMessageUserListModel : BaseModel
    {
        [JsonProperty("user_list")]
        public List<DirectMessageUserModel> UserList { get; set; }
    }
}