using System;
using System.Globalization;
using Newtonsoft.Json;
using OpenWeen.Core.Model.User;

namespace OpenWeen.Core.Model
{
    public class BaseModel
    {
        [JsonProperty("id")]
        public long ID { get; set; }

        [JsonProperty("mid")]
        public long MID { get; set; }

        [JsonProperty("idstr")]
        public string IDStr { get; set; }

        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        public DateTime CreateTime => DateTime.ParseExact(CreatedAt, "ddd MMM dd HH:mm:ss K yyyy", CultureInfo.InvariantCulture);

        [JsonProperty("text")]
        public string Text { get; set; }
        
        [JsonProperty("source_allowclick")]
        public int SourceAllowclick { get; set; }

        [JsonProperty("source_type")]
        public int SourceType { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("user")]
        public UserModel User { get; set; }

        public bool IsRepostList { get; set; }
    }
}