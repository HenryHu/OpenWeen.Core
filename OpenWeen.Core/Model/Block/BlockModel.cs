using System;
using System.Globalization;
using Newtonsoft.Json;
using OpenWeen.Core.Model.User;

namespace OpenWeen.Core.Model.Block
{
    public class BlockModel
    {
        [JsonProperty("user")]
        public UserModel User { get; set; }

        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        public DateTime CreateTime => DateTime.ParseExact(CreatedAt, "ddd MMM dd HH:mm:ss K yyyy", CultureInfo.InvariantCulture);
    }
}