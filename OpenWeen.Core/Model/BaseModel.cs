using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        [JsonProperty("source")]
        public string Source { get; set; }
    }
}
